using ApiClientLibrary.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace ApiClientLibrary.Services
{
    public class F2_PreparacionFabricacion
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _basePath = "F2_PreparacionFabricacion/";
        public F2_PreparacionFabricacion()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _configuration = builder.Build();

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri($"{_configuration["ApiSettings:BaseUrl"]}{_basePath}")
            };

            var token = _configuration["ApiSettings:Token"];
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }
        }
        private async Task<HttpResponseMessage> PostAsync<T>(string url, T dto)
        {
            var json = JsonSerializer.Serialize(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            return response;
        }

        #region ContratoCFE
        public async Task<HttpResponseMessage> RegistrarContratoCFE()
        {
            var contrato = new ContratoCFEDTO
            {
                Tipo = "ContratoCFE",
                Id = "",
                TipoContrato = "ContratoCFE",
                NoContrato = "87489568",
                Estatus = "ACTIVO",
                DetalleContrato = new List<DetalleContratoDTO>
                    {
                        new DetalleContratoDTO
                        {
                            PartidaContrato = "1",
                            DescripcionAviso = "Transformador",
                            AreaDestinoCFE = "Almacém Bajio",
                            Cantidad = 10,
                            Unidad = "PIEZA",
                            ImporteTotal = 1000
                        }
                    },
                UrlArchivo = "https://www.cfe.mx",
                MD5 = "",
                FechaEntregaCFE = new DateTime(2025, 7, 18)
            };

            HttpResponseMessage response = await PostAsync("Contratos", contrato);
            return response;
        }

        public async Task<HttpResponseMessage> RegistrarContratoCFE_DatosInvalidos()
        {
            var contrato = new ContratoCFEDTO
            {
                Tipo = "CFE",
                Id = "",
                TipoContrato = "ContratoCFE",
                NoContrato = "87489568",
                Estatus = "ACTIVO",
                DetalleContrato = new List<DetalleContratoDTO>
                    {
                        new DetalleContratoDTO
                        {
                            PartidaContrato = "1",
                            DescripcionAviso = "Transformador",
                            AreaDestinoCFE = "Almacém Bajio",
                            Cantidad = 10,
                            Unidad = "PIEZA",
                            ImporteTotal = 1000
                        }
                    },
                UrlArchivo = "https://www.cfe.mx",
                MD5 = "",
                FechaEntregaCFE = new DateTime(2025, 7, 18)
            };
            HttpResponseMessage response = await PostAsync("Contratos", contrato);
            return response;
        }

        public async Task<HttpResponseMessage> RegistrarContratoCFE_UrlArchivo_Invalida()
        {
            var contrato = new ContratoCFEDTO
            {
                Tipo = "ContratoCFE",
                Id = "",
                TipoContrato = "ContratoCFE",
                NoContrato = "87489568",
                Estatus = "ACTIVO",
                DetalleContrato = new List<DetalleContratoDTO>
                    {
                        new DetalleContratoDTO
                        {
                            PartidaContrato = "1",
                            DescripcionAviso = "Transformador",
                            AreaDestinoCFE = "Almacém Bajio",
                            Cantidad = 10,
                            Unidad = "PIEZA",
                            ImporteTotal = 1000
                        }
                    },
                UrlArchivo = "C:/Mis documentos",
                MD5 = "",
                FechaEntregaCFE = new DateTime(2025, 7, 18)
            };
            HttpResponseMessage response = await PostAsync("Contratos", contrato);
            return response;
        }
        public async Task<HttpResponseMessage> RegistrarContratoCFEConGarantia()
        {
            var contrato = new ContratoCFEConGarantiaDTO
            {
                Tipo = "ContratoCFEConGarantia",
                Id = "",
                TipoContrato = "ContratoCFEConGarantia",
                NoContrato = "6875686",
                Estatus = "ACTIVO",
                DetalleContrato = new List<DetalleContratoDTO>
                    {
                        new DetalleContratoDTO
                        {
                            PartidaContrato = "1",
                            DescripcionAviso = "Transformador",
                            AreaDestinoCFE = "CFE",
                            Cantidad = 200,
                            Unidad = "PIEZA",
                            ImporteTotal = 2000
                        }
                    },
                PerdidasGarantizadasVacio = 2131.90m,
                PerdidasGarantizadasCarga = 23.90m,
                UrlArchivo = "https://www.cfe.mx",
                MD5 = "",
                FechaEntregaCFE = new DateTime(2025, 5, 15)
            };

            HttpResponseMessage response = await PostAsync("Contratos", contrato);
            return response;
        }

        public async Task<HttpResponseMessage> RegistrarContratoCFEConGarantia_DatosInvalidos()
        {
            var contrato = new ContratoCFEConGarantiaDTO
            {
                Tipo = "CFEConGarantia",
                Id = "",
                TipoContrato = "ContratoCFEConGarantia",
                NoContrato = "6875686",
                Estatus = "ACTIVO",
                DetalleContrato = new List<DetalleContratoDTO>(),
                PerdidasGarantizadasVacio = 2131.90m,
                PerdidasGarantizadasCarga = 23.90m,
                UrlArchivo = "https://www.cfe.mx",
                MD5 = "",
                FechaEntregaCFE = new DateTime(2025, 9,24)
            };

            HttpResponseMessage response = await PostAsync("Contratos", contrato);
            return response;
        }

    }
    #endregion

}
