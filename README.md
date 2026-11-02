# Rick and Morty BFF (Backend for Frontend)

[![CI](https://github.com/Bjarkans97/PruebaTecnicaBackEnd/actions/workflows/ci.yml/badge.svg)](https://github.com/Bjarkans97/PruebaTecnicaBackEnd/actions/workflows/ci.yml)

API en **.NET 8** que actúa como BFF entre el frontend y la [API pública de Rick and Morty](https://rickandmortyapi.com). Centraliza la lógica de negocio, el manejo de errores y la comunicación HTTP.

> Frontend que consume este BFF: [PruebaTecnicaFronEnd](https://github.com/Bjarkans97/PruebaTecnicaFronEnd)

## Flujo

```
Angular (SPA) ──HTTP──▶ BFF .NET 8 ──HttpClient──▶ rickandmortyapi.com
```

## Arquitectura

El proyecto sigue una estructura en capas para separar responsabilidades y aplicar los principios SOLID:

| Capa | Responsabilidad |
| :-- | :-- |
| `PruebaTecnica.Entities` | Modelos y contratos (POCOs) |
| `PruebaTecnica.DataLogic` | Acceso a datos: `HttpClient` hacia la API externa |
| `PruebaTecnica.businessLogic` | Lógica de negocio: procesa, valida y transforma la información |
| `PruebaTecnica.Api` | Web API: endpoints, middleware de errores y configuración |

## Tecnologías

- .NET 8 (C#)
- Middleware de manejo centralizado de excepciones (respuestas 404/500 estandarizadas)
- `HttpClientFactory` para gestionar conexiones HTTP
- Swagger/OpenAPI
- CORS configurado para el frontend

## Configuración

La URL de la API externa se define en `appsettings.json`:

```json
{
  "ExternalApis": {
    "RickAndMortyBaseUrl": "https://rickandmortyapi.com/api"
  },
  "AllowedHosts": "*"
}
```

## Cómo ejecutarlo

### Requisitos previos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- Visual Studio 2022 o VS Code (opcional)

### Desde la terminal

```bash
git clone https://github.com/Bjarkans97/PruebaTecnicaBackEnd.git
cd PruebaTecnicaBackEnd
dotnet run --project PruebaTecnica.Api
```

### Desde Visual Studio

1. Abre la solución `PruebaTecnicaCarsalesBFF.sln`.
2. Define `PruebaTecnica.Api` como proyecto de inicio.
3. Ejecuta con F5.

Swagger queda disponible en `http://localhost:5122/swagger`.

## Endpoints

| Método | Endpoint | Descripción |
| :-- | :-- | :-- |
| GET | `/api/Episodios` | Lista de episodios (`?page=n` para paginar) |
| GET | `/api/Episodios/{id}` | Detalle de un episodio |
| GET | `/api/Episodios/list/{ids}` | Varios episodios por IDs separados por coma |
| GET | `/api/Personajes` | Lista de personajes |
| GET | `/api/Personajes/{id}` | Detalle de un personaje |
| GET | `/api/Personajes/list/{ids}` | Varios personajes por IDs separados por coma |

Ejemplos:

```http
GET http://localhost:5122/api/Episodios?page=2
GET http://localhost:5122/api/Episodios/list/1,2,5
```

## Notas de implementación

- **Manejo de errores**: cualquier falla es capturada por `ErrorHandlingMiddleware`, que devuelve un JSON coherente.
- **Inyección de dependencias**: el uso de interfaces mantiene la lógica desacoplada y testeable.
