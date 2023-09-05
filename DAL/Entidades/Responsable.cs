using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entidades
{
    public class Responsable
    {
        public string? ResponsableID { get; set; }
        public string? Nombres { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string? AreaID { get; set; }
        public string? Nombre { get; set; } //area
        public string? Correo { get; set; }
        public int? Estado { get; set; } //responsable
    }
}
