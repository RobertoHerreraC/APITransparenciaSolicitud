using DAL.Configuracion;
using DAL.Entidades;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorio
{
    public class PlazoRepositorio : IPlazoRepositorio
    {
        private readonly Conexion _conexion;

        public PlazoRepositorio(IOptions<Conexion> conexion)
        {
            _conexion = conexion.Value;
        }

        public async Task<Plazo> ObtenerPlazo()
        {
            try
            {
                using (var con = new SqlConnection(_conexion.SQLString))
                {
                    await con.OpenAsync();
                    using (var cmd = new SqlCommand("ObtenerPlazoUnico", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        var plazoUnico = new Plazo();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                plazoUnico = new Plazo
                                {
                                    PlazoID = Convert.ToInt32(reader["PlazoID"]),
                                    DiasPlazoMaximo = Convert.ToInt32(reader["DiasPlazoMaximo"]),
                                    DiasProrroga = Convert.ToInt32(reader["DiasProrroga"]),
                                    Estado = Convert.ToInt32(reader["Estado"]),

                                };
                            }
                        }

                        return plazoUnico;
                    }
                }
            }
            catch (SqlException ex)
            {
                // Manejar la excepción SQL aquí
                throw new Exception("Error al obtener responsables por AreaID", ex);
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones aquí
                throw new Exception("Error general al obtener responsables por AreaID", ex);
            }
        }
    }
}
