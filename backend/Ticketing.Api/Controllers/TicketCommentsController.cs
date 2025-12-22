using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Ticketing.Api.Domain.Entities;
using Ticketing.Api.Infrastructure.Data;

namespace Ticketing.Api.Controllers;

[ApiController]
[Route("api/tickets/{ticketId}/comments")]
[Authorize]
public class TicketCommentsController : ControllerBase
{
    private readonly AppDbContext _db;

    public TicketCommentsController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetComments(int ticketId)
    {
        var comments = await _db.TicketComments
            .Where(c => c.TicketId == ticketId)
            .OrderBy(c => c.CreatedAt)
            .ToListAsync();

        return Ok(comments);
    }

    [HttpPost]
    public async Task<IActionResult> AddComment(int ticketId, [FromBody] string content)
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        var role = User.FindFirstValue(ClaimTypes.Role);

        if (string.IsNullOrWhiteSpace(content))
            return BadRequest("Comment cannot be empty");

        var comment = new TicketComment
        {
            TicketId = ticketId,
            Content = content,
            CreatedBy = email!,
            CreatedByRole = role!
        };

        _db.TicketComments.Add(comment);
        await _db.SaveChangesAsync();

        return Ok(comment);
    }
}
