using PruebaTecnica.Entities;

namespace _PruebaTecnica.businessLogic.Interfaces
{
    public interface IEpisodiosBLL
    {
        Task<List<EpisodioEN>> ObtieneEpisodios(int page);
        Task<EpisodioEN> ObtieneEpisodioPorNum(int Episodio);
        Task<List<EpisodioEN>> ObtieneEpisodiosVarios(String ids);
    }
}
