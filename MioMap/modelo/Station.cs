using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelo
{
    public class Station
    {
        private String stationId;
        private Ubication ubi;
       private String planVersionId;
        private string shortName;
        private string longName; 

        private Hashtable stops;

     

        public Station(string stationId, string planVersionId, string shortName, string longName, Ubication ubi)
        {
            this.stationId = stationId;
            this.PlanVersionId = planVersionId;
            this.ShortName = shortName;
            this.LongName = longName;
            this.ubi = ubi;
            stops = new Hashtable();

        }

        public void addStop(String key,Stop newStop)
        {

            if (!Stops.ContainsKey(key))
                {
          //      Console.WriteLine(LongName+"+++++ se agrega la parada"+ newStop.ShortName+ " LLAVE "+key);
                Stops.Add(key, newStop);
            }
            else
            {
           //     Console.WriteLine(LongName + "----- NO se agrega la parada" + newStop.ShortName);

            }


        }

        public String StationId { get => stationId; set => stationId = value; }
        public Hashtable Stops { get => stops; set => stops = value; }
        public Ubication Ubi { get => ubi; set => ubi = value; }
        public string PlanVersionId { get => planVersionId; set => planVersionId = value; }
        public string ShortName { get => shortName; set => shortName = value; }
        public string LongName { get => longName; set => longName = value; }
    }
}
