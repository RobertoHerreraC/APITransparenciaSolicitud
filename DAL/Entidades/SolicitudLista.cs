using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entidades
{
    public class SolicitudLista
    {
        public int? SolicitudId { get; set; }
        public PersonaJuridica? PersonaJuridica { get; set; }
        public PersonaNatural? PersonaNatural { get; set; }
        public CatalogoFormaEntrega? FormaEntrega { get; set; }
        public string? Correo { get; set; } = null!;
        public string? Telefono { get; set; }
        public string? CodigoSigedd { get; set; }
        public string? CostoTotal { get; set; }
        public string? FechaPresentacion { get; set; }
        public string? FechaVencimiento { get; set; }
        public string? FechaVencimientoProrroga { get; set; }
        public int? Activo { get; set; }
        public string? PlazoMaximo { get; set; }
        public string? Prorroga { get; set; }
        public string? Observacion { get; set; }
        public string? EstadoDescripcion { get; set; }
    }
}
