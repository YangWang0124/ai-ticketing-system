using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketing.Api.Domain.Entities;

public class TicketComment
{
    [Key]
    public int Id { get; set; }

    [Required]
    public Guid TicketId { get; set; }

    [ForeignKey(nameof(TicketId))]
    public Ticket Ticket { get; set; } = null!;

    [Required]
    public string Content { get; set; } = string.Empty;

    [Required]
    public string CreatedBy { get; set; } = string.Empty;

    [Required]
    public string CreatedByRole { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
