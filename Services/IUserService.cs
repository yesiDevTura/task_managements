using TaskManager.Models;

namespace TaskManager.Services
{
    public interface IUserService
    {
        Task<User?> RegisterUserAsync(string name, string email, string password);  
        Task<User?> LoginUserAsync(string email, string password);  
        Task<User?> GetUserByIdAsync(int userId);
        Task<List<User>> GetAllUsersAsync();
    }
}