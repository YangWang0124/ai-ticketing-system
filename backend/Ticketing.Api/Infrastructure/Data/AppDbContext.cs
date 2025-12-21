using Microsoft.EntityFrameworkCore;
using Ticketing.Api.Domain.Entities;

namespace Ticketing.Api.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Ticket> Tickets => Set<Ticket>();
}
