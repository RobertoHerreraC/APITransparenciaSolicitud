using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entidades
{
    public class PersonaJuridica
    {
        public int? PersonaJuridicaId { get; set; }
        public string? Ruc { get; set; } = null!;
        public string? RazonSocial { get; set; } = null!;
    }
}
