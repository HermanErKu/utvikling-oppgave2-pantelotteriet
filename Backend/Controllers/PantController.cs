using Backend.Data;
using Backend.DTOs;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PantController : ControllerBase
{
    private readonly AppDbContext _context;

    public PantController(AppDbContext context) => _context = context;

    [HttpGet]
    public IActionResult GetAll() => Ok(_context.PantedItems.ToList());

    [HttpPost]
    public IActionResult Create(PantCreateDto dto)
    {
        var pant = new Pant
        {
            UserId = dto.UserId,
            PantemaskinId = dto.PantemaskinId,
            PantAmount = dto.PantAmount,
            Date = DateTime.UtcNow
        };
        _context.PantedItems.Add(pant);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetAll), new { id = pant.Id }, pant);
    }
}
