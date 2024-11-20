using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly PasswordHasher<string> _passwordHasher;

    public UserController(ApplicationDbContext context)
    {
        _context = context;
        _passwordHasher = new PasswordHasher<string>();
    }

    // Crear usuario
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] User user)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        // Hash de la contraseña
        user.Password = _passwordHasher.HashPassword(user.Email, user.Password);

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }

    // Editar usuario
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] User updatedUser)
    {
        if (id != updatedUser.Id) return BadRequest("ID mismatch");

        var user = await _context.Users.FindAsync(id);
        if (user == null) return NotFound();

        user.Email = updatedUser.Email;

        // Actualizar hash de la contraseña
        user.Password = _passwordHasher.HashPassword(user.Email, updatedUser.Password);

        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // Verificar contraseña (opcional)
    [HttpPost("verify-password")]
    public IActionResult VerifyPassword(string email, string plainPassword)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);
        if (user == null) return NotFound("User not found");

        var result = _passwordHasher.VerifyHashedPassword(user.Email, user.Password, plainPassword);
        if (result == PasswordVerificationResult.Success)
            return Ok("Password is valid");
        else
            return Unauthorized("Invalid password");
    }
}
