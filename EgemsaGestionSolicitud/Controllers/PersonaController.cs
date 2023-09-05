using DAL.Entidades;
using DAL.Repositorio;
using EgemsaGestionSolicitud.Utilidad;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EgemsaGestionSolicitud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaAPIRepositorio _repositorio;

        public PersonaController(IPersonaAPIRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet("reniec")]
        public async Task<IActionResult> reniec(string dni)
        {
            var rsp = new Resp<PersonaNaturalAPI>();
            try
            {
                rsp.status = true;
                rsp.value = await _repositorio.validarDni(dni);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }

            return Ok(rsp);
        }

        [HttpGet("sunat")]
        public async Task<IActionResult> sunat(string ruc)
        {
            var rsp = new Resp<PersonaJuridicaAPI>();
            try
            {
                rsp.status = true;
                rsp.value = await _repositorio.validarRuc(ruc);
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
