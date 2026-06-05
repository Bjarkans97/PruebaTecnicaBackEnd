using PruebaTecnica.Entities;

namespace _PruebaTecnica.businessLogic.Interfaces
{
    public interface IPersonajesBLL
    {
        Task<List<PersonajesEN>> ObtienePersonajes();

        Task<PersonajesEN> ObtienePersonajePorID(int id);

        Task<List<PersonajesEN>> ObtienePersonajesVarios(String ids);
    }
}
