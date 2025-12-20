using Ticketing.Api.Domain.Entities;

namespace Ticketing.Api.Infrastructure.Data;

public static class TicketStore
{
    public static List<Ticket> Tickets = new();
}
