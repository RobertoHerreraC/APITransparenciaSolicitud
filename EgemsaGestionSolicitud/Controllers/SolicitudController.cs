using DAL.DTO;
using DAL.Entidades;
using DAL.Repositorio;
using EgemsaGestionSolicitud.Utilidad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EgemsaGestionSolicitud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudController : ControllerBase
    {
        private readonly ISolicitudRepositorio _repositorio;

        public SolicitudController(ISolicitudRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        [Route("DatosSolicitud")]
        public async Task<IActionResult> DatosSolicitud()
        {
            var rsp = new Resp<List<SolicitudLista>>();

            try
            {
                rsp.status = true;
                rsp.value = await _repositorio.Obtener();
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }

            return Ok(rsp);
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] SolicitudAltaDTO solicitud)
        {
            var rsp = new Resp<SolicitudAltaDTO>();

            try
            {
                rsp.status = true;
                rsp.value = await _repositorio.Crear(solicitud);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }

            return Ok(rsp);
        }
    }
}
