
using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelo
{
    public class Managment
    {
        const string ABSOLUTE_PATH_STOPS = "D:/Trabajos/Trabajos sexto/Proyecto integrador/Proyecto Metro Cali/Datos/data/stops.csv";
        const string ABSOLUTE_PATH_DATAGRAM = "D:/Trabajos/Trabajos sexto/Proyecto integrador/Proyecto Metro Cali/Datos/data 2/DATAGRAMS.csv";
        const string ABSOLUTE_PATH_BUS = "D:/Trabajos/Trabajos sexto/Proyecto integrador/Proyecto Metro Cali/Datos/data/buses.csv";

        Hashtable stops;
        Hashtable stations;
        Hashtable bus1;
        GenericTime realTime;

        //Constructor 
        public Managment()
        {
            Stops = new Hashtable();
            Stations = new Hashtable();
            Bus1 = new Hashtable();

            //                        año dia mes min hor seg
            RealTime = new GenericTime(18, 01, 11, 35, 5, 25, "AM");

            loadStops();
            createBus();
            timeReading();
         
        }

   


        //Lee todas las paradas del archivo Stops y agrega las estaciones
        private void loadStops()
        {
            StreamReader reader = new StreamReader(ABSOLUTE_PATH_STOPS);
            string line = reader.ReadLine();         
            line = reader.ReadLine();


            while (line != null)
            {
                string[] datos = line.Split(',');

                if (!datos[6].Equals("0")|| !datos[7].Equals("0")) {
                    //                 Stop Id, Plan Version,   Short Name, Long Name, Gps x,    Gps Y
                    Stop a = new Stop((datos[0]), (datos[1]), datos[2], datos[3], datos[6], datos[7]);
                    if (isStop(a.ShortName) == true)
                    {
                        if (!Stations.ContainsKey(datos[0]))
                        {
                            CreateStation(a);
                        }
                    }
                    else
                    {
                        if (!Stops.ContainsKey(datos[0]))
                        {

                            Stops.Add(datos[0], a);
                        }
                    }

                    
                }
                else
                {
                    line = reader.ReadLine();

                }

                line = reader.ReadLine();

            }
            reader.Close();
        }

        public Boolean isStop(String ShortName)
        {
            Boolean existe = false;

            if (ShortName.Contains("7-ago") || ShortName.Contains("ALA") ||
               ShortName.Contains("AMAN") || ShortName.Contains("ATG") ||
               ShortName.Contains("CHIM") || ShortName.Contains("C.PALOS") ||
               ShortName.Contains("MELEN") || ShortName.Contains("ESTAD") ||
               ShortName.Contains("FATI") || ShortName.Contains("FLOR") ||
               ShortName.Contains("FRAY") || ShortName.Contains("HORMI") ||
               ShortName.Contains("L.AME") || ShortName.Contains("LIDO") ||
               ShortName.Contains("MANZA") || ShortName.Contains("MZAN") ||
               ShortName.Contains("N.LATIR") || ShortName.Contains("PAM") ||
               ShortName.Contains("PTCU") || ShortName.Contains("PILO") ||
               ShortName.Contains("CAY") || ShortName.Contains("PLATO") ||
               ShortName.Contains("POPU") || ShortName.Contains("PRAD") ||
               ShortName.Contains("PRIMI") || ShortName.Contains("REFU") ||
               ShortName.Contains("SALO") || ShortName.Contains("SAN") ||
               ShortName.Contains("SNT") || ShortName.Contains("ST.") ||
               ShortName.Contains("STRO") || ShortName.Contains("SUC") ||
               ShortName.Contains("CALS") || ShortName.Contains("PCO") ||
               ShortName.Contains("T.C-") || ShortName.Contains("TEQU") ||
               ShortName.Contains("SAN") || ShortName.Contains("TCAL") ||
               ShortName.Contains("TMEN") || ShortName.Contains("TOR") ||
               ShortName.Contains("UDP") || ShortName.Contains("UNIV") ||
               ShortName.Contains("VERS") || ShortName.Contains("CONQ") ||
               ShortName.Contains("CALD") || ShortName.Contains("CAP") ||
               ShortName.Contains("CEN") || ShortName.Contains("CHAP") ||
                ShortName.Contains("RIO") || ShortName.Contains("ERMI") ||
               ShortName.Contains("BELA") || ShortName.Contains("BUIT") ||
               ShortName.Contains("TREB") || ShortName.Contains("TRON") ||
               ShortName.Contains("VLN") || ShortName.Contains("VIC") ||
               ShortName.Contains("VIP"))

            {
                existe = true;
            }
                return existe;

        }

        public String nameStop(String stp)
        {
            String name = "";
            char[] charsToTrim1 = { '1', '2', '3', '4', '5', '6', '7', '8', '9', };
            char[] charsToTrim2 = { '0', 'A', 'B', 'C', 'N' };
            char[] charsToTrim3 = { '1', 'A', 'M' };

            string[] words = stp.Split();
            foreach (string word in words) {
                String a1 = word.TrimEnd(charsToTrim1);
                String a2 = a1.TrimEnd(charsToTrim2);
                String a3 = a2.TrimEnd(charsToTrim3);

                name = a3;
            }
        
            return name;
        }



        public void CreateStation(Stop a)
        {
          String  las = a.Gps_X;
            las.Replace(',', '.');
         String   lons = a.Gps_Y;
            lons.Replace(',', '.');

            Boolean existeStop = false;
            Station existente = null;

            ICollection keyStop = Stations.Keys;
            foreach (String key in keyStop)
            {

                if (nameStop(((Station)stations[key]).ShortName).Equals(nameStop(a.ShortName)))
                {

                    existeStop = true;
                    existente = ((Station)stations[key]);
                    break;
                }
            }

            if (existeStop == true)
            {

                (existente).addStop(a.ShortName, a);
            }
            else
            {
                Ubication ubi = new Ubication(lons, las);
                Station b = new Station(a.StopId, a.PlanVersionId, a.ShortName, a.LongName, ubi);

                b.addStop(a.ShortName, a);

                Stations.Add(a.StopId, b);
            }
        }

        public int cont = 1;




        public void timeReading()

        {
            StreamReader sr = new StreamReader(ABSOLUTE_PATH_DATAGRAM);
        
            String line = sr.ReadLine();
            line = sr.ReadLine();
            while (line != null)
            {

                String[] dato = line.Split(',');

                Boolean terminado = false;
                while (!terminado)
                {
                    if (dato[4].Equals("-1") || dato[5].Equals("-1"))
                    {
                        line = sr.ReadLine();
                        dato = line.Split(',');
                    }
                    else
                    {
                        terminado = true;
                    }
                }
                if (cont < 1048575)
                {
                    String lat = dato[4].Insert(1, ",");
                    String lon = dato[5].Insert(3, ",");

                    if (bus1.ContainsKey(dato[11]))
                    {
                   
                        ((Bus)bus1[dato[11]]).addTime(lat, lon, dato[10]);

                    }
                    cont++;

                    line = sr.ReadLine();
                }
                else
                {
                    line = null;
                }
            }
            sr.Close();
            Console.WriteLine("cargado");
        }

       public void loadPorcentage()
        {
            int total = 1048575;
            double porcentaje = cont / total;
        }
     

        public void createBus()
        {
            StreamReader lector = new StreamReader(ABSOLUTE_PATH_BUS);
            String line = lector.ReadLine();
            line = lector.ReadLine();
            while (line != null)
            {
                String[] bus = line.Split(',');
                if (!bus1.ContainsKey(bus[0]))
                {
                    if (bus[2].Equals(""))
                    {
                        Bus nuevo = new Bus(bus[0], "Sin placa");
                        bus1.Add(bus[0], nuevo);

                    }
                    else
                    {
                        Bus nuevo = new Bus(bus[0], bus[2]);
                        bus1.Add(bus[0], nuevo);

                    }
                }
                            line = lector.ReadLine();


            }
        }


        public Hashtable Stops { get => stops; set => stops = value; }
        public Hashtable Stations { get => stations; set => stations = value; }
        public Hashtable Bus1 { get => bus1; set => bus1 = value; }
        public GenericTime RealTime { get => realTime; set => realTime = value; }

    }


}
