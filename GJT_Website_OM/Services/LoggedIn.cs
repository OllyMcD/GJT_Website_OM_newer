namespace GJT_Website_OM.Services
{
    public class LoggedInService
    {
        public static bool isLoggedIn = false;
        public static string CurrentUsername { get; private set; } = string.Empty;

        // Logic for login, logout, and registration...
        public void Login(string username)
        {
            isLoggedIn = true;
            CurrentUsername = username;
        }

        public void Logout()
        {
            isLoggedIn = false;
            CurrentUsername = string.Empty;
        }
    }
}
