using ApiClientLibrary.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
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
        private async Task<HttpResponseMessage> PutAsJsonAsync<T>(string url, T dto)
        {
            var json = JsonSerializer.Serialize(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsJsonAsync(url, dto);
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
                            AreaDestinoCFE = "Almacén Bajio",
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
                            AreaDestinoCFE = "Almacén Bajio",
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
                            AreaDestinoCFE = "Almacén Bajio",
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
        public async Task<HttpResponseMessage> ActualizarContratoCFE() {
            var contrato = new ContratoCFEDTO
            {
                Tipo = "ContratoCFE",
                Id = "68b06f8e5227cb49c87cc22d",
                TipoContrato = "ContratoCFE",
                NoContrato = "PK897854",
                Estatus = "ACTIVO",
                DetalleContrato = new List<DetalleContratoDTO>
                    {
                        new DetalleContratoDTO
                        {
                            PartidaContrato = "7",
                            DescripcionAviso = "Transformador pedestal",
                            AreaDestinoCFE = "Almacén CFE",
                            Cantidad = 5,
                            Unidad = "PIEZA",
                            ImporteTotal = 5000
                        }
                    },
                UrlArchivo = "https://www.cfe.mx",
                MD5 = "",
                FechaEntregaCFE = new DateTime(2025, 7, 19)
            };

            HttpResponseMessage response = await PutAsJsonAsync("Contratos", contrato);
            return response;
        }
        public async Task<HttpResponseMessage> ActualizarContratoCFE_DatosInvalidos() {
            var contrato = new ContratoCFEDTO
            {
                Tipo = "ContratoCFE",
                Id = "",
                TipoContrato = "ContratoCFE",
                NoContrato = "87489568",
                Estatus = "ACTIVO",
                DetalleContrato = new List<DetalleContratoDTO>(),
                UrlArchivo = "https://www.cfe.mx",
                MD5 = "",
                FechaEntregaCFE = new DateTime(2025, 7, 18)
            };

            HttpResponseMessage response = await PutAsJsonAsync("Contratos", contrato);
            return response;
        }
        public async Task<HttpResponseMessage> ActualizarContratoCFEConGarantia() {
        var contrato = new ContratoCFEConGarantiaDTO
            {
                Tipo = "ContratoCFEConGarantia",
                Id = "68b09c1f9029cd6eb03cc919",
                TipoContrato = "ContratoCFEConGarantia",
                NoContrato = "255892568",
                Estatus = "ACTIVO",
                DetalleContrato = new List<DetalleContratoDTO>
                {
                    new DetalleContratoDTO
                    {
                        PartidaContrato = "7",
                        DescripcionAviso = "Transformador tipo pedestal",
                        AreaDestinoCFE = "Almacén CFE",
                        Cantidad = 50,
                        Unidad = "PIEZA",
                        ImporteTotal = 4500
                    }
                },
                PerdidasGarantizadasVacio = 2131.90m,
                PerdidasGarantizadasCarga = 23.90m,
                UrlArchivo = "https://www.cfe.mx",
                MD5 = "",
                FechaEntregaCFE = new DateTime(2025, 5, 25)
            };

            HttpResponseMessage response = await PutAsJsonAsync("Contratos", contrato);
            return response;

        }
        public async Task<HttpResponseMessage> ActualizarContratoCFEConGarantia_DatosInvalidos() {
            var contrato = new ContratoCFEConGarantiaDTO
            {
                Tipo = "ContratoCFEConGarantia",
                Id = "",
                TipoContrato = "ContratoCFEConGarantia",
                NoContrato = "6875686",
                Estatus = "ACTIVO",
                DetalleContrato = new List<DetalleContratoDTO>(),
                PerdidasGarantizadasVacio = 2131.90m,
                PerdidasGarantizadasCarga = 23.90m,
                UrlArchivo = "https://www.cfe.mx",
                MD5 = "",
                FechaEntregaCFE = new DateTime(2025, 5, 15)
            };

            HttpResponseMessage response = await PutAsJsonAsync("Contratos", contrato);
            return response;
        }
        public async Task<HttpResponseMessage> RegistrarContratoParticular()
        {
            var contrato = new ContratoParticularDTO
            {
                Tipo = "ContratoParticular",
                Id = "",
                TipoContrato = "ContratoParticular",
                NoContrato = "STOCK",
                Estatus = "ACTIVO",
                DetalleContrato = new List<PartidaContratoParticularDTO>
                    {
                        new PartidaContratoParticularDTO
                        {
                            PartidaContrato = "1",
                            DescripcionAviso = "Transformador",
                            Cantidad = 200,
                            Unidad = "PIEZA",
                            ImporteTotal = 2000
                        }
                    }
            };

            var json = JsonSerializer.Serialize(contrato);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("Contratos", content);

            return response;
        }
        public async Task<HttpResponseMessage> RegistrarContratoParticular_UrlArchivo_Invalida()
        {
            throw new NotImplementedException("Este método aún no está implementado.");
        }
        public async Task<HttpResponseMessage> RegistrarContratoParticular_DatosInvalidos() {
            throw new NotImplementedException("Este método aún no está implementado.");
        }
        public async Task<HttpResponseMessage> ActualizarContratoParticular()
        {
            throw new NotImplementedException("Este método aún no está implementado.");
        }
        public async Task<HttpResponseMessage> ActualizarContratoParticular_DatosInvalidos()
        {
            throw new NotImplementedException("Este método aún no está implementado.");
        }
        
        public async Task<HttpResponseMessage> ObtenerContratos(int pageNumber, int pageSize) 
        { 
            var url = $"Contratos?pageNumber={pageNumber}&pageSize={pageSize}";
            var response = await _httpClient.GetAsync(url);
            return response;
        }
    }
    #endregion

}
