using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using modelo;

using System;
using System.Collections;
using System.Globalization;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.IO;

using System.Linq;
namespace MioMap
{
    public partial class Form1 : Form
    {

        Managment model;
        Hashtable busMovement;
        Hashtable routeMovement;
        // List<CheckBox> routeList;

       // GMapOverlay timeBusStatus;

        GMapOverlay onlyStops;
        GMapOverlay onlyStations;
        GMapOverlay onlyBus;
        GMapOverlay onlyPolygon;
        GMapOverlay onlyStationStops;

        GMapOverlay onlywest;
        GMapOverlay onlynorth;
        GMapOverlay onlysouth;
        GMapOverlay onlyeast;

        Boolean Activo;
        Boolean optionStop;
        Boolean optionStation;
        Boolean optionAll;

        ICollection Selection;
        DialogRouteBus dialogRoute;

        public ICollection Selection1 { get => Selection; set => Selection = value; }


        //Construtor
        public Form1()
        {
            InitializeComponent();
            Activo = false;
            optionAll = false;
            optionStation = false;
            optionStop = false;
            model = new Managment();

            busMovement = new Hashtable();
            routeMovement = new Hashtable();
            dialogRoute = new DialogRouteBus(model, this);


            //  timeBusStatus = new GMapOverlay();
            onlyStations = new GMapOverlay();
            onlyStops = new GMapOverlay();
            onlyBus = new GMapOverlay();
            onlyPolygon = new GMapOverlay();
            onlyStationStops = new GMapOverlay();

            onlywest = new GMapOverlay();
            onlynorth = new GMapOverlay();
            onlysouth = new GMapOverlay();
            onlyeast = new GMapOverlay();

        }

     

        // inicializa Commponentes y atributos del gmap
        private void Form1_Load(object sender, EventArgs e)
        {
            double latInicial = 3.437584;
            double lonInicial = -76.525843;
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(latInicial, lonInicial);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 12;
            gMapControl1.AutoScroll = true;
            gMapControl1.ShowCenter = false;

            printStops();
            PrintPolygons();
        }



        //Carga todas las paradas que no sean de una estacion
        public void printStops()
        {
            Bitmap imageStop = (Bitmap)Image.FromFile("./2.png");

            ICollection keys = model.Stops.Keys;

            foreach (String a in keys)
            {
                Stop parada = (Stop)(model.Stops[a]);
                double la = double.Parse(parada.Gps_Y, CultureInfo.InvariantCulture);
                double lon = double.Parse(parada.Gps_X, CultureInfo.InvariantCulture);


                GMarkerGoogle markerStop = new GMarkerGoogle(new PointLatLng(la, lon), imageStop);
                markerStop.ToolTipText = String.Format("Parada:{0}\nlatitud:{1} \n longitud{2}", parada.LongName, la, lon);
                onlyStops.Markers.Add(markerStop);

                if (parada.Zona.Equals(Ubication.ZONE_EAST))
                {
                    onlyeast.Markers.Add(markerStop);
                }
                else if (parada.Zona.Equals(Ubication.ZONE_NORTH))
                {
                    onlynorth.Markers.Add(markerStop);
                }
                else if (parada.Zona.Equals(Ubication.ZONE_WEST))
                {
                    onlywest.Markers.Add(markerStop);
                }
                else
                {
                    onlysouth.Markers.Add(markerStop);
                }
            }

        }




        //Carga las estaciones, las paradas que estan en las estaciones y los poligonos
        public void PrintPolygons()
        {
            Bitmap imageStation = (Bitmap)Image.FromFile("./4.png");
            Bitmap imageStop = (Bitmap)Image.FromFile("./2.png");
            double la;
            double lon;

            ICollection keys = model.Stations.Keys;

            foreach (String a in keys)
            {
                List<PointLatLng> puntos = new List<PointLatLng>();
                Station estacion = ((Station)model.Stations[a]);


                la = double.Parse(estacion.Ubi.Latitud, CultureInfo.InvariantCulture);
                lon = double.Parse(estacion.Ubi.Longitud, CultureInfo.InvariantCulture);

                GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(la, lon), imageStation);
                marker.ToolTipText = String.Format("Estacion:{0}\n latitud:{1} \n longitud{2}", estacion.LongName, la, lon);
                onlyStations.Markers.Add(marker);

                if (estacion.Zone.Equals(Ubication.ZONE_EAST))
                {
                    onlyeast.Markers.Add(marker);
                }
                else if (estacion.Zone.Equals(Ubication.ZONE_NORTH))
                {
                    onlynorth.Markers.Add(marker);
                }
                else if (estacion.Zone.Equals(Ubication.ZONE_WEST))
                {
                    onlywest.Markers.Add(marker);
                }
                else
                {
                    onlysouth.Markers.Add(marker);
                }
                ICollection keyStop = estacion.Stops.Keys;
                foreach (String i in keyStop)
                {
                    Stop paradaEstacion = ((Stop)estacion.Stops[i]);

                    la = double.Parse(((Stop)estacion.Stops[i]).Gps_Y, CultureInfo.InvariantCulture);
                    lon = double.Parse(((Stop)estacion.Stops[i]).Gps_X, CultureInfo.InvariantCulture);

                    GMarkerGoogle markerStop = new GMarkerGoogle(new PointLatLng(la, lon), imageStop);
                    markerStop.ToolTipText = String.Format("Estacion:{0}\n Parada:{1}\nlatitud:{2} \n longitud{3}", estacion.LongName, paradaEstacion.ShortName, la, lon);
                    onlyStationStops.Markers.Add(markerStop);

                    PointLatLng p = new PointLatLng(la, lon);

                    puntos.Add(p);
                }
                puntos = GetConvexHull(puntos);
                GMapPolygon poligono = new GMapPolygon(puntos, "");
                poligono.Stroke = new Pen(new SolidBrush(Color.FromArgb(255, 255, 0, 0)), 2);
                poligono.Fill = new SolidBrush(Color.FromArgb(0, 0, 0, 0));
                onlyPolygon.Polygons.Add(poligono);
            }


        }

        //Organiza cada una de los poligonos en orden 
        public static List<PointLatLng> GetConvexHull(List<PointLatLng> points)
        {
            if (points == null)
                return null;

            if (points.Count() <= 1)
                return points;

            int n = points.Count(), k = 0;
            List<PointLatLng> H = new List<PointLatLng>(new PointLatLng[2 * n]);
            points.Sort((a, b) =>
                 a.Lat == b.Lat ? a.Lng.CompareTo(b.Lng) : a.Lat.CompareTo(b.Lat));


            for (int i = 0; i < n; ++i)
            {
                while (k >= 2 && cross(H[k - 2], H[k - 1], points[i]) <= 0)
                    k--;
                H[k++] = points[i];
            }

            // Build upper hull
            for (int i = n - 2, t = k + 1; i >= 0; i--)
            {
                while (k >= t && cross(H[k - 2], H[k - 1], points[i]) <= 0)
                    k--;
                H[k++] = points[i];
            }

            return H.Take(k - 1).ToList();
        }

        public static double cross(PointLatLng O, PointLatLng A, PointLatLng B)
        {
            return (A.Lat - O.Lat) * (B.Lng - O.Lng) - (A.Lng - O.Lng) * (B.Lat - O.Lat);
        }


        // Radiobutton que Muestra todas las estaciones 
        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Activo = true;
            clearMap();
            pause();

            optionStation = true ;
            optionStop =false ;
            optionAll = false;
           gMapControl1.Zoom = gMapControl1.Zoom + 1;
           gMapControl1.Zoom = gMapControl1.Zoom - 1;

        }


        //Radiobutton que Muestra todas las paradas que no estan en una estacion
        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Activo = true;
            pause();

            clearMap();
            optionStation = false;
            optionStop = true;
            optionAll = false;
            gMapControl1.Overlays.Add(onlyStops);
            gMapControl1.Zoom = gMapControl1.Zoom + 1;
            gMapControl1.Zoom = gMapControl1.Zoom - 1;
        }

        //Radiobutton que Muestra todas las paradas y estaciones
        private void rbTodo_CheckedChanged(object sender, EventArgs e)
        {
            Activo = true;
            pause();
            clearMap();
            optionStation = false;
            optionStop = false;
            optionAll = true;
      

            gMapControl1.Zoom = gMapControl1.Zoom + 1;
            gMapControl1.Zoom = gMapControl1.Zoom - 1;


            //prueba();
        }




        //Pone en movimiento el primer timer( El reloj ) de todos los buses que se van a mover en ese tiempo
        private void Timer1_Tick(object sender, EventArgs e)
        {
            
            model.RealTime.passSecond();
            Lb_UbicationTime.Text = model.RealTime.showTime();
            searchBusByDate(model.RealTime.generateDataTime());

        }

        //Busca los buses que tienen por llave " la hora y fecha Actual"
        public void searchBusByDate(String date)
        {
            clearMap();
            ICollection keys = model.Bus1.Keys;

            foreach (String actual in keys)
            {
                Bus busActual = (Bus)model.Bus1[actual];
                busActual.Visit = false;
                Ubication ubi = ((Ubication)busActual.UbicationTime[date]);
                if (busActual.UbicationTime.ContainsKey(date))
                {
                    busActual.Visit = true;
                  
                   
                        if (!busMovement.ContainsKey(busActual.BusId))
                        {
                            busMovement.Add(busActual.BusId, ubi);
                        }
                        else
                        {
                            busMovement[busActual.BusId] = ubi;

                        }
                    
                }
            }
            paintbusComplatetZone();
        }


        //pinta los buses de azul que estan activos en la hora actual  y los pinta de rojo sino estan en movimiento despues de 3 minutos
        public void paintbusComplatetZone()
        {
            onlyBus.Markers.Clear();
            Bitmap activo = (Bitmap)Image.FromFile("./activo.png");
            Bitmap inactivo = (Bitmap)Image.FromFile("./inactivo.png");

            ICollection keyid = busMovement.Keys;
            foreach (String actual in keyid)
            {
                double la = double.Parse(((Ubication)busMovement[actual]).Latitud);
                double lon = double.Parse(((Ubication)busMovement[actual]).Longitud);

                Bus busA = ((Bus)model.Bus1[actual]);

                if (busA.Visit == false)
                {

                        busA.inactividad();
                        if (busA.Inactivo == 180)
                        {
                            busA.activo();
                            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(la, lon), inactivo);
                            marker.ToolTipText = String.Format("Bus:{0} \n Ruta:{1} \nPlaca:{2} \n latitud:{3} \n longitud{4}", busA.ShortName, busA.LongName, busA.NumberPlate, la, lon);
                            onlyBus.Markers.Add(marker);
                        }
                        else
                        {
                            GMarkerGoogle marker2 = new GMarkerGoogle(new PointLatLng(la, lon), activo);
                            marker2.ToolTipText = String.Format("Bus:{0}\nRuta:{1}\nPlaca:{2}\n latitud:{3}\nlongitud{4}", busA.ShortName, busA.LongName, busA.NumberPlate, la, lon);
                            onlyBus.Markers.Add(marker2);
                        }
                    }
                    else
                    {
                        GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(la, lon), activo);
                        marker.ToolTipText = String.Format("Bus:{0}\nRuta:{1}\nPlaca:{2}\n latitud:{3}\nlongitud{4}", busA.ShortName, busA.LongName, busA.NumberPlate, la, lon);
                        onlyBus.Markers.Add(marker);
                    }
                }
            
            gMapControl1.Overlays.Add(onlyBus);
            gMapControl1.Refresh();

        }


     
        // Pone en marcha el primer timer
        private void Button1_Click(object sender, EventArgs e)
        {
            Activo = false;

            timer1.Enabled = true;

        }


        // Pone en Pausa los 2 timer (el reloj de todos los buses y el de un bus)
        private void Button3_Click(object sender, EventArgs e)
        {
            Activo = false;
            pause();
        }

        // Pausa todos los timer (reloj de rutas y de todos los buses)
        public void pause()
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
        }


        //Muestra el panel para seleccionar las rutas que se van a mover
        private void Button2_Click(object sender, EventArgs e)
        {
            Activo = false;
            pause();
            dialogRoute.ShowDialog();
            clearMap();
            onlyBus.Markers.Clear();

        }

        //pone en movimiento el segundo timer (el reloj) de las rutas

        internal void StartTimer()
        {
           // onlyBus.Markers.Clear();
            routeMovement.Clear();
            timer2.Enabled = true;

        }

        //pone en movimiento el reloj y busca las rutas que se moveran en ese tiempo
        private void Timer2_Tick(object sender, EventArgs e)
        {

            model.RealTime.passSecond();
            Lb_UbicationTime.Text = model.RealTime.showTime();
            searchRouteByDate(model.RealTime.generateDataTime());

        }
   
        //Solo pinta el bus que le entra por parametro
        private void searchRouteByDate(string date)
        {
            clearMap();
            foreach (String b in Selection)
            {
                ICollection busSelection = searchByRoutes(b);
                Bitmap activo = (Bitmap)Image.FromFile("./activo.png");

                foreach (String encontrado in busSelection)
                {

                    if (model.Bus1.ContainsKey(encontrado))
                    {

                        Bus busActual = (Bus)model.Bus1[encontrado];
                        if (busActual.UbicationTime.ContainsKey(date))
                        {
                           
                            Ubication ubi = ((Ubication)busActual.UbicationTime[date]);
                            if (!routeMovement.ContainsKey(busActual.BusId))
                            {
                                routeMovement.Add(busActual.BusId, ubi);
                            }
                            else
                            {
                                routeMovement[busActual.BusId] = ubi;

                            }
                      
                        }
                        
                    }
                }
             
            }
            paintRoute();
        }


        //pinta todos los buses que se van a mover dependiendo de las rutas que se escogieron
        public void paintRoute()
        {
            onlyBus.Markers.Clear();
            Bitmap activo = (Bitmap)Image.FromFile("./activo.png");

            ICollection keyid = routeMovement.Keys;
            foreach (String actual in keyid)
            {
                double la = double.Parse(((Ubication)routeMovement[actual]).Latitud);
                double lon = double.Parse(((Ubication)routeMovement[actual]).Longitud);

                Bus busA = ((Bus)model.Bus1[actual]);
              
                    GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(la, lon), activo);
                    marker.ToolTipText = String.Format("Bus:{0} \n Ruta:{1} \nPlaca:{2} \n latitud:{3} \n longitud{4}", busA.ShortName, busA.LongName, busA.NumberPlate, la, lon);
                    onlyBus.Markers.Add(marker);
               
            }
            gMapControl1.Overlays.Add(onlyBus);
            gMapControl1.Refresh();

        }


        //Busca los buses de acuerdo a la ruta escogida
        public List<String> searchByRoutes(String ruta)
        {
            List<String> list = new List<String>();
            ICollection buses = model.Bus1.Keys;
            foreach (String b in buses)
            {
                if (((Bus)model.Bus1[b]).ShortName != null)
                {
                    if (((Bus)model.Bus1[b]).ShortName.Equals(ruta))
                    {
                        list.Add(((Bus)model.Bus1[b]).BusId);
                      //  Console.WriteLine("Se agrega el id " + ((Bus)model.Bus1[b]).BusId);
                    }
                }
            }

            return list;
        }


        //Limpia todos los  que se haya pintado en el mapa
        private void clearMap()
        {
            gMapControl1.Overlays.Clear();

        }


        //Aumenta la velocidad del hilo de mover todos los buses
        private void Button6_Click(object sender, EventArgs e)
        {
            Activo = false;

            try
            {
                timer1.Interval -= 100;
                timer2.Interval -= 100;
               // time_Max_Min.Text = "x" + ((timer1.Interval));
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("velocidad maxima");

            }


        }



        //Disminuye la velocidad del hilo de mover todos los buses
        private void Button5_Click(object sender, EventArgs e)
        {
            Activo = false;

            if (timer1.Interval >= 1000 || timer2.Interval >= 1000)
            {
                MessageBox.Show("velocidad minima");
            }
            else
            {
                timer1.Interval += 100;
                timer2.Interval += 100;
            }
        }

        //Muestra las paradas si estan lejos y los poligonos si estan cerca
        private void GMapControl1_OnMapZoomChanged()
        {
            if (Activo == true)
            {

                if (gMapControl1.Zoom <= 15)
                {
                    if (optionStation==true) {
                        clearMap();
                        gMapControl1.Overlays.Add(onlyStations);
                    }
                  
                    else if (optionAll == true)
                    {
                        clearMap();
                        gMapControl1.Overlays.Add(onlyStops);
                        gMapControl1.Overlays.Add(onlyStations);

                    }
                }
                else
                {
                    if (optionStation == true)
                    {
                        clearMap();
                        gMapControl1.Overlays.Add(onlyStationStops);
                        gMapControl1.Overlays.Add(onlyPolygon);
                    }
                   
                    else if (optionAll == true)
                    {
                        gMapControl1.Overlays.Add(onlyStops);
                        gMapControl1.Overlays.Add(onlyStationStops);
                        gMapControl1.Overlays.Add(onlyPolygon);
                    }
                }
            }
        }


    

       

        //Muestra las estaciones y paradas por zonas
        private void CbZonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearMap();
            pause();

            Activo = false;

            if (cbZonas.SelectedItem.Equals(Ubication.ZONE_NORTH))
            {
                gMapControl1.Overlays.Add(onlynorth);
                gMapControl1.Zoom = gMapControl1.Zoom + 1;
                gMapControl1.Zoom = gMapControl1.Zoom - 1;
            }
            else if (cbZonas.SelectedItem.Equals(Ubication.ZONE_WEST))
            {
                gMapControl1.Overlays.Add(onlywest);
                gMapControl1.Zoom = gMapControl1.Zoom + 1;
                gMapControl1.Zoom = gMapControl1.Zoom - 1;
            }
            else if (cbZonas.SelectedItem.Equals(Ubication.ZONE_EAST))
            {
                gMapControl1.Overlays.Add(onlyeast);
                gMapControl1.Zoom = gMapControl1.Zoom + 1;
                gMapControl1.Zoom = gMapControl1.Zoom - 1;
            }
            else if (cbZonas.SelectedItem.Equals(Ubication.ZONE_SOUTH))
            {
                gMapControl1.Overlays.Add(onlysouth);
                gMapControl1.Zoom = gMapControl1.Zoom + 1;
                gMapControl1.Zoom = gMapControl1.Zoom - 1;
            }
        }

       

    }

  
    
}
