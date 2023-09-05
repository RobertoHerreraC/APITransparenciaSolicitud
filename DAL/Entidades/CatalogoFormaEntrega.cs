using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entidades
{
    public class CatalogoFormaEntrega
    {
        public int? FormaEntregaID { get; set; }
        public string? Descripcion { get; set; } = null!;
        public int? GeneraCosto { get; set; }
        public int? Estado { get; set; }
    }
}
