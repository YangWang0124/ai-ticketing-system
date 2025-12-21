using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Ticketing.Api.Domain.Entities;
using Ticketing.Api.Domain.Constants;
using Ticketing.Api.Infrastructure.Data;

namespace Ticketing.Api.Controllers;

[ApiController]
[Route("api/tickets")]
[Authorize]
public class TicketController : ControllerBase
{
    [HttpGet]
public IActionResult GetTickets()
{
    var role = User.FindFirstValue(ClaimTypes.Role);
    var email = User.FindFirstValue(ClaimTypes.Email);

    if (role == Roles.Agent || role == Roles.Admin)
    {
        // Agents & Admins see all tickets
        return Ok(
            TicketStore.Tickets
                .OrderByDescending(t => t.CreatedAt)
        );
    }

    // Customers only see their own
    var tickets = TicketStore.Tickets
        .Where(t => t.CreatedBy == email)
        .OrderByDescending(t => t.CreatedAt);

    return Ok(tickets);
}


    [HttpPost]
    [Authorize(Roles = Roles.Customer)]
    public IActionResult CreateTicket(Ticket request)
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        request.CreatedBy = email!;
        TicketStore.Tickets.Add(request);

        return Ok(request);
    }
}
