using DAL.Configuracion;
using DAL.DTO;
using DAL.Entidades;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorio
{
    public class PersonaAPIRepositorio : IPersonaAPIRepositorio
    {
        private static string? _token;
        private static string _baseurl;
        private static string? _usuario;
        private static string? _clave;
        private readonly IConfiguration _configuration;

        public PersonaAPIRepositorio(IConfiguration configuracion)
        {
            _configuration = configuracion;
            _usuario = _configuration.GetSection("ApiSettings:usuario").Value;
            _clave = _configuration.GetSection("ApiSettings:clave").Value;
            _baseurl = _configuration.GetSection("ApiSettings:baseUrl").Value!;
            _token = "apis-token-5330.BLa3uNGI6hj1FptQn112sQ2wWV73Y0Y-";
        }

        public async Task Autenticar()
        {
            _token = "apis-token-5330.BLa3uNGI6hj1FptQn112sQ2wWV73Y0Y-";
        }

        public async Task<PersonaNaturalAPI> validarDni(string numDocumento)
        {
            PersonaNaturalAPI persona = new PersonaNaturalAPI();

            //await Autenticar();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var response = await cliente.GetAsync($"reniec/dni?numero={numDocumento}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<PersonaNaturalAPI>(json_respuesta);
                persona.nombres = resultado!.nombres;
                persona.apellidoPaterno = resultado.apellidoPaterno;
                persona.apellidoMaterno = resultado.apellidoMaterno;
                persona.numeroDocumento = resultado.numeroDocumento;
            }
            return persona;
        }

        public async Task<PersonaJuridicaAPI> validarRuc(string numRuc)
        {
            PersonaJuridicaAPI persona = new PersonaJuridicaAPI();

            //await Autenticar();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var response = await cliente.GetAsync($"sunat/ruc?numero={numRuc}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<PersonaJuridicaAPI>(json_respuesta);
                persona.razonSocial = resultado!.razonSocial;
            }
            return persona;
        }
    }
}
