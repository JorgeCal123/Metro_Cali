using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelo
{
    public class Ubication
    {
        public const string ZONE_NORTH = "Zona Norte";
        public const string ZONE_WEST = "Zona Este";
        public const string ZONE_EAST = "Zona Oeste";
        public const string ZONE_SOUTH = "Zona Sur";

        string latitud;
        string longitud;

        GenericTime time;
     //   Ubication actual;

        public Ubication(string latitud, string longitud)
        {
            this.Latitud = latitud;
            this.Longitud = longitud;
        }
      
        public string Latitud { get => latitud; set => latitud = value; }
        public string Longitud { get => longitud; set => longitud = value; }
        public GenericTime Time { get => time; set => time = value; }
    }
}
