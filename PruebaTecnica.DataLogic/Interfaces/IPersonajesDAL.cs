using PruebaTecnica.Entities;

namespace PruebaTecnica.DataLogic.Interfaces
{
    public interface IPersonajesDAL
    {
        Task<List<PersonajesEN>> ObtienePersonajes();
        Task<PersonajesEN> ObtienePersonajePorID(int id);
        Task<List<PersonajesEN>> ObtienePersonajesVarios(String ids);
    }
}
