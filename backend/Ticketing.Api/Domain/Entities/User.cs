namespace Ticketing.Api.Domain.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Email { get; set; } = "";
    public string Password { get; set; } = ""; // TEMP (hash later)
    public string Role { get; set; } = "Customer";
}
