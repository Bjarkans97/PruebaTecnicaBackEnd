using System.Net.Http.Json;
using PruebaTecnica.Entities;
using PruebaTecnica.DataLogic.Interfaces;

namespace PruebaTecnica.DataLogic.Clases;

public class EpisodiosDAL : IEpisodiosDAL
{
    private readonly IHttpClientFactory _httpClientFactory;

    public EpisodiosDAL(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<List<EpisodioEN>> ObtieneEpisodios(int page)
{
    var client = _httpClientFactory.CreateClient("RickAndMortyClient");

    // Pasamos el parámetro de página a la API externa
    var response = await client.GetFromJsonAsync<ApiResponse>($"episode?page={page}");

    return response?.Results.Select(r => new EpisodioEN
    {
        Id = r.Id,
        Name = r.Name,
        AirDate = r.Air_date,
        Characters = r.Characters,
        CharactersLinq = string.Join(",", r.Characters.Select(url => url.Split('/').Last())),
        EpisodeCode = r.Episode
    }).ToList() ?? new List<EpisodioEN>();
}

    public async Task<EpisodioEN> ObtieneEpisodioPorNum(int Episodio)
    {

        var client = _httpClientFactory.CreateClient("RickAndMortyClient");

        var episode = await client.GetFromJsonAsync<ApiEpisodio>($"episode/{Episodio}");

        if (episode == null) return null;

        return new EpisodioEN
        {
            Id = episode.Id,
            Name = episode.Name,
            AirDate = episode.Air_date,
            Characters = episode.Characters,
            CharactersLinq = string.Join(",", episode.Characters.Select(url => url.Split('/').Last())),
            EpisodeCode = episode.Episode
        };
    }

    public async Task<List<EpisodioEN>> ObtieneEpisodiosVarios(String ids)
    {

        var client = _httpClientFactory.CreateClient("RickAndMortyClient");
      
        var response = await client.GetFromJsonAsync<List<ApiEpisodio>>($"episode/{ids}");


        return response?.Select(r => new EpisodioEN
        {
            Id = r.Id,
            Name = r.Name,
            AirDate = r.Air_date,
            Characters = r.Characters,
            CharactersLinq = string.Join(",", r.Characters.Select(url => url.Split('/').Last())),
            EpisodeCode = r.Episode
        }).ToList() ?? new List<EpisodioEN>();
    }
}