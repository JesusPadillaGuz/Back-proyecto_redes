using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Clima.Entities
{
    public class Consulta
    { 
        [Key]
        public int id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string Locacion { get; set; }
        public double Temperatura { get; set; }
        public double Sensacion_termica { get; set; }
        public double Humedad { get; set; }



    }
}
