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

namespace MioMap
{
    public partial class Form1 : Form
    {
     
        Managment model;
        double latInicial = 3.437584;
        double lonInicial = -76.525843;
        GMapOverlay timeBusStatus;
        GMapOverlay onlyStops;
        GMapOverlay onlyStations;
        GroupBox options;
        Hashtable busMovement;
        GMapOverlay onlyBus ;
        int vel = 1;
        String idBus;


        //inicializa todos los componentes y atributos
        public Form1()
        {
            InitializeComponent();
            model = new Managment();
            options = new GroupBox();
            timeBusStatus = new GMapOverlay();
            onlyStations = new GMapOverlay();
            onlyStops = new GMapOverlay();
            onlyBus = new GMapOverlay();
            busMovement = new Hashtable();
        }


        // Muestra todas las estaciones 
        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gMapControl1.Overlays.Clear();
            gMapControl1.Overlays.Add(onlyStations);

            gMapControl1.Zoom = gMapControl1.Zoom + 1;
            gMapControl1.Zoom = gMapControl1.Zoom - 1;
        }


        //Muestra todas las paradas
        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gMapControl1.Overlays.Clear();
            gMapControl1.Overlays.Add(onlyStops);
            gMapControl1.Zoom = gMapControl1.Zoom + 1;
            gMapControl1.Zoom = gMapControl1.Zoom - 1;
        }


        private void Label1_Click(object sender, EventArgs e)
        {
        }

        private void GMapControl1_Load(object sender, EventArgs e)
        {
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
            
        }

     
        //Muestra todas las paradas
        public void printStops()
        {
            Bitmap b = (Bitmap)Image.FromFile("./2.png");

            ICollection keys = model.Stops.Keys;

            foreach(String a in keys)
            {
                double la = double.Parse(((Stop)(model.Stops[a])).Gps_Y, CultureInfo.InvariantCulture);
                double lon = double.Parse(((Stop)(model.Stops[a])).Gps_X, CultureInfo.InvariantCulture);
                onlyStops.Markers.Add(new GMarkerGoogle(new PointLatLng(la, lon), b));
            }
            
        }

        //Muestra todas las estaciones
        public void printStations()
        {
            Bitmap b = (Bitmap)Image.FromFile("./4.png");

            ICollection keys = model.Stations.Keys;
            foreach (String a in keys)
            {
                double la = double.Parse(((Stop)(model.Stations[a])).Gps_Y, CultureInfo.InvariantCulture);
                double lon = double.Parse(((Stop)(model.Stations[a])).Gps_X, CultureInfo.InvariantCulture);
                onlyStations.Markers.Add(new GMarkerGoogle(new PointLatLng(la, lon), b));
            }
            
        }

        
        //Muestra todas las paradas y estaciones
        private void rbTodo_CheckedChanged(object sender, EventArgs e)
        {
            gMapControl1.Overlays.Clear();
            gMapControl1.Overlays.Add(onlyStations);
            gMapControl1.Overlays.Add(onlyStops);
            gMapControl1.Zoom = gMapControl1.Zoom + 1;
            gMapControl1.Zoom = gMapControl1.Zoom - 1;
        }


        //Mueve un bus de acuerdo al id del bus que el usuario ingrese
        private void Button2_Click(object sender, EventArgs e)
        {
            onlyBus.Markers.Clear();

            idBus = InputDialog.mostrar("Escriba el id del bus");
           if (idBus != null) {
                timer2.Enabled = true;
            }
        }

    

     
       


        //Pone en movimiento primer timer( El reloj )y busca los buses que se van a mover en ese tiempo
        private void Timer1_Tick(object sender, EventArgs e)
        {
            
            model.RealTime.passSecond();
            UbicationTime.Text = model.RealTime.showTime();
            searchBusByDate(model.RealTime.generateDataTime());
       


        }
        //Busca los buses que tienen por llave " la hora y fecha Actual"
        public void searchBusByDate(String date)
        {
          //  onlyBus.Clear();

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

                if (((Bus)model.Bus1[actual]).Visit == true)
                {
                    GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(la, lon), activo);
                    marker.ToolTipText = String.Format("Bus del Mio:\n Placa:{0} \n latitud:{1} \n longitud{2}", ((Bus)model.Bus1[actual]).NumberPlate, la, lon);
                    onlyBus.Markers.Add(marker);

                }
                else
                {
                    GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(la, lon), inactivo);
                    marker.ToolTipText = String.Format("Placa:{0} \n latitud:{1} \n longitud{2}", ((Bus)model.Bus1[actual]).NumberPlate, la, lon);
                    onlyBus.Markers.Add(marker);

                }

            }
            gMapControl1.Overlays.Add(onlyBus);
            gMapControl1.Refresh();

        }
    
        // Pone en mmarcha el primer timer
        private void Button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
         
        }

        
       // Pone en Pausa los 2 timer (el reloj de todos los buses y el de un bus)
        private void Button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
        }

      

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        //pone en movimiento el hilo del reloj de un solo bus
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
        //Limpia todos los makers que se pintaron en el mapa
        private void Button4_Click_1(object sender, EventArgs e)
        {
            gMapControl1.Overlays.Clear();
            onlyBus.Markers.Clear();
            onlyStops.Markers.Clear();
            onlyStations.Markers.Clear();

        }


        //Aumenta la velocidad del hilo de mover todos los buses
        private void Button6_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Interval -= 100;
                timer2.Interval -= 100;
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("velocidad maxima");

            }



         //   Console.WriteLine(timer1.Interval);
        }



        //Disminuye la velocidad del hilo de mover todos los buses

        private void Button5_Click(object sender, EventArgs e)
        {
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
    }

      
    
}
