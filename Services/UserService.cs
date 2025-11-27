using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Models;
using BCrypt.Net;  // <- AGREGAR

namespace TaskManager.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> RegisterUserAsync(string name, string email, string password)
        {
            // Verificar si el email ya existe
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);

            if (existingUser != null)
                return null; // Email ya registrado

            // Hashear el password
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            var user = new User
            {
                Name = name,
                Email = email,
                PasswordHash = passwordHash,  // <- NUEVO
                CreatedAt = DateTime.Now
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

     public async Task<User?> LoginUserAsync(string email, string password)
{
    var user = await _context.Users
        .FirstOrDefaultAsync(u => u.Email == email);

    if (user == null)
    {
        Console.WriteLine("Usuario no encontrado");  // LOG
        return null;
    }

    Console.WriteLine($"Usuario encontrado: {user.Email}");  // LOG
    Console.WriteLine($"Password ingresado: {password}");  // LOG
    Console.WriteLine($"Hash almacenado: {user.PasswordHash}");  // LOG

    // Verificar el password
    bool isValidPassword = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
    
    Console.WriteLine($"Password válido: {isValidPassword}");  // LOG

    if (!isValidPassword)
    {
        Console.WriteLine("Password inválido");  // LOG
        return null;
    }

    Console.WriteLine("Login exitoso");  // LOG
    return user;
}
        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await _context.Users
                .Include(u => u.Tasks)
                .FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}