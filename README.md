# Backend: API BFF (Backend for Frontend) - Rick and Morty

Este proyecto sirve como BFF (Backend for Frontend) para orquestar la comunicación con la API pública de Rick and Morty, garantizando una capa de lógica de negocio, manejo centralizado de errores y una estructura robusta.

## Arquitectura
El proyecto sigue una estructura de capas para garantizar la separación de responsabilidades y los principios SOLID:

* PruebaTecnica.Entities: Capa de modelos y contratos (POCOs).
* PruebaTecnica.DataLogic: Capa de acceso a datos (DAL) que gestiona HttpClient hacia la API externa.
* PruebaTecnica.BusinessLogic: Capa de lógica de negocio (BLL) que procesa, valida y transforma la información.
* PruebaTecnica.Api: Web API que expone los endpoints al frontend, incluye el Middleware de errores y la configuración.

## Tecnologías
* .NET 8 (C#)
* Middleware: Manejo centralizado de excepciones (Retorna respuestas 500/404 estandarizadas).
* HttpClientFactory: Gestión eficiente de conexiones HTTP.
* Swagger/OpenAPI: Documentación automática de endpoints.
* CORS: Configurado para comunicación segura con el frontend.

## Configuración
El proyecto utiliza appsettings.json para gestionar la conexión a la API externa:

{
  "ExternalApis": {
    "RickAndMortyBaseUrl": "https://rickandmortyapi.com/api"
  },
  "AllowedHosts": "*"
}


## Cómo ejecutar el proyecto

### Prerrequisitos
* .NET 8 SDK instalado.
* Visual Studio 2022 o VS Code.

### Pasos para levantar el Backend:
1. Clona el repositorio: git clone https://github.com/Bjarkans97/PruebaTecnicaBackEnd
2. Abre la solución PruebaTecnicaCarsales.sln.
3. Establece PruebaTecnica.Api como Proyecto de Inicio.
4. Ejecuta (F5). Swagger se abrirá en http://localhost:5122/swagger.

## Endpoints

| Método | Endpoint 				| Descripción 													|
| :------| :------------------------| :-------------------------------------------------------------|
| GET    | /api/Episodes 			| Obtiene la lista de episodios (usa ?page=n para paginación). 	|
| GET 	 | /api/Episodes/{id} 		| Obtiene el detalle de un episodio por ID. 					|
| GET 	 | /api/Episodes/list/{ids} | Obtiene múltiples episodios por IDs separados por coma. 		|
| GET 	 | /api/Personajes 			| Obtiene la lista de personajes. 								|
| GET 	 | /api/Personajes/{id} 	| Obtiene detalle de un personaje. 								|

## Ejemplos de uso
* Consulta paginada: GET http://localhost:5122/api/Episodes?page=2
* Consulta de múltiples: GET http://localhost:5122/api/Episodes/list/1,2,5

---
Notas de implementación:
* Manejo de Errores: Cualquier falla en el servidor es capturada por el ErrorHandlingMiddleware, retornando un JSON coherente.
* Inyección de Dependencias: El uso de interfaces asegura que la lógica sea testeable y desacoplada.