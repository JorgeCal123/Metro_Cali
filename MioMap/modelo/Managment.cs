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




        public Managment()
        {
            Stops = new Hashtable();
            Stations = new Hashtable();
            Bus1 = new Hashtable();

            //                                     año  dia mes min hor seg
            RealTime = new GenericTime(18, 01, 11, 35, 5, 25, "AM");

            loadStops();
            createBus();
            timeReading();
         
        }

        public Hashtable Stops { get => stops; set => stops = value; }
        public Hashtable Stations { get => stations; set => stations = value; }
        public Hashtable Bus1 { get => bus1; set => bus1 = value; }
        public GenericTime RealTime { get => realTime; set => realTime = value; }

        private void loadStops()
        {
            //DO NOT PUT CSV IN PROYECT FOLDER, USE ABSOLUTE PATH
            StreamReader reader = new StreamReader(ABSOLUTE_PATH_STOPS);


            string line = reader.ReadLine();

            string las;
            string lons;

            int countInvalidEntries = 0;
            int markers = 0;



            while (line != null && countInvalidEntries < 100)
            {
                string[] datos = line.Split(',');
                las = datos[6];
                las.Replace(',', '.');
                lons = datos[7];
                lons.Replace(',', '.');

                try
                {
                    //  Stop Id,             Plan Version,      Short Name, Long Name,        Gps x,                 Gps Y
                    Stop a = new Stop(int.Parse(datos[0]), int.Parse(datos[1]), datos[2], datos[3], datos[6], datos[7]);
                    if (a.ShortName.Contains("7-ago") || a.ShortName.Contains("ALA") ||
                        a.ShortName.Contains("AMAN") || a.ShortName.Contains("ATG") ||
                        a.ShortName.Contains("CHIM") || a.ShortName.Contains("C.PALOS") ||
                        a.ShortName.Contains("MELEN") || a.ShortName.Contains("ESTAD") ||
                        a.ShortName.Contains("FATI") || a.ShortName.Contains("FLOR") ||
                        a.ShortName.Contains("FRAY") || a.ShortName.Contains("HORMI") ||
                        a.ShortName.Contains("L.AME") || a.ShortName.Contains("LIDO") ||
                        a.ShortName.Contains("MANZA") || a.ShortName.Contains("MZAN") ||
                        a.ShortName.Contains("N.LATIR") || a.ShortName.Contains("PAM") ||
                        a.ShortName.Contains("PTCU") || a.ShortName.Contains("PILO") ||
                        a.ShortName.Contains("CAY") || a.ShortName.Contains("PLATO") ||
                        a.ShortName.Contains("POPU") || a.ShortName.Contains("PRAD") ||
                        a.ShortName.Contains("PRIMI") || a.ShortName.Contains("REFU") ||
                        a.ShortName.Contains("SALO") || a.ShortName.Contains("SAN") ||
                        a.ShortName.Contains("SNT") || a.ShortName.Contains("ST.") ||
                        a.ShortName.Contains("STRO") || a.ShortName.Contains("SUC") ||
                        a.ShortName.Contains("CALS") || a.ShortName.Contains("PCO") ||
                        a.ShortName.Contains("T.C-") || a.ShortName.Contains("TEQU") ||
                        a.ShortName.Contains("A.SAN") || a.ShortName.Contains("TCAL") ||
                        a.ShortName.Contains("TMEN") || a.ShortName.Contains("TOR") ||
                        a.ShortName.Contains("UDP") || a.ShortName.Contains("UNIV") ||
                        a.ShortName.Contains("VERS") || a.ShortName.Contains("CONQ") ||
                        a.ShortName.Contains("CALD") || a.ShortName.Contains("CAP") ||
                        a.ShortName.Contains("CEN") || a.ShortName.Contains("CHAP") ||
                         a.ShortName.Contains("RIO") || a.ShortName.Contains("ERMI") ||
                        a.ShortName.Contains("BELA") || a.ShortName.Contains("BUIT") ||
                        a.ShortName.Contains("TREB") || a.ShortName.Contains("TRON") ||
                        a.ShortName.Contains("VLN") || a.ShortName.Contains("VIC") ||
                        a.ShortName.Contains("VIP"))
                    {
                        if (!Stations.ContainsKey(datos[0]))
                        {
                            Stations.Add(datos[0], a);
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
                catch (Exception)
                {
                    countInvalidEntries++;
                }

                line = reader.ReadLine();
                markers++;
            }
            Console.WriteLine("number of invalid coordenate entries: " + countInvalidEntries);
            reader.Close();


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
             
                if (cont < 10000)
                {
                    //  Console.WriteLine(cont);
                    String lat = dato[4].Insert(1, ",");
                    String lon = dato[5].Insert(3, ",");

                    if (bus1.ContainsKey(dato[11]))
                    {
                   
                Console.WriteLine("******************excepcion " + ((Bus)bus1[dato[11]]).NumberPlate+" llave "+dato[10]);

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

        public void createBus()
        {
            StreamReader lector = new StreamReader(ABSOLUTE_PATH_BUS);
            String line = lector.ReadLine();
            line = lector.ReadLine();
            while (line != null)
            {
                String[] bus = line.Split(',');
        //              Console.WriteLine("lee el bus "+bus[0]);
                if (!bus1.ContainsKey(bus[0]))
                {
                    //     ((Bus)bus1[bus[0]]).NumberPlate = bus[2];
                    if (bus[2].Equals(""))
                    {
                        Bus nuevo = new Bus(bus[0], "Sin placa");
                        bus1.Add(bus[0], nuevo);

                 //           Console.WriteLine(bus[0]+" Sin placa");
                    }
                    else
                    {
                        Bus nuevo = new Bus(bus[0], bus[2]);
                        bus1.Add(bus[0], nuevo);
                   //     Console.WriteLine(bus[0] + " con placa "+ bus[2]);

                    }
                }
                            line = lector.ReadLine();


            }
        }
    }
         

        }
