using PruebaTecnica.Entities;
using PruebaTecnica.DataLogic.Interfaces;
using System.Net.Http.Json;

namespace PruebaTecnica.DataLogic.Clases
{
    public class PersonajesDAL : IPersonajesDAL
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public PersonajesDAL(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<PersonajesEN>> ObtienePersonajes()
        {

            var client = _httpClientFactory.CreateClient("RickAndMortyClient");

            var response = await client.GetFromJsonAsync<ApiResponsePersonaje>("character");


            return response?.Results.Select(r => new PersonajesEN
            {
                id = r.id,
                name = r.name,
                status = r.status,
                species = r.species,
                gender = r.gender,
                origin = r.origin,
                image = r.image,
                episode = r.episode

            }).ToList() ?? new List<PersonajesEN>();
        }

        public async Task<PersonajesEN> ObtienePersonajePorID(int id)
        {
            var client = _httpClientFactory.CreateClient("RickAndMortyClient");

            var response = await client.GetFromJsonAsync<PersonajesEN>($"character/{id}");

            if (response == null) return null;

            return new PersonajesEN
            {
                id = response.id,
                name = response.name,
                status = response.status,
                species = response.species,
                gender = response.gender,
                origin = response.origin,
                image = response.image,
                episode = response.episode
            };
        }

        public async Task<List<PersonajesEN>> ObtienePersonajesVarios(String ids)
        {

            var client = _httpClientFactory.CreateClient("RickAndMortyClient");

            var response = await client.GetFromJsonAsync<List<PersonajesEN>>($"character/{ids}");

            return response?.Select(r => new PersonajesEN
            {
                id = r.id,
                name = r.name,
                status = r.status,
                species = r.species,
                gender = r.gender,
                origin = r.origin,
                image = r.image,
                episode = r.episode

            }).ToList() ?? new List<PersonajesEN>();
        }
    }
}
