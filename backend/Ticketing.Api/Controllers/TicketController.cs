using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Ticketing.Api.Domain.Entities;
using Ticketing.Api.Infrastructure.Data;

namespace Ticketing.Api.Controllers;

[ApiController]
[Route("api/tickets")]
[Authorize]
public class TicketController : ControllerBase
{
    [HttpGet]
    public IActionResult GetMyTickets()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        var tickets = TicketStore.Tickets
            .Where(t => t.CreatedBy == email)
            .OrderByDescending(t => t.CreatedAt);

        return Ok(tickets);
    }

    [HttpPost]
    public IActionResult CreateTicket(Ticket request)
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        request.CreatedBy = email!;
        TicketStore.Tickets.Add(request);

        return Ok(request);
    }
}
