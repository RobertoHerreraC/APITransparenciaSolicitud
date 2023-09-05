using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entidades
{
    public class Plazo
    {
        public int? PlazoID { get; set; }
        public int? DiasPlazoMaximo { get; set; }
        public int? DiasProrroga { get; set; }
        public int? Estado { get; set; }
    }
}
