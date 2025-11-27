using TaskManager.Models;

namespace TaskManager.Services
{
    public interface ISessionService
    {
        User? CurrentUser { get; set; }
        bool IsLoggedIn { get; }
        void Login(User user);
        void Logout();
    }
}