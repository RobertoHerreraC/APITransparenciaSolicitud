using DAL.Configuracion;
using DAL.DTO;
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
    public class FormaEntregaRepositorio : IFormaEntregaRepositorio
    {
        private readonly Conexion _conexion;

        public FormaEntregaRepositorio(IOptions<Conexion> conexion)
        {
            _conexion = conexion.Value;
        }

        public async Task<List<CatalogoFormaEntrega>> Obtener()
        {
            try
            {
                using (var con = new SqlConnection(_conexion.SQLString))
                {
                    await con.OpenAsync();
                    using (var cmd = new SqlCommand("ObtenerFormaEntrega", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        var formasEntrega = new List<CatalogoFormaEntrega>();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                formasEntrega.Add(new CatalogoFormaEntrega
                                {
                                    FormaEntregaID = Convert.ToInt32(reader["FormaEntregaID"]),
                                    Descripcion = reader["Descripcion"].ToString(),
                                    GeneraCosto = Convert.ToInt32(reader["GeneraCosto"]),
                                    Estado = Convert.ToInt32(reader["Estado"]),
                                    
                                });
                            }
                        }

                        return formasEntrega;
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
