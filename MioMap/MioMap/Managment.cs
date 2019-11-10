
using MioMap;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace modelo
{
    public class Managment
    {
       
        const string ABSOLUTE_PATH_DIRECTION = "./direcciones.txt";

        private string rELATIVE_PATH_STOPS;
        private string rELATIVE_PATH_BUS;
        private string rELATIVE_PATH_DATAGRAM;
        private string rELATIVE_PATH_LINES;

        Hashtable stops;
        Hashtable stations;
        Hashtable bus1;
        Hashtable routes;

        GenericTime realTime;

        DialogDataAddress LoadDate;
        Form2 progress;

        //Constructor 
        public Managment()
        {
            Routes = new Hashtable();
            Stops = new Hashtable();
            Stations = new Hashtable();
            Bus1 = new Hashtable();

            absolutePath();
            //                        año dia mes min hor seg
            RealTime = new GenericTime(18, 01, 11, 35, 5, 25, "AM");

            LoadDate = new DialogDataAddress(this);
            Load();
        }

        //Carga rutas absolutas que eastn guardadas en un archivo
        public void absolutePath()
        {
            StreamReader reader = new StreamReader(ABSOLUTE_PATH_DIRECTION);

            string line = reader.ReadLine();

            while (line != null)
            {
                String[] datos = line.Split(',');
                if (datos[0].Equals("1"))
                {
                    RELATIVE_PATH_STOPS = datos[1];
                }
                else if (datos[0].Equals("2"))
                {
                    RELATIVE_PATH_DATAGRAM = datos[1];
                }
                else if (datos[0].Equals("3"))
                {
                    RELATIVE_PATH_BUS = datos[1];
                }
                else if (datos[0].Equals("4"))
                {
                    RELATIVE_PATH_LINES = datos[1];
                }
                line = reader.ReadLine();
            }
            reader.Close();
         
        }


        //Cambia las rutas que estan guardadas en un archivo
        public void editAbsolutePath(int id_Line, String nRuta)
        {
            string[] lineas = File.ReadAllLines(ABSOLUTE_PATH_DIRECTION);

            foreach (string linea in lineas)
            {
                string[] partes = linea.Split(',');
                Console.WriteLine("Se va a remplazar    "+id_Line );

                if ((id_Line+"").Equals(partes[0]))
                {
                    lineas[id_Line-1] = id_Line + "," + nRuta;
                    Console.WriteLine(id_Line+"   "+ nRuta);
                    
                }

            }

            File.WriteAllLines(ABSOLUTE_PATH_DIRECTION, lineas);
            absolutePath();
        }

      
        //Cargo todos los datos necesarios para la aplicacion
        public void Load()
        {
            loadStops();
            createBus();
            timeReading();
        }




        //Lee todas las paradas del archivo Stops y agrega las estaciones
        public void loadStops()
        {
            try
            {
                StreamReader reader = new StreamReader(RELATIVE_PATH_STOPS);


                string line = reader.ReadLine();
                line = reader.ReadLine();


                while (line != null)
                {
                    string[] datos = line.Split(',');

                    if (!datos[6].Equals("0") || !datos[7].Equals("0"))
                    {
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
                                a.Zona = getZona(a);
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
            catch (DirectoryNotFoundException dnf)
            {
                LoadDate.ErrorStop("No se encuentra el archivo stop");
                if (LoadDate.Estado == false)
                {
                    LoadDate.Hide();
                    LoadDate.DialogError();
                    LoadDate.ShowDialog();
                    LoadDate.Estado = true;
                }

            }


            catch (ArgumentException ae)
            {
                LoadDate.ErrorStop("Archivo equivocado de stop");
                if (LoadDate.Estado == false)
                {
                    LoadDate.DialogError();
                    LoadDate.ShowDialog();
                    LoadDate.Estado = true;
                }
            }
            catch (IndexOutOfRangeException ae)
            {
                LoadDate.ErrorStop("Archivo equivocado de stop");
                if (LoadDate.Estado == false)
                {
                    LoadDate.DialogError();
                    LoadDate.ShowDialog();
                    LoadDate.Estado = true;
                }
            }
           
        }


        //Revisa si es una parada o una estacion 
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

        //Construye el nombre de las paradas quitando letras y numeros extras
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

        //Confirma si una parada se encuentra en el este
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

        //Confirma si una parada se encuentra en el oeste

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
            return salida;
        }


        //Confirma si una parada se encuentra en el norte

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

        public string getZona(Stop parada)
        {
            String zona = "";
            if (isNorthZone(parada) == true)
            {
                zona = Ubication.ZONE_NORTH;
            }
            else if (isEastZone(parada) == true)
            {
                zona = Ubication.ZONE_EAST;
            }
            else if (isWestZone(parada) == true)
            {
                zona = Ubication.ZONE_WEST;
            }
            else
            {
                zona = Ubication.ZONE_SOUTH;
            }


            return zona;
        }


        // Crea una estacion
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
                b.Zone = getZona(a);
                b.addStop(a.ShortName, a);

                Stations.Add(a.StopId, b);
            }
        }

        public int cont = 1;


        //Le asigna a todos los buses la hora y la posicion que se va mover
        public void timeReading()
        {
            try
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
                            if (!(dato[7].Equals("-1")))
                            {
                                //    Console.WriteLine("3ntra "+dato[7]);

                                ((Bus)bus1[dato[11]]).IdLine = dato[7];
                            }
                        }
                        cont++;
                        //     progress.porcentaje(cont);
                        line = sr.ReadLine();
                    }
                    else
                    {
                        line = null;
                    }
                }

                sr.Close();
                //  nameBus();
                nameBus();

                Console.WriteLine("cargado");
                //prueba2();
            }
            catch (DirectoryNotFoundException dnf)
            {
                LoadDate = new DialogDataAddress(this);

                LoadDate.ErrorDatagram("No se encuentra el archivo datagram");
                if (LoadDate.Estado == false)
                {
                    LoadDate.DialogError();
                    LoadDate.ShowDialog();
                    LoadDate.Estado = true;
                }

            }


            catch (ArgumentException ae)
            {
                LoadDate = new DialogDataAddress(this);

                LoadDate.ErrorDatagram("Archivo equivocado de datagram");
                if (LoadDate.Estado == false)
                {
                    LoadDate.DialogError();
                    LoadDate.ShowDialog();
                    LoadDate.Estado = true;
                }
            }
            catch (IndexOutOfRangeException ae)
            {
                LoadDate.ErrorStop("Archivo equivocado de datagram");
                if (LoadDate.Estado == false)
                {
                    LoadDate.DialogError();
                    LoadDate.ShowDialog();
                    LoadDate.Estado = true;
                }
            }
        }

     
        //Crea los buses
        public void createBus()
        {
            try { 
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
            catch (DirectoryNotFoundException dnf)
            {
                LoadDate = new DialogDataAddress(this);

                LoadDate.ErrorBus("No se encontro el archivo de buses");
                if (LoadDate.Estado == false)
                {
                    LoadDate.DialogError();
                    LoadDate.ShowDialog();
                    LoadDate.Estado = true;
                }

            }


            catch (ArgumentException ae)
            {
                LoadDate = new DialogDataAddress(this);

                LoadDate.ErrorBus("Se esta cargando el archivo equivocado de buses");
                if (LoadDate.Estado == false)
                {
                    LoadDate.DialogError();
                    LoadDate.ShowDialog();
                    LoadDate.Estado = true;
                }
            }
            catch (IndexOutOfRangeException ae)
            {
                LoadDate.ErrorStop("Se esta cargando el archivo equivocado de buses");
                if (LoadDate.Estado == false)
                {
                    LoadDate.DialogError();
                    LoadDate.ShowDialog();
                    LoadDate.Estado = true;
                }
            }
        }


        //Lee el archivo donde estan los nombres y rutas de los buses
        public void nameBus()
        {
            try { 
            ICollection buses = bus1.Keys;
            StreamReader lector = new StreamReader(RELATIVE_PATH_LINES);
          //  Hashtable name = new Hashtable();
            String line = lector.ReadLine();

                line = lector.ReadLine();
                while (line != null)
                {
                String[] l = line.Split(',');
                if (!Routes.ContainsKey(l[0]))
                {
                  //  Console.WriteLine("agrega " + l[0]+"    "+ l[2]+ "   "+   l[3]);

                    Routes.Add(l[0], new Bus(l[0], l[2], l[3]));
                }
                line = lector.ReadLine();

            }
            relationBus();
            }
            catch (DirectoryNotFoundException dnf)
            {
                LoadDate = new DialogDataAddress(this);

                LoadDate.ErrorLine("No se encontro el archivo de lines");
                if (LoadDate.Estado == false)
                {
                    LoadDate.DialogError();
                    LoadDate.ShowDialog();
                    LoadDate.Estado = true;
                }

            }


            catch (ArgumentException ae)
            {
                LoadDate = new DialogDataAddress(this);

                LoadDate.ErrorLine("Se esta cargando el archivo equivocado de lines");
                if (LoadDate.Estado == false)
                {
                    LoadDate.DialogError();
                    LoadDate.ShowDialog();
                    LoadDate.Estado = true;
                }
            }
            catch (IndexOutOfRangeException ae)
            {
                LoadDate.ErrorStop("Se esta cargando el archivo equivocado de lines");
                if (LoadDate.Estado == false)
                {
                    LoadDate.DialogError();
                    LoadDate.ShowDialog();
                    LoadDate.Estado = true;
                }
            }
        }

        //Le asigna a cada bus la ruta correspondiente 
        public void relationBus()
        {
            ICollection buses = bus1.Keys;
            foreach (String bus in buses)
            {
                Bus busOrignal = ((Bus)bus1[bus]);
                if (busOrignal.IdLine!=null) {
                //    Console.WriteLine(busOrignal.IdLine);
                    Bus busNombre = ((Bus)Routes[busOrignal.IdLine]);

                    if (Routes.ContainsKey(busOrignal.IdLine))
                    {
                        //((Bus)bus1[bus]).IdLine = name.(((Bus)bus1[bus]).IdLine);
                        busOrignal.ShortName = busNombre.ShortName;
                        busOrignal.LongName = busNombre.LongName;
                    }
                }
            }
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
        public void selectLines(String lineFiles)
        {
            RELATIVE_PATH_LINES = lineFiles;
        }


        public Hashtable Stops { get => stops; set => stops = value; }
        public Hashtable Stations { get => stations; set => stations = value; }
        public Hashtable Bus1 { get => bus1; set => bus1 = value; }
        public GenericTime RealTime { get => realTime; set => realTime = value; }
        public string RELATIVE_PATH_STOPS { get => rELATIVE_PATH_STOPS; set => rELATIVE_PATH_STOPS = value; }
        public string RELATIVE_PATH_BUS { get => rELATIVE_PATH_BUS; set => rELATIVE_PATH_BUS = value; }
        public string RELATIVE_PATH_DATAGRAM { get => rELATIVE_PATH_DATAGRAM; set => rELATIVE_PATH_DATAGRAM = value; }
        public string RELATIVE_PATH_LINES { get => rELATIVE_PATH_LINES; set => rELATIVE_PATH_LINES = value; }
        public Hashtable Routes { get => routes; set => routes = value; }
    }


}
