using PruebaTecnica.Entities;

namespace PruebaTecnica.DataLogic.Interfaces;

public interface IEpisodiosDAL
{
    Task<List<EpisodioEN>> ObtieneEpisodios(int page);

    Task<EpisodioEN> ObtieneEpisodioPorNum(int Episodio);

    Task<List<EpisodioEN>> ObtieneEpisodiosVarios(String ids);
}