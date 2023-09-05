using DAL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class SolicitudAltaDTO
    {
        public int? SolicitudId { get; set; }
        public PersonaJuridica? PersonaJuridica { get; set; }
        public PersonaNatural? PersonaNatural { get; set; }
        public int? FraiID { get; set; }
        public int? MpvID { get; set; }
        public int? ResponsableClasificacionID { get; set; }
        public string Correo { get; set; } = null!;
        public string Telefono { get; set; }
        public string InformacionSolicitada { get; set; }
        public int FormaEntregaID { get; set; }
        public string Direccion { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
        public int PlazoMaximo { get; set; }
        public int Prorroga { get; set; }

    }
}
