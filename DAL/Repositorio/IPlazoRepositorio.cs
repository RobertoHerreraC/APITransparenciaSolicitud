using DAL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorio
{
    public interface IPlazoRepositorio
    {
        Task<Plazo> ObtenerPlazo();
    }
}
