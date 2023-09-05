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
    public class CatalogoFormaEntregaController : ControllerBase
    {
        private readonly IFormaEntregaRepositorio _repositorio;

        public CatalogoFormaEntregaController(IFormaEntregaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> lista()
        {
            var rsp = new Resp<List<CatalogoFormaEntrega>>();

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
    }
}
