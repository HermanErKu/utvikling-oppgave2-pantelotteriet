using Backend.Data;
using Backend.DTOs;
using Backend.Helpers;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PantemaskinController : ControllerBase
{
    private readonly AppDbContext _context;

    public PantemaskinController(AppDbContext context) => _context = context;

    [HttpGet]
    public IActionResult GetAll() => Ok(_context.Pantemaskiner.ToList());

    [HttpPost]
    public IActionResult Create(PantemaskinCreateDto dto)
    {
        if (!AdminApiKeyChecker.IsAdmin(Request))
            return Unauthorized("Admin API key required.");

        var machine = new Pantemaskin
        {
            Name = dto.Name,
            MaxPant = dto.MaxPant,
            CurrentPant = dto.CurrentPant,
            Area = dto.Area,
            Latitude = dto.Latitude,
            Longitude = dto.Longitude
        };

        _context.Pantemaskiner.Add(machine);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetAll), new { id = machine.Id }, machine);
    }
}
