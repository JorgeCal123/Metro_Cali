
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
        public  string RELATIVE_PATH_STOPS = "C:/Users/juanm/OneDrive/Documentos/ICESI/6to/Integrador/stops.csv";
        public  string RELATIVE_PATH_DATAGRAM = "C:/Users/juanm/OneDrive/Documentos/ICESI/6to/Integrador/integ/DATAGRAMS.csv";
        public  string RELATIVE_PATH_BUS = "C:/Users/juanm/OneDrive/Documentos/ICESI/6to/Integrador/buses.csv"; 

        private Hashtable northStops;
        private Hashtable eastStops;
        private Hashtable southStops;
        private Hashtable westStops;

        private Hashtable westStations;
        private Hashtable northStations;
        private Hashtable eastStations;
        private Hashtable southStations;

        Hashtable stops;
        Hashtable stations;
        Hashtable bus1;
        GenericTime realTime;

        //Constructor 
        public Managment()
        {
            westStops = new Hashtable();
            eastStops = new Hashtable();
            northStops = new Hashtable();
            southStops = new Hashtable();

            westStations = new Hashtable();
            eastStations = new Hashtable();
            northStations = new Hashtable();
            southStations = new Hashtable();

            Stops = new Hashtable();
            Stations = new Hashtable();
            Bus1 = new Hashtable();

            //                        año dia mes min hor seg
            RealTime = new GenericTime(18, 01, 11, 35, 5, 25, "AM");

            loadStops();
            createBus();
            timeReading();
         
        }

   
        public void selectStops(String stopsFile)
        {
            RELATIVE_PATH_STOPS = stopsFile;
        }

        public void selectDatagram(String datagramFile)
        {
            RELATIVE_PATH_DATAGRAM = datagramFile;
        }

        public void selectBus(String busFile)
        {
            RELATIVE_PATH_BUS = busFile;
        }


        //Lee todas las paradas del archivo Stops y agrega las estaciones
        private void loadStops()
        {
            StreamReader reader = new StreamReader(RELATIVE_PATH_STOPS);
            string line = reader.ReadLine();         
            line = reader.ReadLine();


            while (line != null)
            {
                string[] datos = line.Split(',');

                if (!datos[6].Equals("0")|| !datos[7].Equals("0")) {
                    //                 Stop Id, Plan Version,   Short Name, Long Name, Gps x,    Gps Y
                    Stop a = new Stop((datos[0]), (datos[1]), datos[2], datos[3], datos[6], datos[7]);
                    if (isWestZone(a))
                    {
                        if (isStop(a.ShortName))
                        {
                            if (!westStations.ContainsKey(datos[0]))
                            {
                                westStations.Add(datos[0], a);
                            }
                        }
                        else
                        {
                            if (!westStops.ContainsKey(datos[0]))
                            {
                                westStops.Add(datos[0], a);
                            }
                        }
                    }
                    else if (isNorthZone(a) || isCenterZone(a))
                    {
                        if (isStop(a.ShortName))
                        {
                            if (!northStations.ContainsKey(datos[0]))
                            {
                                northStations.Add(datos[0], a);
                            }
                        }
                        else
                        {
                            if (!northStops.ContainsKey(datos[0]))
                            {
                                northStops.Add(datos[0], a);
                            }
                        }
                    }
                    else if (isEastZone(a))
                    {
                        if (isStop(a.ShortName))
                        {
                            if (!eastStations.ContainsKey(datos[0]))
                            {
                                eastStations.Add(datos[0], a);
                            }
                        }
                        else
                        {
                            if (!eastStops.ContainsKey(datos[0]))
                            {
                                eastStops.Add(datos[0], a);
                            }
                        }
                    }
                    else
                    {
                        if (isStop(a.ShortName))
                        {
                            if (!southStations.ContainsKey(datos[0]))
                            {
                                southStations.Add(datos[0], a);
                            }
                        }
                        else
                        {
                            if (!southStops.ContainsKey(datos[0]))
                            {
                                southStops.Add(datos[0], a);
                            }
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
                        ShortName.Contains("FRAY") || ShortName.Contains("SANBO") ||
                        ShortName.Contains("SANIC") ||
                        ShortName.Contains("L.AME") || ShortName.Contains("LIDO") ||
                        ShortName.Contains("MANZA") || ShortName.Contains("MZAN") ||
                        ShortName.Contains("N.LATIR") || ShortName.Contains("PAM") ||
                        ShortName.Contains("PTCU") || ShortName.Contains("PILO") ||
                        ShortName.Contains("CAY") || ShortName.Contains("PLATO") ||
                        ShortName.Contains("POPU") || ShortName.Contains("PRAD") ||
                        ShortName.Contains("PRIMI") || ShortName.Contains("REFU") ||
                        ShortName.Contains("SALO") || ShortName.Contains("SANP") ||
                        ShortName.Contains("SNT") || ShortName.Contains("ST.") ||
                        ShortName.Contains("STRO") || ShortName.Contains("SUC") ||
                        ShortName.Contains("CALS") || ShortName.Contains("PCO") ||
                        ShortName.Contains("T.C-") || ShortName.Contains("TEQU") ||
                        ShortName.Contains("A.SAN") || ShortName.Contains("TCAL") ||
                        ShortName.Contains("TMEN") || ShortName.Contains("TOR") ||
                        ShortName.Contains("UDP") || ShortName.Contains("UNIV") ||
                        ShortName.Contains("VERS") || ShortName.Contains("CONQ") ||
                        ShortName.Contains("CALD") || ShortName.Contains("CAPRI") ||
                        ShortName.Contains("CEN") || ShortName.Contains("CHAPI") ||
                        ShortName.Contains("RIO") || ShortName.Contains("ERMI") ||
                        ShortName.Contains("BELA") || ShortName.Contains("BUITRE") ||
                        ShortName.Contains("TREB") || ShortName.Contains("TRON") ||
                        ShortName.Contains("VLN") || ShortName.Contains("VIC") ||
                        ShortName.Contains("VIP"))

            {
                existe = true;
            } 
            if (ShortName.Contains("VBUITRE") || ShortName.Contains("COL_FRAY")
                || ShortName.Contains("V_BUI") || ShortName.Contains("AV-MELE")
                || ShortName.Contains("V_CAS") || ShortName.Contains("VBUI")
                || ShortName.Contains("AV-MELEN"))
            {
                existe = false;
            }
                return existe;
        }

        public bool isWestZone(Stop a)
        {
            bool salida = false;
            double latitud = Double.Parse(a.Gps_Y, CultureInfo.InvariantCulture);
            double longitud = Double.Parse(a.Gps_X, CultureInfo.InvariantCulture);
            if ((latitud >= 3.440161 && longitud <= -76.536702)
                && (latitud <= 3.462857 && longitud >= -76.578708)
                || (latitud >= 3.422367 && longitud <= -76.547611)//3.422367, -76.547611
                || (latitud >= 3.440478 && longitud <= -76.559365)//3.440478, -76.559365
                || (latitud >= 3.432271 && longitud <= -76.543115) //3.432271, -76.543115
                )
            {
                salida = true;
            }
            return salida;
        }

        public bool isEastZone(Stop a)
        {
            bool salida = false;
            double latitud = Double.Parse(a.Gps_Y, CultureInfo.InvariantCulture);
            double longitud = Double.Parse(a.Gps_X, CultureInfo.InvariantCulture);

            if ((latitud >= 3.406574 && longitud >= -76.521705 //3.406574, -76.521705
                && latitud <= 3.463656 && longitud <= -76.457907)
                || (latitud <= 3.428325 && longitud >= -76.533173
                && latitud >= 3.401965 && longitud <= -76.448308)
                || (latitud <= 3.402450 && longitud >= -76.522392)//3.402450, -76.522392
                && (latitud >= 3.391370 && longitud <= -76.454762) //3.391370, -76.454762
                )
            {
                salida = true;
            }
            if ((latitud == 3.43970167 && longitud == -76.522745) || (latitud == 3.43980417 && longitud == -76.52290361))
            {
                salida = true;
            } 
            return salida;
        }

        public bool isCenterZone(Stop a)
        {
            bool salida = false;
            double latitud = Double.Parse(a.Gps_Y, CultureInfo.InvariantCulture);
            double longitud = Double.Parse(a.Gps_X, CultureInfo.InvariantCulture);
            if (latitud >= 3.440856 && longitud >= -76.536904   //3.440856, -76.536904
                && latitud <= 3.460096 && longitud <= -76.521034)//3.460096, -76.521034
            {
                salida = true;
            }
            return salida;
        }

        public bool isNorthZone(Stop a)
        {
            bool salida = false;
            double latitud = Double.Parse(a.Gps_Y, CultureInfo.InvariantCulture);
            double longitud = Double.Parse(a.Gps_X, CultureInfo.InvariantCulture);
            if ((latitud >= 3.451321 && longitud >= -76.537168) //3.451321, -76.537168
                && (latitud <= 3.510002 && longitud <= -76.472321)) //3.510002, -76.472321
            {
                salida = true;
            }
            return salida;
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
            StreamReader sr = new StreamReader(RELATIVE_PATH_DATAGRAM);
        
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
                        Console.WriteLine(line);
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
            StreamReader lector = new StreamReader(RELATIVE_PATH_BUS);
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
        public Hashtable WestStops { get => westStops; set => westStops = value; }
        public Hashtable NorthStops { get => northStops; set => northStops = value; }
        public Hashtable EastStops { get => eastStops; set => eastStops = value; }
        public Hashtable SouthStops { get => southStops; set => southStops = value; }
        public Hashtable WestStations { get => westStations; set => westStations = value; }
        public Hashtable NorthStations { get => northStations; set => northStations = value; }
        public Hashtable EastStations { get => eastStations; set => eastStations = value; }
        public Hashtable SouthStations { get => southStations; set => southStations = value; }
    }


}
