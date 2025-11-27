using TaskManager.Models;

namespace TaskManager.Services
{
    public class SessionService : ISessionService
    {
        public User? CurrentUser { get; set; }
        public bool IsLoggedIn => CurrentUser != null;

        public void Login(User user)
        {
            CurrentUser = user;
        }

        public void Logout()
        {
            CurrentUser = null;
        }
    }
}