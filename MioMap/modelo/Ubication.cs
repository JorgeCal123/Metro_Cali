using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelo
{
    public class Ubication
    {
        string latitud;
        string longitud;

        public Ubication(string latitud, string longitud)
        {
            this.Latitud = latitud;
            this.Longitud = longitud;
        }

        public string Latitud { get => latitud; set => latitud = value; }
        public string Longitud { get => longitud; set => longitud = value; }
       
    }
}
