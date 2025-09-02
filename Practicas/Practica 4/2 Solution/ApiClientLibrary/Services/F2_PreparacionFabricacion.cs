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
                NoContrato = "9100026571",
                Estatus = "ACTIVO",
                DetalleContrato = new List<DetalleContratoDTO>
                    {
                        new DetalleContratoDTO
                        {
                            PartidaContrato = "55",
                            DescripcionAviso = "CABLE CONTROL CU PVC + PVC  8X10  C/B OCHO CONDUCTORES DE COBRE, CALIBRE 10 AWG, FORRADOS DE AISLAMIENTO DE PVC-LS, RPI, 75°C, 600V, CON BLINDAJE DE MALLA TRENZADA DE COBRE, CUBIERTA DE PVC COLOR NEGRO. ESPECIFICACIÓN CFE E0000-20/2005 TOTAL DE TRAMOS: 1081304",
                            AreaDestinoCFE = "JALISCO D144 TLAQUEPAQUE JAL.COL. LAS JUNTAS",
                            Cantidad = 500,
                            Unidad = "Metros",
                            ImporteTotal = 93055.00m
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
                            Unidad = "Pieza",
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
                NoContrato = "9100026571",
                Estatus = "ACTIVO",
                DetalleContrato = new List<DetalleContratoDTO>
                    {
                        new DetalleContratoDTO
                        {
                            PartidaContrato = "55",
                            DescripcionAviso = "CABLE CONTROL CU PVC + PVC  8X10  C/B OCHO CONDUCTORES DE COBRE, CALIBRE 10 AWG, FORRADOS DE AISLAMIENTO DE PVC-LS, RPI, 75°C, 600V, CON BLINDAJE DE MALLA TRENZADA DE COBRE, CUBIERTA DE PVC COLOR NEGRO. ESPECIFICACIÓN CFE E0000-20/2005 TOTAL DE TRAMOS: 1081304",
                            AreaDestinoCFE = "JALISCO D144 TLAQUEPAQUE JAL.COL. LAS JUNTAS",
                            Cantidad = 500,
                            Unidad = "Metros",
                            ImporteTotal = 93055.00m
                        }
                    },
                UrlArchivo = "C:/Mis documentos",
                MD5 = "",
                FechaEntregaCFE = new DateTime(2025, 7, 18)
            };

            HttpResponseMessage response = await PostAsync("Contratos", contrato);
            return response;
        }
        public async Task<HttpResponseMessage> ActualizarContratoCFE()
        {
            var contrato = new ContratoCFEDTO
            {
                Tipo = "ContratoCFE",
                Id = "68b5b4973b7309591c0d829d",
                TipoContrato = "ContratoCFE",
                NoContrato = "9100026571",
                Estatus = "ACTIVO",
                DetalleContrato = new List<DetalleContratoDTO>
                    {
                        new DetalleContratoDTO
                        {
                            PartidaContrato = "55",
                            DescripcionAviso = "CABLE CONTROL CU PVC + PVC  8X10  C/B OCHO CONDUCTORES DE COBRE, CALIBRE 10 AWG, FORRADOS DE AISLAMIENTO DE PVC-LS, RPI, 75°C, 600V, CON BLINDAJE DE MALLA TRENZADA DE COBRE, CUBIERTA DE PVC COLOR NEGRO. ESPECIFICACIÓN CFE E0000-20/2005 TOTAL DE TRAMOS: 1081304",
                            AreaDestinoCFE = "JALISCO D144 TLAQUEPAQUE JAL.COL. LAS JUNTAS",
                            Cantidad = 500,
                            Unidad = "Metros",
                            ImporteTotal = 93055
                        },
                        new DetalleContratoDTO
                        {
                            PartidaContrato = "76",
                            DescripcionAviso = "CABLE CONTROL 6X12 CABLE CONTROL 6X12 NMX-J-300-ANCE 2013/0132.",
                            AreaDestinoCFE = "ALMACÉN DIVISIONAL NOROESTE CARR HERMOSILLO-EL NOVILLO",
                            Cantidad = 800,
                            Unidad = "Metros",
                            ImporteTotal = 77504
                        },
                        new DetalleContratoDTO
                        {
                            PartidaContrato = "85",
                            DescripcionAviso = " CABLE SA-AAC (266.8)-XLP38 CABLE SA-AAC (266.8)-XLP38 CFE E0000-29 2020/09",
                            AreaDestinoCFE = "ALMACÉN DIVISIONAL GOLFO CENTRO CARR TAMPICO-MANTE KM 14 No.S/N, COL| VILLA HERMOSA 89319|TAMPICO",
                            Cantidad = 100,
                            Unidad = "Metros",
                            ImporteTotal = 9689.25m
                        }
                    },
                UrlArchivo = "https://www.cfe.mx",
                MD5 = "",
                FechaEntregaCFE = new DateTime(2025, 7, 18)
            };

            HttpResponseMessage response = await PutAsJsonAsync("Contratos", contrato);
            return response;
        }
        public async Task<HttpResponseMessage> RegistrarContratoCFEConGarantia()
        {
            var contrato = new ContratoCFEConGarantiaDTO
            {
                Tipo = "ContratoCFEConGarantia",
                Id = "",
                TipoContrato = "ContratoCFEConGarantia",
                NoContrato = "9100025605",
                Estatus = "ACTIVO",
                DetalleContrato = new List<DetalleContratoDTO>
                    {
                        new DetalleContratoDTO
                        {
                            PartidaContrato = "34",
                            DescripcionAviso = "TRANSFORMADOR TIPO POSTE D1-15-13200YT/7620-120/240; ACORDE CON LA CFE K1000-01-2016. NUMERO DE CONSTANCIA PROTOTIPO K311P-16-E/7036.",
                            AreaDestinoCFE = "CENTRO SUR",
                            Cantidad = 8,
                            Unidad = "Pieza",
                            ImporteTotal = 165590.32m
                        }
                    },
                PerdidasGarantizadasVacio = 41.90m,
                PerdidasGarantizadasCarga = 63,
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
                Id = "68b5fc963b7309591c0d829e",
                TipoContrato = "ContratoCFEConGarantia",
                NoContrato = "9100025605",
                Estatus = "ACTIVO",
                DetalleContrato = new List<DetalleContratoDTO>
                    {
                        new DetalleContratoDTO
                        {
                            PartidaContrato = "34",
                            DescripcionAviso = "TRANSFORMADOR TIPO POSTE D1-15-13200YT/7620-120/240; ACORDE CON LA CFE K1000-01-2016. NUMERO DE CONSTANCIA PROTOTIPO K311P-16-E/7036.",
                            AreaDestinoCFE = "CENTRO SUR",
                            Cantidad = 8,
                            Unidad = "Pieza",
                            ImporteTotal = 165590.32m
                        },
                        new DetalleContratoDTO
                        {
                            PartidaContrato = "57",
                            DescripcionAviso = "TRANSFORMADOR TIPO POSTEDA1-10-13200-120/240; ACORDE CON LA CFE K1000-01-2016.",
                            AreaDestinoCFE = "SURESTE",
                            Cantidad = 5,
                            Unidad = "Pieza",
                            ImporteTotal = 99999.60m
                        }
                    },
                PerdidasGarantizadasVacio = 42,
                PerdidasGarantizadasCarga = 63,
                UrlArchivo = "https://www.cfe.mx",
                MD5 = "",
                FechaEntregaCFE = new DateTime(2025, 5, 15)
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
        #endregion

        #region ContratoParticular
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
                            PartidaContrato = "307",
                            DescripcionAviso = "CABLE DE POTENCIA MONOPOLAR AL - (1/0) - XLP - 35 - 100 CABLE DE ENERGÍA, UN CONDUCTOR DE ALUMINIO COMPACTO SELLADO, CALIBRE 1/0 AWG, XLP 100",
                            Cantidad = 15480,
                            Unidad = "Metros",
                            ImporteTotal = 1120860.51m
                        }
                    }
            };
            HttpResponseMessage response = await PostAsync("Contratos", contrato);
            return response;
        }
        public async Task<HttpResponseMessage> RegistrarContratoParticular_DatosInvalidos()
        {
            var contrato = new ContratoParticularDTO
            {
                Tipo = "Particular",
                Id = "",
                TipoContrato = "ContratoParticular",
                NoContrato = "0",
                Estatus = "ACTIVO",
                DetalleContrato = new List<PartidaContratoParticularDTO>()
            };
            HttpResponseMessage response = await PostAsync("Contratos", contrato);
            return response;
        }                
        public async Task<HttpResponseMessage> ActualizarContratoParticular()
        {
            var contrato = new ContratoParticularDTO
            {
                Tipo = "ContratoParticular",
                Id = "68b7366eb53b69f1a1caec2e",
                TipoContrato = "ContratoParticular",
                NoContrato = "STOCK",
                Estatus = "ACTIVO",
                DetalleContrato = new List<PartidaContratoParticularDTO>
                    {
                        new PartidaContratoParticularDTO
                        {
                            PartidaContrato = "307",
                            DescripcionAviso = "CABLE DE POTENCIA MONOPOLAR AL - (1/0) - XLP - 35 - 100 CABLE DE ENERGÍA, UN CONDUCTOR DE ALUMINIO COMPACTO SELLADO, CALIBRE 1/0 AWG, XLP 100",
                            Cantidad = 15480,
                            Unidad = "Metros",
                            ImporteTotal = 1120860.51m
                        },
                        new PartidaContratoParticularDTO
                        {
                            PartidaContrato = "2",
                            DescripcionAviso = " CABLE AL (3/0)-XLP-RA-15-100-B CFE E1000-16 2016/05 Cable Energia media tension de 5 kV a 35 kV",
                            Cantidad = 2000,
                            Unidad = "Metros",
                            ImporteTotal = 147083.94m
                        }
                    }
            };
            HttpResponseMessage response = await PutAsJsonAsync("Contratos", contrato);
            return response;
        }
        public async Task<HttpResponseMessage> ActualizarContratoParticular_DatosInvalidos()
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
                            PartidaContrato = "307",
                            DescripcionAviso = "CABLE DE POTENCIA MONOPOLAR AL - (1/0) - XLP - 35 - 100 CABLE DE ENERGÍA, UN CONDUCTOR DE ALUMINIO COMPACTO SELLADO, CALIBRE 1/0 AWG, XLP 100",
                            Cantidad = 15480,
                            Unidad = "Metros",
                            ImporteTotal = 1120860.51m
                        }
                    }
            };
            HttpResponseMessage response = await PutAsJsonAsync("Contratos", contrato);
            return response;
        }
        #endregion
        public async Task<HttpResponseMessage> ObtenerContratos(int pageNumber, int pageSize) 
        { 
            var url = $"Contratos?pageNumber={pageNumber}&pageSize={pageSize}";
            var response = await _httpClient.GetAsync(url);
            return response;
        }
    }  

}
