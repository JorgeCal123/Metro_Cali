using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using modelo;
using InputKey;

using System;
using System.Collections;
using System.Globalization;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.IO;

namespace MioMap
{
    public partial class Form1 : Form
    {

        Managment model;
        double latInicial = 3.437584;
        double lonInicial = -76.525843;
        Boolean Activo;
        Hashtable busMovement;

        GMapOverlay timeBusStatus;

        GMapOverlay westStops;
        GMapOverlay northStops;
        GMapOverlay southStops;
        GMapOverlay eastStops;

        GMapOverlay westStations;
        GMapOverlay northStations;
        GMapOverlay southStations;
        GMapOverlay eastStations;

        GMapOverlay onlyStops;
        GMapOverlay onlyStations;
        GMapOverlay onlyBus;
        GMapOverlay onlyPolygon;
        GMapOverlay onlyStationStops;

        String idBus;


        //Construtor
        public Form1()
        {
            InitializeComponent();
            model = new Managment();
            Activo = false;
            timeBusStatus = new GMapOverlay();
            onlyStations = new GMapOverlay();
            onlyStops = new GMapOverlay();
            onlyBus = new GMapOverlay();
            onlyPolygon = new GMapOverlay();
            onlyStationStops = new GMapOverlay();
            busMovement = new Hashtable();

            westStations = new GMapOverlay();
            northStations = new GMapOverlay();
            southStations = new GMapOverlay();
            eastStations = new GMapOverlay();

            westStops = new GMapOverlay();
            northStops = new GMapOverlay();
            southStops = new GMapOverlay();
            eastStops = new GMapOverlay();
        }



        // inicializa Commponentes y atributos del gmap
        private void Form1_Load(object sender, EventArgs e)
        {
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
            printStations();
            PrintPolygons();
        }


        //Carga todas las paradas que no sean de una estacion
        public void printStops()
        {
            Bitmap b = (Bitmap)Image.FromFile("./2.png");

            ICollection westKeys = model.WestStops.Keys;
            ICollection northKeys = model.NorthStops.Keys;
            ICollection southKeys = model.SouthStops.Keys;
            ICollection eastKeys = model.EastStops.Keys;

            foreach (String a in westKeys)
            {

                double la = double.Parse(((Stop)(model.WestStops[a])).Gps_Y, CultureInfo.InvariantCulture);
                double lon = double.Parse(((Stop)(model.WestStops[a])).Gps_X, CultureInfo.InvariantCulture);
                westStops.Markers.Add(new GMarkerGoogle(new PointLatLng(la, lon), b));
            }

            foreach (String a in northKeys)
            {

                double la = double.Parse(((Stop)(model.NorthStops[a])).Gps_Y, CultureInfo.InvariantCulture);
                double lon = double.Parse(((Stop)(model.NorthStops[a])).Gps_X, CultureInfo.InvariantCulture);
                northStops.Markers.Add(new GMarkerGoogle(new PointLatLng(la, lon), b));

            }

            foreach (String a in southKeys)
            {

                double la = double.Parse(((Stop)(model.SouthStops[a])).Gps_Y, CultureInfo.InvariantCulture);
                double lon = double.Parse(((Stop)(model.SouthStops[a])).Gps_X, CultureInfo.InvariantCulture);
                southStops.Markers.Add(new GMarkerGoogle(new PointLatLng(la, lon), b));

            }

            foreach (String a in eastKeys)
            {

                double la = double.Parse(((Stop)(model.EastStops[a])).Gps_Y, CultureInfo.InvariantCulture);
                double lon = double.Parse(((Stop)(model.EastStops[a])).Gps_X, CultureInfo.InvariantCulture);
                eastStops.Markers.Add(new GMarkerGoogle(new PointLatLng(la, lon), b));

            }
        }

        public void printStations()
        {
            Bitmap b = (Bitmap)Image.FromFile("./4.png");

            ICollection westKeys = model.WestStations.Keys;
            ICollection northKeys = model.NorthStations.Keys;
            ICollection southKeys = model.SouthStations.Keys;
            ICollection eastKeys = model.EastStations.Keys;
            int estaciones = 0;
            try
            {
                foreach (String a in westKeys)
                {

                    double la = double.Parse(((Stop)(model.WestStations[a])).Gps_Y, CultureInfo.InvariantCulture);
                    double lon = double.Parse(((Stop)(model.WestStations[a])).Gps_X, CultureInfo.InvariantCulture);
                    westStations.Markers.Add(new GMarkerGoogle(new PointLatLng(la, lon), b));
                }

                foreach (String a in northKeys)
                {

                    double la = double.Parse(((Stop)(model.NorthStations[a])).Gps_Y, CultureInfo.InvariantCulture);
                    double lon = double.Parse(((Stop)(model.NorthStations[a])).Gps_X, CultureInfo.InvariantCulture);
                    northStations.Markers.Add(new GMarkerGoogle(new PointLatLng(la, lon), b));
                }

                foreach (String a in southKeys)
                {

                    double la = double.Parse(((Stop)(model.SouthStations[a])).Gps_Y, CultureInfo.InvariantCulture);
                    double lon = double.Parse(((Stop)(model.SouthStations[a])).Gps_X, CultureInfo.InvariantCulture);
                    southStations.Markers.Add(new GMarkerGoogle(new PointLatLng(la, lon), b));
                }

                foreach (String a in eastKeys)
                {

                    double la = double.Parse(((Stop)(model.EastStations[a])).Gps_Y, CultureInfo.InvariantCulture);
                    double lon = double.Parse(((Stop)(model.EastStations[a])).Gps_X, CultureInfo.InvariantCulture);
                    eastStations.Markers.Add(new GMarkerGoogle(new PointLatLng(la, lon), b));
                }
            }
            catch (NullReferenceException)
            {
                estaciones++;
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
                ICollection keyStop = estacion.Stops.Keys;


                la = double.Parse(estacion.Ubi.Latitud, CultureInfo.InvariantCulture);
                lon = double.Parse(estacion.Ubi.Longitud, CultureInfo.InvariantCulture);
                GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(la, lon), imageStation);
                marker.ToolTipText = String.Format("Estacion:{0}\n latitud:{1} \n longitud{2}", estacion.LongName, la, lon);
                onlyStations.Markers.Add(marker);

                foreach (String i in keyStop)
                {
                    Stop paradaEstacion = ((Stop)estacion.Stops[i]);

                    //      Console.WriteLine("Tiene la parada: " + ((Stop)estacion.Stops[i]).StopId);
                    la = double.Parse(((Stop)estacion.Stops[i]).Gps_Y, CultureInfo.InvariantCulture);
                    lon = double.Parse(((Stop)estacion.Stops[i]).Gps_X, CultureInfo.InvariantCulture);
                    //      Console.WriteLine(((Stop)estacion.Stops[i]).ShortName+"   Punto: " + " latitud "+lat+" Longitud "+lont);
                    //  GMarkerGoogle markerStopp = new GMarkerGoogle(new PointLatLng(la, lon), imageStation);

                    GMarkerGoogle markerStop = new GMarkerGoogle(new PointLatLng(la, lon), imageStop);
                    markerStop.ToolTipText = String.Format("Estacion:{0}\n Parada:{1}\nlatitud:{2} \n longitud{3}", estacion.LongName, paradaEstacion.ShortName, la, lon);
                    onlyStationStops.Markers.Add(markerStop);

                    PointLatLng p = new PointLatLng(la, lon);
                    puntos.Add(p);
                }

                GMapPolygon poligono = new GMapPolygon(puntos, "");
                poligono.Stroke = new Pen(new SolidBrush(Color.FromArgb(255, 255, 0, 0)), 2);
                poligono.Fill = new SolidBrush(Color.FromArgb(0, 0, 0, 0));
                onlyPolygon.Polygons.Add(poligono);
            }


        }


        // Radiobutton que Muestra todas las estaciones 
        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Activo = true;
            clearMap();
            gMapControl1.Overlays.Add(onlyStations);
            gMapControl1.Zoom = gMapControl1.Zoom + 1;
            gMapControl1.Zoom = gMapControl1.Zoom - 1;

        }


        //Radiobutton que Muestra todas las paradas que no estan en una estacion
        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Activo = false;
            clearMap();

            gMapControl1.Overlays.Add(onlyStops);
            gMapControl1.Zoom = gMapControl1.Zoom + 1;
            gMapControl1.Zoom = gMapControl1.Zoom - 1;
        }

        //Radiobutton que Muestra todas las paradas y estaciones
        private void rbTodo_CheckedChanged(object sender, EventArgs e)
        {
            Activo = false;
            clearMap();
            gMapControl1.Overlays.Add(onlyStationStops);
            gMapControl1.Overlays.Add(onlyStops);
            gMapControl1.Overlays.Add(onlyStations);

            gMapControl1.Zoom = gMapControl1.Zoom + 1;
            gMapControl1.Zoom = gMapControl1.Zoom - 1;


            prueba();
        }





        private void Label1_Click(object sender, EventArgs e)
        {
        }

        private void GMapControl1_Load(object sender, EventArgs e)
        {

        }


        //Mueve un bus de acuerdo al id del bus que el usuario ingrese
        private void Button2_Click(object sender, EventArgs e)
        {
            Activo = false;

            idBus = InputDialog.mostrar("Escriba el id del bus");
            if (idBus != null)
            {
                timer2.Enabled = true;
            }
        }



        //Pone en movimiento el primer timer( El reloj ) de todos los buses que se van a mover en ese tiempo
        private void Timer1_Tick(object sender, EventArgs e)
        {

            model.RealTime.passSecond();
            UbicationTime.Text = model.RealTime.showTime();
            Console.WriteLine(model.RealTime.generateDataTime());
            searchBusByDate(model.RealTime.generateDataTime());

        }

        //Busca los buses que tienen por llave " la hora y fecha Actual"
        public void searchBusByDate(String date)
        {

            ICollection keys = model.Bus1.Keys;

            foreach (String actual in keys)
            {
                Bus busActual = (Bus)model.Bus1[actual];
                busActual.Visit = false;

                if (busActual.UbicationTime.ContainsKey(date))
                {
                    busActual.Visit = true;

                    if (!busMovement.ContainsKey(busActual.BusId))
                    {
                        busMovement.Add(busActual.BusId, ((Ubication)busActual.UbicationTime[date]));
                    }
                    else
                    {
                        busMovement[busActual.BusId] = ((Ubication)busActual.UbicationTime[date]);

                    }
                }
            }
            PaintBus();
        }


        //pinta los buses de azul que estan activos en la hora actual  y los pinta de rojo sino se estan en movimiento en la hora actual
        public void PaintBus()
        {
            onlyBus.Markers.Clear();
            Bitmap activo = (Bitmap)Image.FromFile("./activo.png");
            Bitmap inactivo = (Bitmap)Image.FromFile("./inactivo.png");

            ICollection keyid = busMovement.Keys;
            foreach (String actual in keyid)
            {
                double la = double.Parse(((Ubication)busMovement[actual]).Latitud);
                double lon = double.Parse(((Ubication)busMovement[actual]).Longitud);

                if (((Bus)model.Bus1[actual]).Visit == false)
                {
                  
                    GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(la, lon), inactivo);
                    marker.ToolTipText = String.Format("Placa:{0} \n latitud:{1} \n longitud{2}", ((Bus)model.Bus1[actual]).NumberPlate, la, lon);
                    onlyBus.Markers.Add(marker);
                }
                else
                {
                    GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(la, lon), activo);
                    marker.ToolTipText = String.Format("Bus del Mio:\n Placa:{0} \n latitud:{1} \n longitud{2}", ((Bus)model.Bus1[actual]).NumberPlate, la, lon);
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

            timer1.Enabled = false;
            timer2.Enabled = false;
        }



        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        //pone en movimiento el segundo timer (el reloj) de un solo bus
        private void Timer2_Tick(object sender, EventArgs e)
        {
            model.RealTime.passSecond();
            UbicationTime.Text = model.RealTime.generateDataTime();
            prinMoveOneBus(model.RealTime.generateDataTime(), idBus);

        }

        //Solo pinta el bus que le entra por parametro
        private void prinMoveOneBus(string date, string idBus)
        {
            //    Console.WriteLine(model.Bus1.ContainsKey(idBus));

            if (model.Bus1.ContainsKey(idBus))
            {
                Bus busActual = (Bus)model.Bus1[idBus];
                if (busActual.UbicationTime.ContainsKey(date))
                {
                    double la = double.Parse(((Ubication)busActual.UbicationTime[date]).Latitud);
                    double lon = double.Parse(((Ubication)busActual.UbicationTime[date]).Longitud);

                    onlyBus.Markers.Add(new GMarkerGoogle(new PointLatLng(la, lon), GMarkerGoogleType.blue_dot));

                }
                gMapControl1.Overlays.Add(onlyBus);
                gMapControl1.Refresh();
            }

            gMapControl1.Overlays.Clear();

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




        private void GMapControl1_OnMapZoomChanged()
        {
            if (Activo == true)
            {

                if (gMapControl1.Zoom <= 16)
                {
                    clearMap();
                    gMapControl1.Overlays.Add(onlyStations);
                }
                else
                {
                    clearMap();
                    gMapControl1.Overlays.Add(onlyStationStops);
                    gMapControl1.Overlays.Add(onlyPolygon);
                }
            }
        }


        public void prueba()
        {
            string rutaCompleta = "D:/Trabajos/Trabajos sexto/Proyecto integrador/Proyecto Metro Cali/Datos/data 2/mi archivo.txt";
            ICollection keyid = ((Bus)model.Bus1["1"]).UbicationTime.Keys;

            using (StreamWriter file = new StreamWriter(rutaCompleta, true))
            {
                foreach (String actual in keyid)
                {
                    file.WriteLine(actual);

                }
                file.Close();
            }

           
        
        }

        private void cbZonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbEstaciones.Checked = false;
            cbParadas.Checked = false;
            cbTodo.Checked = false;
        }

        private void cbTodo_CheckedChanged(object sender, EventArgs e)
        {
            limpiarOpciones();
            gMapControl1.Overlays.Clear();
            if (cbZonas.SelectedItem.Equals("Zona Norte"))
            {
                gMapControl1.Overlays.Add(northStations);
                gMapControl1.Overlays.Add(northStops);
            }
            else if (cbZonas.SelectedItem.Equals("Zona Oeste"))
            {
                gMapControl1.Overlays.Add(westStations);
                gMapControl1.Overlays.Add(westStops);
            }
            else if (cbZonas.SelectedItem.Equals("Zona Oriente"))
            {
                gMapControl1.Overlays.Add(eastStations);
                gMapControl1.Overlays.Add(eastStops);
            }
            else if (cbZonas.SelectedItem.Equals("Zona Sur"))
            {
                gMapControl1.Overlays.Add(southStations);
                gMapControl1.Overlays.Add(southStops);
            }
        }

        private void cbParadas_CheckedChanged(object sender, EventArgs e)
        {
            limpiarOpciones();
            gMapControl1.Overlays.Clear();
            if (cbZonas.SelectedItem.Equals("Zona Norte"))
            {
                gMapControl1.Overlays.Add(northStops);
            }
            else if (cbZonas.SelectedItem.Equals("Zona Oeste"))
            {
                gMapControl1.Overlays.Add(westStops);
            }
            else if (cbZonas.SelectedItem.Equals("Zona Oriente"))
            {
                gMapControl1.Overlays.Add(eastStops);
            }
            else if (cbZonas.SelectedItem.Equals("Zona Sur"))
            {
                gMapControl1.Overlays.Add(southStops);
            }
        }

        private void cbEstaciones_CheckedChanged(object sender, EventArgs e)
        {
            limpiarOpciones();
            gMapControl1.Overlays.Clear();
            if (cbZonas.SelectedItem.Equals("Zona Norte"))
            {
                gMapControl1.Overlays.Add(northStations);
            }
            else if (cbZonas.SelectedItem.Equals("Zona Oeste"))
            {
                gMapControl1.Overlays.Add(westStations);
            }
            else if (cbZonas.SelectedItem.Equals("Zona Oriente"))
            {
                gMapControl1.Overlays.Add(eastStations);
            }
            else if (cbZonas.SelectedItem.Equals("Zona Sur"))
            {
                gMapControl1.Overlays.Add(southStations);
            }
        }

        public void limpiarOpciones()
        {
            if (cbTodo.Checked)
            {
                cbEstaciones.Checked = false;
                cbParadas.Checked = false;
            }
            else if (cbParadas.Checked)
            {
                cbTodo.Checked = false;
                cbEstaciones.Checked = false;
            }
            else
            {
                cbParadas.Checked = false;
                cbTodo.Checked = false;
            }
            gMapControl1.Refresh();
        }
    }

  
    
}
