using Backend.Data;
using Backend.DTOs;
using Backend.Helpers;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PantelotteriController : ControllerBase
{
    private readonly AppDbContext _context;

    public PantelotteriController(AppDbContext context) => _context = context;

    [HttpGet]
    public IActionResult GetAll() => Ok(_context.Pantelotterier.ToList());

    [HttpPost]
    public IActionResult Create(PantelotteriCreateDto dto)
    {
        if (!AdminApiKeyChecker.IsAdmin(Request))
            return Unauthorized("Admin API key required.");

        var lotteri = new Pantelotteri
        {
            DrawDate = dto.DrawDate,
            WinnerUserId = dto.WinnerUserId
        };

        _context.Pantelotterier.Add(lotteri);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetAll), new { id = lotteri.Id }, lotteri);
    }
}
