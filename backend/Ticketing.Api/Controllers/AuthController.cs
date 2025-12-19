using Microsoft.AspNetCore.Mvc;
using Ticketing.Api.Application.Services;
using Ticketing.Api.Domain.Entities;
using Ticketing.Api.Infrastructure.Data;

namespace Ticketing.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly JwtService _jwtService;

    public AuthController(JwtService jwtService)
    {
        _jwtService = jwtService;
    }

    [HttpPost("register")]
    public IActionResult Register(User request)
    {
        if (UserStore.Users.Any(u => u.Email == request.Email))
            return BadRequest("User already exists");

        UserStore.Users.Add(request);
        return Ok("User registered");
    }

    [HttpPost("login")]
    public IActionResult Login(User request)
    {
        var user = UserStore.Users
            .FirstOrDefault(u => u.Email == request.Email && u.Password == request.Password);

        if (user == null)
            return Unauthorized("Invalid credentials");

        var token = _jwtService.GenerateToken(user);
        return Ok(new { token });
    }
}
