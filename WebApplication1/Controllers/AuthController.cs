using auth.Helpers;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.DataTransfersObjects;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class AuthificateController : Controller
{

    private readonly IUserRepository _repository;
    private readonly JwtService _jwtService;

    public AuthificateController(IUserRepository repository,JwtService jwtService)
    {
        _repository = repository;
        _jwtService = jwtService;
    }
    [HttpPost]
    public IActionResult Register(RegisterDto dto)
    {
        User user = new User
        {
            name = dto.name,
            email = dto.email,
            password = BCrypt.Net.BCrypt.HashPassword(dto.password)
            
        };
        return Created("success", _repository.Create(user));
    }

    [HttpPost]
    public IActionResult Login(LoginDto dto)
    {
        User user = _repository.GetByEmail(dto.email);
        if (user.email != dto.email)
        {
            return BadRequest("invalid credentials");
        }
        
        if (!BCrypt.Net.BCrypt.Verify(dto.password,user.password))
        {
            return BadRequest("invalid credentials");
        }
        var jwt = _jwtService.Generate(user.id);

        Response.Cookies.Append("jwt", jwt, new CookieOptions
        {
            HttpOnly = true
        });

        return Ok(new
        {
            message = "success"
        });
        

    }
    [HttpGet("user")]
    public IActionResult User()
    {
        try
        {
            var jwt = Request.Cookies["jwt"];

            var token = _jwtService.Verify(jwt);

            int userId = int.Parse(token.Issuer);

            var user = _repository.GetById(userId);

            return Ok(user);
        }
        catch (Exception)
        {
            return Unauthorized();
        }
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("jwt");

        return Ok(new
        {
            message = "success"
        });
    }
}