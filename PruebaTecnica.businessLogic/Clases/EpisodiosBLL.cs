using PruebaTecnica.Entities;
using PruebaTecnica.DataLogic.Interfaces;
using _PruebaTecnica.businessLogic.Interfaces;
namespace _PruebaTecnica.businessLogic.Clases;

public class EpisodiosBLL : IEpisodiosBLL
{
    private readonly IEpisodiosDAL _dal;

    public EpisodiosBLL(IEpisodiosDAL dal)
    {
        _dal = dal;
    }

    public async Task<List<EpisodioEN>> ObtieneEpisodios(int page)
    {
        int pageToFetch = page < 1 ? 1 : page;

        return await _dal.ObtieneEpisodios(pageToFetch);
    }

    public async Task<EpisodioEN> ObtieneEpisodioPorNum(int Episodio)
    {
        if (Episodio <= 0)
            throw new ArgumentException("El número de episodio debe ser mayor a 0.");

        return await _dal.ObtieneEpisodioPorNum(Episodio);
    }

    public async Task<List<EpisodioEN>> ObtieneEpisodiosVarios(string ids)
    {
        if (string.IsNullOrWhiteSpace(ids))
            return new List<EpisodioEN>();

        return await _dal.ObtieneEpisodiosVarios(ids);
    }
}