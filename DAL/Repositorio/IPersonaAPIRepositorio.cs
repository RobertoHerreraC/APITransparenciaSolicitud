using DAL.DTO;
using DAL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorio
{
    public interface IPersonaAPIRepositorio
    {
        Task<PersonaNaturalAPI> validarDni(string numDocumento);
        Task<PersonaJuridicaAPI> validarRuc(string numRuc);
    }
}
