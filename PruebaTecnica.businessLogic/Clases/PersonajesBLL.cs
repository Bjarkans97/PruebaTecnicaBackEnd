using PruebaTecnica.Entities;
using PruebaTecnica.DataLogic.Interfaces;
using _PruebaTecnica.businessLogic.Interfaces;

namespace _PruebaTecnica.businessLogic.Clases
{
    public class PersonajesBLL : IPersonajesBLL
    {
        private readonly IPersonajesDAL _dal;

        public PersonajesBLL(IPersonajesDAL dal)
        {
            _dal = dal;
        }

        public async Task<List<PersonajesEN>> ObtienePersonajes()
        {
            var personajes = await _dal.ObtienePersonajes();
            return personajes.OrderBy(p => p.name).ToList();
        }

        public async Task<PersonajesEN> ObtienePersonajePorID(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del personaje debe ser un número positivo.");

            return await _dal.ObtienePersonajePorID(id);
        }

        public async Task<List<PersonajesEN>> ObtienePersonajesVarios(string ids)
        {
            if (string.IsNullOrWhiteSpace(ids))
                return new List<PersonajesEN>();

            return await _dal.ObtienePersonajesVarios(ids);
        }
    }
}