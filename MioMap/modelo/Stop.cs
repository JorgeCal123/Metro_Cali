using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelo
{
    public class Stop
    {
        private String stopId;
        private String planVersionId;
        private string shortName;
        private string longName;
        private string gps_X;
        private string gps_Y;

        public Stop(String stopId, String planVersionId, string shortName, string longName, string gps_X, string gps_Y)
        {
            this.stopId = stopId;
            this.planVersionId = planVersionId;
            this.shortName = shortName;
            this.longName = longName;
            this.gps_X = gps_X;
            this.gps_Y = gps_Y;
        }

        public String StopId { get => stopId; set => stopId = value; }
        public String PlanVersionId { get => planVersionId; set => planVersionId = value; }
        public string ShortName { get => shortName; set => shortName = value; }
        public string LongName { get => longName; set => longName = value; }
        public string Gps_X { get => gps_X; set => gps_X = value; }
        public string Gps_Y { get => gps_Y; set => gps_Y = value; }
    }
}
