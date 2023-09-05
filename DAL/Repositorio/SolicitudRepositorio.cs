using DAL.Entidades;

using DAL.Configuracion;
using System.Data;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using DAL.DTO;

namespace DAL.Repositorio
{
    public class SolicitudRepositorio : ISolicitudRepositorio
    {
        private readonly Conexion   _conexion;

        public SolicitudRepositorio(IOptions<Conexion> conexion)
        {
            _conexion = conexion.Value;
        }

        public async Task<SolicitudAltaDTO> Crear(SolicitudAltaDTO modelo)
        {
            //var solicitudAlta = new SolicitudAltaDTO();
            //int id = 0;
            try
            {
                using (var con = new SqlConnection(_conexion.SQLString))
                {
                    await con.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("CrearSolicitud", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Ruc", modelo.PersonaJuridica?.Ruc ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@RazonSocial", modelo.PersonaJuridica?.RazonSocial ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Nombres", modelo.PersonaNatural?.Nombres ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@ApellidoPaterno", modelo.PersonaNatural?.ApellidoPaterno ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@ApellidoMaterno", modelo.PersonaNatural?.ApellidoMaterno ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@NroDocumento", modelo.PersonaNatural?.NroDocumento ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@TipoDocumento", modelo.PersonaNatural?.TipoDocumento ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@FraiID", modelo.FraiID);
                        cmd.Parameters.AddWithValue("@MpvID", modelo.MpvID);
                        cmd.Parameters.AddWithValue("@ResponsableClasificacionID", modelo.ResponsableClasificacionID);
                        cmd.Parameters.AddWithValue("@Correo", modelo.Correo);
                        cmd.Parameters.AddWithValue("@Telefono", modelo.Telefono);
                        cmd.Parameters.AddWithValue("@InformacionSolicitada", modelo.InformacionSolicitada);
                        cmd.Parameters.AddWithValue("@FormaEntregaID", modelo.FormaEntregaID);
                        cmd.Parameters.AddWithValue("@Direccion", modelo.Direccion);
                        cmd.Parameters.AddWithValue("@Departamento", modelo.Departamento);
                        cmd.Parameters.AddWithValue("@Provincia", modelo.Provincia);
                        cmd.Parameters.AddWithValue("@Distrito", modelo.Distrito);
                        cmd.Parameters.AddWithValue("@PlazoMaximo", modelo.PlazoMaximo);
                        cmd.Parameters.AddWithValue("@Prorroga", modelo.Prorroga);


                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                modelo.SolicitudId = reader.GetInt32(reader.GetOrdinal("SolicitudId"));
                            }
                        }

                    }
                }
            }
            catch (SqlException ex)
            {
                // Manejar la excepción SQL aquí
                throw new Exception("Error al obtener responsables por solicitud" + ex.Message, ex);
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones aquí
                throw new Exception("Error general al obtener responsables por solicitud", ex);
            }

            return modelo;
        }

        public async Task<List<SolicitudLista>> Obtener()
        {
            
            try
            {
                using (var con = new SqlConnection(_conexion.SQLString))
                {
                    await con.OpenAsync();
                    using (var cmd = new SqlCommand("ObtenerSolicitudes", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var ListaSolicitudes = new List<SolicitudLista>();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                ListaSolicitudes.Add(new SolicitudLista
                                {
                                    SolicitudId = Convert.ToInt32(reader["SolicitudID"])
                                });
                            }
                        }

                        return ListaSolicitudes;
                    }
                }
            }
            catch
            {
                throw;
            }
            

        }

        public Task<DatosSolicitud> ObtenerDatosAlta()
        {
            throw new NotImplementedException();
        }
    }
}
