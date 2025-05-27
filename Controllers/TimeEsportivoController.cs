using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/times")]
[ApiController]
public class TimeEsportivoController : ControllerBase
{
    private readonly AppDbContext _context;

    public TimeEsportivoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TimeEsportivo>> GetTimes()
    {
        var times = _context.TimesEsportivos.ToList();
        
        if (times.Count == 0)
            return NotFound("Nenhum time encontrado no banco de dados.");

        return Ok(times);
    }

    [HttpGet("{id}")]
    public ActionResult<TimeEsportivo> GetTime(int id)
    {
        var time = _context.TimesEsportivos.Find(id);
        if (time == null)
            return NotFound($"Nenhum time encontrado com o ID {id}");

        return Ok(time);
    }

    [HttpPost]
    public ActionResult<TimeEsportivo> PostTime([FromBody] TimeEsportivo time)
    {
        if (time == null || string.IsNullOrEmpty(time.Nome) || time.NumeroJogadores <= 0)
            return BadRequest("Os dados do time são inválidos! Verifique os campos.");

        _context.TimesEsportivos.Add(time);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetTime), new { id = time.Id }, time);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTime(int id)
    {
        var time = _context.TimesEsportivos.Find(id);
        if (time == null)
            return NotFound($"Nenhum time encontrado com o ID {id}");

        _context.TimesEsportivos.Remove(time);
        _context.SaveChanges();

        return NoContent();
    }
}