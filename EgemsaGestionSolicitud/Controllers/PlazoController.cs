using DAL.Entidades;
using DAL.Repositorio;
using EgemsaGestionSolicitud.Utilidad;
using Microsoft.AspNetCore.Mvc;

namespace EgemsaGestionSolicitud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlazoController : Controller
    {
        private readonly IPlazoRepositorio _repositorio;

        public PlazoController(IPlazoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        [Route("Obtener")]
        public async Task<IActionResult> Obtener()
        {
            var rsp = new Resp<Plazo>();

            try
            {
                rsp.status = true;
                rsp.value = await _repositorio.ObtenerPlazo();
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
