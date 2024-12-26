using Microsoft.AspNetCore.Mvc;
using MyHome.Api.Models;
using MyHome.Api.Data;


[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly MyHomDBContext _context;

    public UsersController(MyHomDBContext context)
    {
        _context = context;
    }

    // Create User
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return Ok(user);
    }

    // Get All Users
    [HttpGet]
    public IActionResult GetAllUsers()
    {
        var users = _context.Users.ToList();
        return Ok(users);
    }

    // Get User by ID
    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    // Query Users by Name
    [HttpGet("search")]
    public IActionResult SearchUsers([FromQuery] string name)
    {
        var users = _context.Users
            .Where(u => u.Name.Contains(name))
            .ToList();
        return Ok(users);
    }
}