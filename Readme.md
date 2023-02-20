# Procedimiento L0000-71 edición 2022
### _Documentación técnica_

## Archivos de la presentación del curso

- [Autenticación en el servicio web](#autenticación-en-el-servicio-web)
- [Envío de estatus del SID](#envío-de-estatus-del-sid)
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

El sistema almacenará el estado reportado, correspondiente a la sesión del usuario.

## Registrar instrumentos de medición

Método http: POST

Endpoint: 
```
https://lapem.cfe.gob.mx/sid_capacitacion/Soporte/Instrumento

```
_Comentarios_:

"id":	Identificador que se genera automáticamente (no ingresar)

"nombre":	Nombre del equipo de medición

"numeroSerie":	Número de serie del equipo de medición

"fechaCalibracion":	Fecha de calibración del equipo

"fechaVencimientoCalibracion":	Fecha de vencimiento de la calibración

"urlArchivo":	URL del archivo de calibración del equipo

"mD5":	Hash del archivo (generado por LAPEM)

"estatus": Estado del instrumento (ACTIVO/INACTIVO)

"fechaRegistro":	Fecha actual 

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

El sistema almacenará los instrumentos de medición, correspondiente a la sesión del usuario.

