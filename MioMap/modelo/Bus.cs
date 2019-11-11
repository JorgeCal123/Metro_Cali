using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading;

namespace modelo
{
    public class Bus
    {
        private String busId;
        private Hashtable ubicationTime;
        private String numberPlate;
        private Boolean visit;
        private String  uBus;
        private String idLine;
        private String shortName;
        private String longName;
        private int inactivo;

        public Bus(string busId, String numberPlate)
        {
            Inactivo = 0;

            this.BusId = busId;
            this.NumberPlate = numberPlate;

            UbicationTime = new Hashtable();

        }

        public Bus(string idLine, string shortName, string longName)
        {
            this.idLine = idLine;
            this.shortName = shortName;
            this.longName = longName;
        }



        public void addTime(String posX, String posY, String time)
        {

            String[] date = time.Split(' ');
            String[] hour = date[1].Split('.');
            String[] date2 = date[0].Split('-');

            String key = Int32.Parse(date2[0]) + "-" + date2[1] + "-" + Int32.Parse(date2[2]) + " " + Int32.Parse(hour[0]) + "." + Int32.Parse(hour[1]) + "." + Int32.Parse(hour[2]) + " " + date[2];

            if (!UbicationTime.ContainsKey(key))
            { 
                Ubication nuevou = new Ubication(posX, posY);
                //   Int32.Parse(date2[2]) Int32.Parse(date2[0]), Int32.Parse(date2[1]), Int32.Parse(date2[2]), Int32.Parse(hour[0]), Int32.Parse(hour[1]), Int32.Parse(hour[2]), date[2]
                GenericTime time2 = new GenericTime(Int32.Parse(date2[2]), Int32.Parse(date2[0]),(date2[1]), Int32.Parse(hour[0]), Int32.Parse(hour[1]), Int32.Parse(hour[2]), date[2]);
                nuevou.Time = time2;
                UbicationTime.Add(key, nuevou);
                //Next(key, nuevou);
            }
        }

       public void inactividad()
        {
            Inactivo += 1;
        }
        public void activo()
        {
            Inactivo = 0;
        }


        public string BusId { get => busId; set => busId = value; }
        public Hashtable UbicationTime { get => ubicationTime; set => ubicationTime = value; }
        public string NumberPlate { get => numberPlate; set => numberPlate = value; }
        public bool Visit { get => visit; set => visit = value; }
        public string UBus { get => uBus; set => uBus = value; }
        public string IdLine { get => idLine; set => idLine = value; }
        public string ShortName { get => shortName; set => shortName = value; }
        public string LongName { get => longName; set => longName = value; }
        public int Inactivo { get => inactivo; set => inactivo = value; }
    }
}
