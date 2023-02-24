# Procedimiento L0000-71 edición 2022
### _Documentación técnica_

## Archivos de la presentación del curso

- [Autenticación en el servicio web](#autenticación-en-el-servicio-web)
- [Envío de estatus del SID](#envío-de-estatus-del-sid)
- [Registrar instrumentos de medición](#registrar-instrumentos-de-medición)
- [Consultar instrumentos de medición](#consultar-instrumentos-de-medición)
- [Registrar la norma con la que se liberan los productos](#registrar-la-norma-con-la-que-se-liberan-los-productos)
- [Consultar las normas con las que se liberan los productos](#consultar-las-normas-con-las-que-se-liberan-los-productos)
- [Registrar las pruebas](#registrar-las-pruebas)
- [Consultar las pruebas](#consultar-las-pruebas)
- [Registrar los valores de referencia](#registrar-los-valores-de-referencia)
- [Prácticas](practicas.md)
- Registro de los instrumentos de medición
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
| `fechaRegistro` | Fecha actual del registro |

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
  "estatus": "ACTIVO",
  "fechaRegistro": "2023-01-18T20:55:05.917Z"
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
| `fechaRegistro` | Fecha actual del registro |

json de ejemplo:
```json
{
  "id": "",
  "clave": "01000-11",
  "nombre": "CFE 01000-11-1996",
  "edicion": "1996",
  "estatus": "VIGENTE",
  "esCFE": true,
  "fechaRegistro": "2022-10-10"
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
| `tipoResultado` | Tipo de resultado **PASA/NO-PASA/SATISFACTORIO/NOSATISFACTORIO** |
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
| `producto` | Información del producto |
| `prototipo` | Información del prototipo |
| `prueba` | Información de la prueba|
| `valor` | Valor inicial (mínimo) |
| `valor2` | Valor final (máximo) |
| `unidad` | Unidad para medir el valor de referencia |
| `comparación` | Comparativa de los valores de referencia **RANGO/EXACTO** |
| `fechaRegistro` | Fecha actual en que se registra la información |


json de ejemplo:
```json
{
  "id": "string",
  "producto": {
    "id": "",
    "codigoFabricante": "RP08976",
    "descripcion": "TRANSFORMADOR PEDESTAL",
    "descripcionCorta": "TRAFO15KV",
    "tipoFabricacion": "ARTESANAL",
    "unidad": "PIEZA",
    "norma": {
      "id": "",
      "clave": "PK3000",
      "nombre": "TRANSFORMADORES DE DISTRIBUCION TIPO PEDESTAL",
      "edicion": "2018",
      "estatus": "VIGENTE",
      "esCFE": true,
      "fechaRegistro": "2023-01-24T19:57:12.635Z"
    },
    "prototipo": {
      "id": "",
      "numero": "E101-2022",
      "fechaEmision": "2021-01-20T19:57:12.635Z",
      "fechaVencimiento": "2023-01-20T19:57:12.635Z",
      "urlArchivo": "C:/tmp/Ejemplo.pdf",
      "mD5": "",
      "estatus": "VIGENTE",
      "fechaRegistro": "2023-01-24T19:57:12.635Z"
    },
    "estatus": "ACTIVO",
    "fechaRegistro": "2023-01-24T19:57:12.635Z"
  },
  "prueba": {
    "id": "",
    "nombre": "IMPULSO",
    "estatus": "ACTIVA",
    "tipoPrueba": "RUTINA",
    "tipoResultado": "PASA/NO-PASA",
    "fechaRegistro": "2023-01-24T19:57:12.635Z"
  },
  "valor": 12,
  "valor2": 15,
  "unidad": "KV",
  "comparacion": "INTERVALO",
  "fechaRegistro": "2023-01-24T19:57:12.635Z"
}
```
_Resultado_:

Status: 200 - El sistema almacenará los valores de referencia por producto y prueba , correspondiente a la sesión del usuario.

