using PruebaTecnica.Entities;
using _PruebaTecnica.businessLogic.Clases;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EpisodiosController : ControllerBase
{
    private readonly EpisodiosBLL _bll;

    public EpisodiosController(EpisodiosBLL bll)
    {
        _bll = bll;
    }

    [HttpGet]
public async Task<ActionResult<List<EpisodioEN>>> GetAll([FromQuery] int page = 1)
{
    var data = await _bll.ObtieneEpisodios(page);
    return Ok(data);
}

    [HttpGet("{id:int}")]
    public async Task<ActionResult<EpisodioEN>> GetById(int id)
    {
        var data = await _bll.ObtieneEpisodioPorNum(id);

        if (data == null) return NotFound();

        return Ok(data);
    }

    [HttpGet("list/{ids}")]
    public async Task<ActionResult<List<EpisodioEN>>> GetByIds(string ids)
    {
        var data = await _bll.ObtieneEpisodiosVarios(ids);
        return Ok(data);
    }
}