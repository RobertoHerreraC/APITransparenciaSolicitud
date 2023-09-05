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
using DAL.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DAL.Repositorio
{
    public class ResponsableRepositorio : IResponsableRepositorio
    {
        private readonly Conexion _conexion;

        public ResponsableRepositorio(IOptions<Conexion> conexion)
        {
            _conexion = conexion.Value;
        }

        public async Task<List<ResponsableDTO>> ObtenerPorAreaID(int id)
        {
            try
            {
                using (var con = new SqlConnection(_conexion.SQLString))
                {
                    await con.OpenAsync();
                    using (var cmd = new SqlCommand("ObtenerResponsablesPorAreaID", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@AreaID", SqlDbType.Int) { Value = id });

                        var responsables = new List<ResponsableDTO>();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                responsables.Add(new ResponsableDTO
                                {
                                    ResponsableID = reader["ResponsableID"].ToString(),
                                    Responsable = new PersonaResponsableDTO {
                                        Nombres = reader["Nombres"].ToString(),
                                        ApellidoPaterno = reader["ApellidoPaterno"].ToString(),
                                        ApellidoMaterno = reader["ApellidoMaterno"].ToString(),
                                    },
                                    Area = new AreaDTO{
                                        AreaID = reader["AreaID"].ToString(),
                                        Nombre = reader["NombreArea"].ToString()
                                    },

                                    Correo = reader["Correo"].ToString(),
                                    Estado = Convert.ToBoolean(reader["Estado"]) == true ? 1  : 0
                                });;
                            }
                        }

                        return responsables;
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
