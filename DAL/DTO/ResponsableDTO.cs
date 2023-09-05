using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class ResponsableDTO
    {
        public string? ResponsableID { get; set; }
        public PersonaResponsableDTO? Responsable { get; set; }

        public AreaDTO? Area { get; set; }
        public string? Correo { get; set; }
        public int? Estado { get; set; }
    }
}
