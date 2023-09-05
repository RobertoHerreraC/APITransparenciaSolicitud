using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entidades
{
    public class PersonaNatural
    {
        public int? PersonaNaturalId { get; set; }
        public string? Nombres { get; set; } = null!;
        public string? ApellidoPaterno { get; set; } = null!;
        public string? ApellidoMaterno { get; set; } = null!;
        public string? NroDocumento { get; set; } = null!;
        public string? TipoDocumento { get; set; } = null!;
    }
}
