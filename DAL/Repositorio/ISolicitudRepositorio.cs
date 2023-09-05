using DAL.DTO;
using DAL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorio
{
    public interface ISolicitudRepositorio
    {
        Task<DatosSolicitud> ObtenerDatosAlta();

        Task<List<SolicitudLista>> Obtener();

        Task<SolicitudAltaDTO> Crear(SolicitudAltaDTO modelo);
    }
}
