# Procedimiento L0000-71 edición 2022
### _Documentación técnica_

## Archivos de la presentación del curso

- [Autenticación en el servicio web](#autenticación-en-el-servicio-web)
- [Envío de estatus del SID](#envío-de-estatus-del-sid)
- [Registrar instrumentos de medición](#registrar-instrumentos-de-medición)
- [Consultar instrumentos de medición](#consultar-instrumentos-de-medición)
- [Actualizar instrumentos de medición](#actualizar-instrumentos-de-medición)
- [Registrar la norma con la que se liberan los productos](#registrar-la-norma-con-la-que-se-liberan-los-productos)
- [Consultar las normas con las que se liberan los productos](#consultar-las-normas-con-las-que-se-liberan-los-productos)
- [Actualizar la norma con la que se liberan los productos](#actualizar-la-norma-con-la-que-se-liberan-los-productos)
- [Registrar las pruebas](#registrar-las-pruebas)
- [Consultar las pruebas](#consultar-las-pruebas)
- [Registrar los valores de referencia](#registrar-los-valores-de-referencia)
- [Consultar los valores de referencia](#consultar-los-valores-de-referencia)
- [Actualizar los valores de referencia](#actualizar-los-valores-de-referencia)
- [Registrar producto](#registrar-producto)
- [Consultar productos](#consultar-productos)
- [Actualizar producto](#actualizar-producto)
- [Registrar prototipo](#registrar-prototipo)
- [Consultar prototipos](#consultar-prototipos)
- [Actualizar prototipo](#actualizar-prototipo)
- [Registrar prueba](#registrar-prueba)
- [Registrar contrato de CFE](#registrar-contrato-de-cfe)
- [Consultar contrato de CFE](#consultar-contrato-de-cfe)
- [Crear expediente de pruebas](#crear-expediente-de-pruebas)
- [Agregar muestra al expediente de pruebas](#agregar-muestra-al-expediente-de-pruebas)
- [Prácticas](practicas.md)
- ✨Magic ✨

## Autenticación en el servicio web

Método http: POST

Endpoint: 
```
https://lapem.cfe.gob.mx/sid_capacitacion/User/Login
```

_Comentarios_:

Username: Nombre del usuario registrado con LAPEM

Password: Es la contraseña sin cifrar correspondiente al nombre de usuario proporcionado

Nota: Solo tendrán acceso los usuarios registrados en SID.

json de ejemplo:
```json
{
  "username": "9AJAX",
  "password": "58974"
}

```

_Resultado_:

El sistema deberá generar el token criptográfico correspondiente a la sesión del usuario.

body resultante si la respuesta es correcta
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJDQVJMT1MgQUxCRVJUTyBTT0xJUyBNQURSSUdBTCIsImZ1bGxOYW1lIjoiQ0FSTE9TIEFMQkVSVE8gU09MSVMgTUFEUklHQUwiLCJ1c2VybmFtZSI6IjlBSkFYIiwicmZjIjoiQ0ZFMzcwODE0UUkwIiwiZW1wcmVzYSI6IkNPTUlTSU9OIEZFREVSQUwgREUgRUxFQ1RSSUNJREFEIiwiSWRFbXByZXNhIjoiMSIsInJvbGUiOiJVc2VyX1NJRCIsImp0aSI6ImY1Y2E1MzY1LWY1NzUtNGQ0Ny04MDU2LWMxMzRjYWY0OThkMyIsImV4cCI6MTY3NDg0NzI4OSwiaXNzIjoiaHR0cHM6Ly9sYXBlbS5jZmUuZ29iLm14L3NpZC8iLCJhdWQiOiJodHRwczovL2xhcGVtLmNmZS5nb2IubXgvc2lkLyJ9.F1Ihgrv93C11Y1mrGSuF_vGnPJ2Exek373i3csSmnFs",
  "userDetails": {
    "nombre": "CARLOS ALBERTO SOLIS MADRIGAL",
    "username": "9AJAX",
    "password": null,
    "empresa": "COMISION FEDERAL DE ELECTRICIDAD",
    "idEmpresa": "1",
    "rfc": "CFE370814QI0",
    "rol": "User_SID"
  }
}
```

## Envío de estatus del SID

Método http: POST

Endpoint: 
```
https://lapem.cfe.gob.mx/sid_capacitacion/Soporte/EstadoSID
```
_Comentarios_:

El estado a reportar es: EN_ESPERA ó EN_PRUEBAS

json de ejemplo:
```json
{
  "estado": "EN_PRUEBAS"
}
```
_Resultado_:

Status: 200 - El sistema almacenará el estado reportado, correspondiente a la sesión del usuario.

## Registrar instrumentos de medición

Método http: POST

Endpoint: 
```
https://lapem.cfe.gob.mx/sid_capacitacion/Soporte/Instrumento
```
_Comentarios_:


| Propiedad | Descripción |
| --- | --- |
| `id` | Identificador que se genera automáticamente  *(no ingresar)* |
| `nombre` | Nombre del equipo de medición|
| `numeroSerie` | Número de serie del equipo de medición |
| `fechaCalibracion` | Fecha de calibración del equipo |
| `fechaVencimientoCalibracion` | Fecha de vencimiento de la calibración |
| `urlArchivo` | ruta donde el fabricante almacena el archivo de calibración del equipo |
| `mD5` | Hash del archivo *(generado por LAPEM, no ingresar)* |
| `estatus` | Estado del instrumento: **ACTIVO/INACTIVO** |
| `fechaRegistro` | Fecha actual del registro *(no ingresar)* |

json de ejemplo:
```json
{
  "id": "",
  "nombre": "Voltímetro",
  "numeroSerie": "F256989",
  "fechaCalibracion": "2023-01-18T20:55:05.917Z",
  "fechaVencimientoCalibracion":"2023-01-18T20:55:05.917Z",  
  "urlArchivo":"https://unlp.edu.ar/wp-content/uploads/51/27751/5c5a8f71c013ea9277e46bcf4b1658b2.pdf",
  "mD5": "",
  "estatus": "ACTIVO"
}
```
_Resultado_:

Status: 200 - El sistema almacena el instrumento de medición, correspondiente a la sesión del usuario.

## Consultar instrumentos de medición

Método http: GET

Endpoint: 
```
https://lapem.cfe.gob.mx/sid_capacitacion/Soporte/Instrumento
```

_Resultado_:

Status: 200 - Listado con todos los instrumentos de medición correspondientes a la sesión del usuario

## Actualizar instrumentos de medición

Método http: PUT

Endpoint: 
```
https://lapem.cfe.gob.mx/sid_capacitacion/Soporte/Instrumento
```
_Comentarios_:


| Propiedad | Descripción |
| --- | --- |
| `id` | Identificador del instrumento de medición a actualizar |
| `nombre` | Nombre del equipo de medición|
| `numeroSerie` | Número de serie del equipo de medición |
| `fechaCalibracion` | Fecha de calibración del equipo |
| `fechaVencimientoCalibracion` | Fecha de vencimiento de la calibración |
| `urlArchivo` | ruta donde el fabricante almacena el archivo de calibración del equipo |
| `mD5` | Hash del archivo *(generado por LAPEM, no ingresar)* |
| `estatus` | Estado del instrumento: **ACTIVO/INACTIVO** |
| `fechaRegistro` | Fecha actual del registro *(no ingresar)* |

json de ejemplo:
```json
{
  "id": "63f3d5bf32320c6cf9a742f4",
  "nombre": "Voltímetro 897",
  "numeroSerie": "F256989-897",
  "fechaCalibracion": "2024-01-10",
  "fechaVencimientoCalibracion": "2025-01-10",
  "urlArchivo": "https://unlp.edu.ar/wp-content/uploads/51/27751/5c5a8f71c013ea9277e46bcf4b1658b2.pdf",
  "mD5": "",
  "estatus": "ACTIVO"
}
```
_Resultado_:

Status: 200 - El sistema actualiza el instrumento de medición correspondiente la sesión del usuario.

## Registrar la norma con la que se liberan los productos

Método http: POST

Endpoint: 
```
https://lapem.cfe.gob.mx/sid_capacitacion/Soporte/Norma
```
_Comentarios_:

| Propiedad | Descripción |
| --- | --- |
| `id` | Identificador que se genera automáticamente  *(no ingresar)* |
| `clave` | Identificador clave de la norma|
| `nombre` | Nombre de la norma |
| `edicion` | Año de edición de la norma *(yyyy)*|
| `estatus` | Estado de la norma: **VIGENTE/OBSOLETA** |
| `esCFE` | Indicar true si es de CFE, false en caso contrario |
| `fechaRegistro` | Fecha actual del registro *(no ingresar)* |

json de ejemplo:
```json
{
  "id":"",
  "clave": "52100-65",
  "nombre": "Aisladores Sintéticos tipo Suspensión para Tensiones de 13.8 kV hasta 138 kV",
  "edicion": "2019",
  "estatus": "VIGENTE",
  "esCFE": true 
}
```
_Resultado_:

Status: 200 - El sistema almacenará la información de la norma, correspondiente a la sesión del usuario.

## Consultar las normas con las que se liberan los productos

Método http: GET

Endpoint: 
```
https://lapem.cfe.gob.mx/sid_capacitacion/Soporte/Norma
```

_Resultado_:

Status: 200 - Listado con todas las normas correspondientes a la sesión del usuario

## Actualizar la norma con la que se liberan los productos

Método http: PUT

Endpoint: 
```
https://lapem.cfe.gob.mx/sid_capacitacion/Soporte/Norma
```
_Comentarios_:

| Propiedad | Descripción |
| --- | --- |
| `id` | Identificador de la norma a actualizar |
| `clave` | Identificador clave de la norma|
| `nombre` | Nombre de la norma |
| `edicion` | Año de edición de la norma *(yyyy)*|
| `estatus` | Estado de la norma: **VIGENTE/OBSOLETA** |
| `esCFE` | Indicar true si es de CFE, false en caso contrario |
| `fechaRegistro` | Fecha actual del registro *(no ingresar)* |

json de ejemplo:
```json
{
  "id": "62c5c527f2479888d0233f22",
  "clave": "01000-11",
  "nombre": "CFE 01000-11-1996",
  "edicion": "1996",
  "estatus": "VIGENTE",
  "esCFE": true
}
```
_Resultado_:

Status: 200 - El sistema actualizará la información de la norma, correspondiente a la sesión del usuario.


## Registrar las pruebas

Método http: POST

Endpoint: 
```
https://lapem.cfe.gob.mx/sid_capacitacion/Soporte/Prueba
```
_Comentarios_:

| Propiedad | Descripción |
| --- | --- |
| `id` | Identificador que se genera automáticamente  *(no ingresar)* |
| `nombre` | Nombre de la prueba|
| `estatus` | Estado de la prueba: **ACTIVA/INACTIVA** |
| `tipoPrueba` | Tipo de prueba **ACEPTACION/RUTINA**|
| `tipoResultado` | Tipo de resultado **VALOR_REFERENCIA/PASA/NO-PASA** |
| `fechaRegistro` | Fecha actual del registro |

json de ejemplo:
```json
{
  "id": "",
  "nombre": "IMPULSO",
  "estatus": "ACTIVA",
  "tipoPrueba": "ACEPTACION",
  "tipoResultado": "PASA/NO-PASA",
  "fechaRegistro": "2022-10-10"
}
```
_Resultado_:

Status: 200 - El sistema almacenará la información de la prueba, correspondiente a la sesión del usuario.

## Consultar las pruebas

Método http: GET

Endpoint: 
```
https://lapem.cfe.gob.mx/sid_capacitacion/Soporte/prueba
```

_Resultado_:

Status: 200 - Listado con todas las pruebas, correspondientes a la sesión del usuario.

## Registrar los valores de referencia

Método http: POST

Endpoint: 
```
https://lapem.cfe.gob.mx/sid_capacitacion/Soporte/ValorReferencia
```
_Comentarios_:

| Propiedad | Descripción |
| --- | --- |
| `id` | Identificador que se genera automáticamente  *(no ingresar)* |
| `producto` | [Json del producto](#registrar-producto)|
| `prototipo` | [Json del prototipo](#registrar-prototipo) |
| `prueba` | [Json de la prueba](#registrar-prueba) |
| `valor` | Rango inicial (mínimo) *solo se utiliza cuando el tipo de "comparacion" sea por "RANGO"* |
| `valor2` | Rango final (máximo) *solo se utiliza cuando el tipo de "comparacion" sea por "RANGO"*  |
| `unidad` | Unidad para medir el valor de referencia |
| `comparacion` | Comparativa de los valores de referencia pueden ser: **VALOR_MINIMO/VALOR_MAXIMO/RANGO** |
| `fechaRegistro` | Fecha actual en que se registra la información |

> Cuando en la prueba, el valor de "tipoResultado" es **PASA/NO-PASA** NO se utilizan los valores de referencia 

json de ejemplo:
```json
{
  "id": "string",
  "producto": {
    "id": "62c5c5dbf2479888d0233f23",
    "codigoFabricante": "PROD-001-2024",
    "descripcion": "PRODUCTO P001",
    "descripcionCorta": "CFE 456464646",
    "tipoFabricacion": "SERIE",
    "unidad": "PIEZA",
    "norma": {
      "id": "62c5c527f2479888d0233f22",
      "clave": "CFE K0000-25",
      "nombre": "NORMA CFE K0000-25",
      "edicion": "2014",
      "estatus": "VIGENTE",
      "esCFE": true,
      "fechaRegistro": "2022-07-06T17:23:51.971Z"
    },
    "prototipo": {
      "id": "62c5c45bf2479888d0233f21",
      "numero": "K3100/2300-90",
      "fechaEmision": "2022-07-06T17:18:33.522Z",
      "fechaVencimiento": "2025-07-06T17:18:33.522Z",
      "urlArchivo": "http://10.44.6.51/CotizacionesAPI/api/cotizacion/cotizacionArchPdf/cot/pdf/44004",
      "mD5": "",
      "estatus": "VIGENTE",
      "fechaRegistro": "2022-07-06T17:22:01.61Z"
    },
    "estatus": "ACTIVO",
    "fechaRegistro": "2023-01-24T19:57:12.635Z"
  },
  "prueba":{
    "id": "62ead53891372bb1f219d0e5",
    "nombre": "PRUEBA VISUAL Y DIMENSIONAL",
    "estatus": "ACTIVA",
    "tipoPrueba": "ACEPTACION",
    "tipoResultado": "PASA/NO-PASA",
    "fechaRegistro": "2022-08-03T20:06:16.878Z"
  },
  "valor": 15,
  "valor2": 20,
  "unidad": "KV",
  "comparacion": "RANGO"
}
```
_Resultado_:

Status: 200 - El sistema almacenará los valores de referencia por producto y prueba , correspondiente a la sesión del usuario.

## Consultar los valores de referencia

Método http: GET

Endpoint: 
```
https://lapem.cfe.gob.mx/sid_capacitacion/Soporte/ValorReferencia
```

_Resultado_:

Status: 200 - Listado con todos los valores de referencia, correspondientes a la sesión del usuario

## Actualizar los valores de referencia

Método http: PUT

Endpoint: 
```
https://lapem.cfe.gob.mx/sid_capacitacion/Soporte/ValorReferencia
```
_Comentarios_:

| Propiedad | Descripción |
| --- | --- |
| `id` | Identificador del valor de referencia a modificar |
| `producto` | [Json del producto](#registrar-producto)|
| `prototipo` | [Json del prototipo](#registrar-prototipo) |
| `prueba` | [Json de la prueba](#registrar-prueba) |
| `valor` | Rango inicial (mínimo) *solo se utiliza cuando el tipo de "comparacion" sea por "RANGO"* |
| `valor2` | Rango final (máximo) *solo se utiliza cuando el tipo de "comparacion" sea por "RANGO"*  |
| `unidad` | Unidad para medir el valor de referencia |
| `comparacion` | Comparativa de los valores de referencia pueden ser: **VALOR_MINIMO/VALOR_MAXIMO/RANGO** |
| `fechaRegistro` | Fecha actual en que se registra la información *(no ingresar)* |

> Cuando en la prueba, el valor de "tipoResultado" es **PASA/NO-PASA** NO se utilizan los valores de referencia 

json de ejemplo:
```json
{
  "id": "string",
  "producto": {
    "id": "62c5c5dbf2479888d0233f23",
    "codigoFabricante": "PROD-001-2024",
    "descripcion": "PRODUCTO P001",
    "descripcionCorta": "CFE 456464646",
    "tipoFabricacion": "SERIE",
    "unidad": "PIEZA",
    "norma": {
      "id": "62c5c527f2479888d0233f22",
      "clave": "CFE K0000-25",
      "nombre": "NORMA CFE K0000-25",
      "edicion": "2014",
      "estatus": "VIGENTE",
      "esCFE": true,
      "fechaRegistro": "2022-07-06T17:23:51.971Z"
    },
    "prototipo": {
      "id": "62c5c45bf2479888d0233f21",
      "numero": "K3100/2300-90",
      "fechaEmision": "2022-07-06T17:18:33.522Z",
      "fechaVencimiento": "2025-07-06T17:18:33.522Z",
      "urlArchivo": "http://10.44.6.51/CotizacionesAPI/api/cotizacion/cotizacionArchPdf/cot/pdf/44004",
      "mD5": "",
      "estatus": "VIGENTE",
      "fechaRegistro": "2022-07-06T17:22:01.61Z"
    },
    "estatus": "ACTIVO",
    "fechaRegistro": "2023-01-24T19:57:12.635Z"
  },
  "prueba":{
    "id": "62ead53891372bb1f219d0e5",
    "nombre": "PRUEBA VISUAL Y DIMENSIONAL",
    "estatus": "ACTIVA",
    "tipoPrueba": "ACEPTACION",
    "tipoResultado": "PASA/NO-PASA",
    "fechaRegistro": "2022-08-03T20:06:16.878Z"
  },
  "valor": 15,
  "valor2": 20,
  "unidad": "KV",
  "comparacion": "RANGO"
}
```
_Resultado_:

Status: 200 - El sistema actualizará el valor de referencia, correspondiente a la sesión del usuario.

## Registrar producto

Método http: POST

Endpoint: 
```
https://lapem.cfe.gob.mx/sid_capacitacion/Soporte/Producto
```
_Comentarios_:

| Propiedad | Descripción |
| --- | --- |
| `id` | Identificador que se genera automáticamente  *(no ingresar)* |
| `codigoFabricante` | Código del producto como lo identifica el fabricante|
| `descripcion` | Descripción del producto |
| `descripcionCorta` | Descripción corta de CFE para identificar el producto |
| `tipoFabricacion` | Tipo de fabricación **SERIE/LOTE** |
| `unidad` | Unidades **Pieza/Metro/Tramo/Kilo** |
| `norma` | [Json de la norma](#registrar-la-norma-con-la-que-se-liberan-los-productos) |
| `prototipo` | [Json del prototipo](#registrar-prototipo) |
| `estatus` | Estado del producto **ACTIVO/INACTIVO** |
| `fechaRegistro` | Fecha actual del registro *(no ingresar)* |

json de ejemplo:
```json
{
  "id": "",
  "codigoFabricante": "Tablero TFCD 125 VCD",
  "descripcion": "Tablero TFCD para 125 VCD transferencia de 2 fuentes de corriente directa",
  "descripcionCorta": "TAB125VCD",
  "tipoFabricacion": "SERIE",
  "unidad": "Piezas",
  "norma": {
    "id": "6388e41a5a5f3032d0a45279",
    "clave": "CFE K0000-25",
    "nombre": "NORMA CFE K0000-25",
    "edicion": "2014",
    "estatus": "VIGENTE",
    "esCFE": true,
    "fechaRegistro": "2023-01-30T20:17:27.981Z"
  },
  "prototipo": {
  "id": "62c5c45bf2479888d0233f21",
    "numero": "K3100/2300-90",
    "fechaEmision": "2022-07-06T17:18:33.522Z",
    "fechaVencimiento": "2025-07-06T17:18:33.522Z",
    "urlArchivo": "http://10.44.6.51/CotizacionesAPI/api/cotizacion/cotizacionArchPdf/cot/pdf/44004",
    "mD5": "",
    "estatus": "VIGENTE",
    "fechaRegistro": "2022-07-06T17:22:01.61Z"
  },
  "estatus": "ACTIVO",
  "fechaRegistro": "2023-01-30"
}
```
_Resultado_:

Status: 200 - El sistema almacenará la información del producto, correspondiente a la sesión del usuario.

## Consultar productos

Método http: GET

Endpoint: 
```
https://lapem.cfe.gob.mx/sid_capacitacion/Soporte/Producto
```

_Resultado_:

Status: 200 - Listado con todos los productos, correspondientes a la sesión del usuario

## Actualizar producto

Método http: PUT

Endpoint: 
```
https://lapem.cfe.gob.mx/sid_capacitacion/Soporte/Producto
```
_Comentarios_:

| Propiedad | Descripción |
| --- | --- |
| `id` | Identificador del producto a actualizar |
| `codigoFabricante` | Código del producto como lo identifica el fabricante|
| `descripcion` | Descripción del producto |
| `descripcionCorta` | Descripción corta de CFE para identificar el producto |
| `tipoFabricacion` | Tipo de fabricación **SERIE/LOTE** |
| `unidad` | Unidades **Pieza/Metro/Tramo/Kilo** |
| `norma` | [Json de la norma](#registrar-la-norma-con-la-que-se-liberan-los-productos) |
| `prototipo` | [Json del prototipo](#registrar-prototipo) |
| `estatus` | Estado del producto **ACTIVO/INACTIVO** |
| `fechaRegistro` | Fecha actual del registro *(no ingresar)* |

json de ejemplo:
```json
{
   "id": "62c5c5dbf2479888d0233f23",
  "codigoFabricante": "PROD-001-2024",
  "descripcion": "PRODUCTO P001",
  "descripcionCorta": "CFE 456464646",
  "tipoFabricacion": "SERIE",
  "unidad": "PIEZA",
    "norma": {
      "id": "62c5c527f2479888d0233f22",
      "clave": "CFE K0000-25",
      "nombre": "NORMA CFE K0000-25",
      "edicion": "2014",
      "estatus": "VIGENTE",
      "esCFE": true,
      "fechaRegistro": "2022-07-06T17:23:51.971Z"
    },
 "prototipo": {
      "id": "62c5c45bf2479888d0233f21",
      "numero": "K3100/2300-90",
      "fechaEmision": "2022-07-06T17:18:33.522Z",
      "fechaVencimiento": "2025-07-06T17:18:33.522Z",
      "urlArchivo": "http://10.44.6.51/CotizacionesAPI/api/cotizacion/cotizacionArchPdf/cot/pdf/44004",
      "mD5": "",
      "estatus": "VIGENTE",
      "fechaRegistro": "2022-07-06T17:22:01.61Z"
    },
   "estatus": "ACTIVO",
    "fechaRegistro": "2023-01-30T20:50:12.363Z"
}
```
_Resultado_:

Status: 200 - El sistema actualizará la información del producto, correspondiente a la sesión del usuario.

## Registrar prototipo

Método http: POST

Endpoint: 
```
https://lapem.cfe.gob.mx/sid_capacitacion/Soporte/Prototipo
```
_Comentarios_:

| Propiedad | Descripción |
| --- | --- |
| `id` | Identificador que se genera automáticamente  *(no ingresar)* |
| `numero` | Número de identificación del prototipo |
| `fechaEmision` | Fecha en que se emitió el prototipo |
| `fechaVencimiento` | Fecha en que se vence el prototipo |
| `urlArchivo` | Ruta de ubicación del fabricante donde reside el archivo del prototipo |
| `md5` | Hash del archivo prototipo, se genera por LAPEM *(no ingresar)* |
| `estatus` | Estado del prototipo **VIGENTE/VENCIDO** |
| `fechaRegistro` | Fecha actual del registro *(no ingresar)* |

json de ejemplo:
```json
{
  "id": "",
  "numero": "0589/K3115-E/2023",
  "fechaEmision": "2020-01-20T19:40:14.065Z",
  "fechaVencimiento": "2022-01-27T19:40:14.065Z",
  "urlArchivo": "http://10.44.6.51/CotizacionesAPI/api/cotizacion/cotizacionArchPdf/cot/pdf/44004",
  "mD5": "",
  "estatus": "VIGENTE"
}

```
_Resultado_:

Status: 200 - El sistema almacenará la información del prototipo, correspondiente a la sesión del usuario.

## Consultar prototipos

Método http: GET

Endpoint: 
```
https://lapem.cfe.gob.mx/sid_capacitacion/Soporte/Prototipo
```

_Resultado_:

Status: 200 - Listado con todos los prototipos, correspondientes a la sesión del usuario

## Actualizar prototipo

Método http: PUT

Endpoint: 
```
https://lapem.cfe.gob.mx/sid_capacitacion/Soporte/Prototipo
```
_Comentarios_:

| Propiedad | Descripción |
| --- | --- |
| `id` | Identificador del prototipo a actualizar |
| `numero` | Número de identificación del prototipo |
| `fechaEmision` | Fecha en que se emitió el prototipo |
| `fechaVencimiento` | Fecha en que se vence el prototipo |
| `urlArchivo` | Ruta de ubicación del fabricante donde reside el archivo del prototipo |
| `md5` | Hash del archivo prototipo, se genera por LAPEM *(no ingresar)* |
| `estatus` | Estado del prototipo **VIGENTE/VENCIDO** |
| `fechaRegistro` | Fecha actual del registro *(no ingresar)* |

json de ejemplo:
```json
{
  "id": "62c5c45bf2479888d0233f21",
  "numero": "K3100/2300-90",
  "fechaEmision": "2022-07-06T17:18:33.522Z",
  "fechaVencimiento": "2025-07-06T17:18:33.522Z",
  "urlArchivo": "http://10.44.6.51/CotizacionesAPI/api/cotizacion/cotizacionArchPdf/cot/pdf/44004",
  "mD5": "",
  "estatus": "VIGENTE"
}

```
_Resultado_:

Status: 200 - El sistema actualiza la información del prototipo, correspondiente a la sesión del usuario.

## Registrar prueba

Método http: POST

Endpoint: 
```
https://lapem.cfe.gob.mx/sid_capacitacion/Soporte/Prueba
```
_Comentarios_:

| Propiedad | Descripción |
| --- | --- |
| `id` | Identificador que se genera automáticamente  *(no ingresar)* |
| `nombre` | Nombre de la prueba |
| `estatus` | Estado de la prueba **ACTIVA/INACTIVA** |
| `tipoPrueba` |Tipo de prueba **ACEPTACION/RUTINA** |
| `tipoResultado` | Los tipos de resultado pueden ser: **VALOR_REFERENCIA/PASA/NO-PASA** |
| `fechaRegistro` | Fecha actual del registro |

> Si "tipoResultado" es **PASA/NO-PASA** no se utilizan los referencia

json de ejemplo:
```json
{
  "id": "",
  "nombre": "IMPULSO",
  "estatus": "ACTIVA",
  "tipoPrueba": "ACEPTACION",
  "tipoResultado": "PASA/NO-PASA",
  "fechaRegistro": "2022-10-10"
}


```
_Resultado_:

Status: 200 - El sistema almacenará la información de la prueba, correspondiente a la sesión del usuario.

## Registrar contrato de CFE

Método http: POST

Endpoint: 
```
https://lapem.cfe.gob.mx/sid_capacitacion/Soporte/ContratosCFE
```
_Comentarios_:

| Propiedad | Descripción |
| --- | --- |
| `id` | Identificador que se genera automáticamente  *(no ingresar)* |
| `noContrato` | Número de contrato de CFE |
| `areaDestinoCFE` | Nombre del área destino de los equipos |
| `urlArchivo` | Ubicación del fabricante donde se ubica el archivo del contrato de CFE |
| `mD5` | Hash del archivo del contrato *(no ingresar)* |
| `estatus` | Los estatus pueden ser: **VIGENTE/VENCIDO** |
| `fechaEntregaCFE` | Fecha de entrega de los materiales a CFE |
| `fechaRegistro` | Fecha actual del registro |


json de ejemplo:
```json
{
  "id": "",
  "noContrato": "CFE-GRP-0587",
  "areaDestinoCFE": "Almacén Bajío",
  "urlArchivo": "http://10.44.6.51/CotizacionesAPI/api/cotizacion/cotizacionArchPdf/cot/pdf/44004",
  "mD5": "",
  "estatus": "VIGENTE",
  "fechaEntregaCFE": "2023-10-05T19:56:57.059Z",
  "fechaRegistro": "2023-01-30T19:56:57.059Z"
}
```

_Resultado_:

Status: 200 - El sistema almacenará la información del contrato de CFE, correspondiente a la sesión del usuario.

## Consultar contrato de CFE

Método http: GET

Endpoint: 
```
https://lapem.cfe.gob.mx/sid_capacitacion/Soporte/ContratosCFE
```

_Resultado_:

Status: 200 - Listado con todos los contratos de CFE registrados, correspondientes a la sesión del usuario

## Crear expediente de pruebas

Método http: POST

Endpoint: 
```
https://lapem.cfe.gob.mx/sid_capacitacion/Inspeccion/CreaExpedientePruebas
```
_Comentarios_:

| Propiedad | Descripción |
| --- | --- |
| `id` | Identificador que se genera automáticamente  *(no ingresar)* |
| `claveExpediente` | Clave que identifica el expediente de pruebas |
| `muestrasExpediente` | Lista de [muestras] del expediente(#registrar-muestra) |

json de ejemplo:
```json
{
  "id": "",
  "claveExpediente": "EXP-123",
  "muestrasExpediente": [
    {
      "identificador": "M1-0001",
      "estatus": "EN_PRUEBA",
      "fechaRegistro": "2023-01-31T17:53:24.285Z"
    }
  ],
  "ordenFabricacion": {
    "claveOrdenFabricacion": "OF-02-2023",
    "producto": {
      "id": "62c5c5dbf2479888d0233f23",
      "codigoFabricante": "AISLADOR 138PM",
      "descripcion": "AISLADOR 138PM MODELO AI867",
      "descripcionCorta": "AS-AISLADOR 138PM",
      "tipoFabricacion": "SERIE",
      "unidad": "PIEZA",
      "norma": {
        "id": "62c5c527f2479888d0233f22",
        "clave": "CFE K0000-25",
        "nombre": "NORMA CFE K0000-25",
        "edicion": "2014",
        "estatus": "VIGENTE",
        "esCFE": true,
        "fechaRegistro": "2023-01-31T17:53:24.285Z"
      },
      "prototipo": {
        "id": "62a9f173156b9acb784bb597",
        "numero": "K311P/2345-2022",
        "fechaEmision": "2022-06-15T17:53:24.285Z",
        "fechaVencimiento": "2025-06-15T17:53:24.285Z",
        "urlArchivo": "http://10.44.6.51/CotizacionesAPI/api/cotizacion/cotizacionArchPdf/cot/pdf/44004",
        "mD5": "",
        "estatus": "VIGENTE",
        "fechaRegistro": "2023-01-31T17:53:24.285Z"
      },
      "estatus": "REGISTRADO",
      "fechaRegistro": "2023-01-31T17:53:24.285Z"
    },
    "tipoContrato": "CFE",
    "contratoCFE": {
      "id": "63d8216bcb5cc767b6f82300",
      "noContrato": "CFE-GRP-0587",
      "areaDestinoCFE": "Almacén Bajío",
      "urlArchivo": "http://10.44.6.51/CotizacionesAPI/api/cotizacion/cotizacionArchPdf/cot/pdf/44004",
      "mD5": "",
      "estatus": "VIGENTE",
      "fechaEntregaCFE": "2023-10-05T17:53:24.285Z",
      "fechaRegistro": "2023-01-31T17:53:24.285Z"
    },
    "partidaContrato": "5",
    "cantidad": 3,
    "fechaRegistro": "2023-01-31T17:53:24.285Z"
  }
}
```

_Resultado_:

Status: 200 - El sistema almacenará la información del expediente de pruebas, correspondiente a la sesión del usuario.

## Agregar muestra al expediente de pruebas

Método http: PUT

Endpoint: 
```
https://lapem.cfe.gob.mx/sid_capacitacion/Inspeccion/AgregaMuestraExpediente/{Expediente}
```
_Comentarios_:

> `{Expediente}` | Corresponde a la clave que identifica al expediente donde se agregará la muestra 

| Propiedad | Descripción |
| --- | --- |
| `noContrato` | Número de contrato de CFE |


json de ejemplo:
```json
{
  
}
```

_Resultado_:

Status: 200 - El sistema almacenará la información de la muestra en el expediente, correspondiente a la sesión del usuario.
