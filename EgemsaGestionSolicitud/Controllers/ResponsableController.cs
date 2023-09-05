using DAL.DTO;
using DAL.Repositorio;
using EgemsaGestionSolicitud.Utilidad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EgemsaGestionSolicitud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsableController : ControllerBase
    {
        private readonly IResponsableRepositorio _repositorio;

        public ResponsableController(IResponsableRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        [Route("porArea/{id:int}")]
        public async Task<IActionResult> ObtenerPorArea(int id)
        {
            var rsp = new Resp<List<ResponsableDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _repositorio.ObtenerPorAreaID(id);
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
