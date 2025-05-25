using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/times")]
[ApiController]
public class TimesController : ControllerBase
{
    private readonly AppDbContext _context;

    public TimesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TimeEsportivo>>> GetTimes()
    {
        return await _context.Times.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TimeEsportivo>> GetTime(int id)
    {
        var time = await _context.Times.FindAsync(id);

        if (time == null)
        {
            return NotFound();
        }

        return time;
    }

    [HttpPost]
    public async Task<ActionResult<TimeEsportivo>> PostTime(TimeEsportivo time)
    {
        _context.Times.Add(time);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTime), new { id = time.Id }, time);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTime(int id)
    {
        var time = await _context.Times.FindAsync(id);

        if (time == null)
        {
            return NotFound();
        }

        _context.Times.Remove(time);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}