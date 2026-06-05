using PruebaTecnica.Entities;
using _PruebaTecnica.businessLogic.Clases;
using Microsoft.AspNetCore.Mvc;

namespace PruebaTecnicaCarsalesBFF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonajesController : ControllerBase
    {
        private readonly PersonajesBLL _bll;

        public PersonajesController(PersonajesBLL bll)
        {
            _bll = bll;
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonajesEN>>> GetAll()
        {
            var data = await _bll.ObtienePersonajes();
            return Ok(data);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PersonajesEN>> GetByID(int id)
        {
            var data = await _bll.ObtienePersonajePorID(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpGet("list/{ids}")]
        public async Task<ActionResult<List<PersonajesEN>>> GetByIDs(string ids)
        {
            var data = await _bll.ObtienePersonajesVarios(ids);
            return Ok(data);
        }
    }
}