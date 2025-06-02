using Backend.Data;
using Backend.DTOs;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PantelotteriLoddController : ControllerBase
{
    private readonly AppDbContext _context;

    public PantelotteriLoddController(AppDbContext context) => _context = context;

    [HttpGet]
    public IActionResult GetAll() => Ok(_context.LotteryTickets.ToList());

    [HttpPost]
    public IActionResult Create(PantelotteriLoddCreateDto dto)
    {
        var lodd = new PantelotteriLodd
        {
            UserId = dto.UserId,
            PantId = dto.PantId,
            LotteriId = dto.LotteriId,
            PantemaskinId = dto.PantemaskinId,
            Barcode = dto.Barcode
        };

        _context.LotteryTickets.Add(lodd);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetAll), new { id = lodd.Id }, lodd);
    }
}
