using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelo
{
    class Station
    {
        private int stationId;
        private Stop[] stops;
        private double gps_X;
        private double gps_Y;

        public Station(int stationId, Stop[] stops, double gps_X, double gps_Y)
        {
            this.stationId = stationId;
            this.stops = stops;
            this.gps_X = gps_X;
            this.gps_Y = gps_Y;
        }

        public int StationId { get => stationId; set => stationId = value; }
        public Stop[] Stops { get => stops; set => stops = value; }
        public double Gps_X { get => gps_X; set => gps_X = value; }
        public double Gps_Y { get => gps_Y; set => gps_Y = value; }
    }
}
