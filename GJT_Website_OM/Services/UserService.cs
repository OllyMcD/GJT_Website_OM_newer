using Microsoft.EntityFrameworkCore;
using GJT_Website_OM.Models; // Ensure you have a model for your users
using GJT_Website_OM.Utilities; // For password utilities


namespace GJT_Website_OM.Services
{
    public class UserService
    {
        private readonly TlS2303831GjtContext _context;

        public UserService(TlS2303831GjtContext context)
        {
            _context = context;
        }

        // Method to check if username already exists
        public async Task<bool> UsernameExistsAsync(string? username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return false; // Return false if username is null or empty
            }

            return await _context.Users.AnyAsync(u => u.Username == username);
        }

        // Add new user if the username does not already exist
        public async Task<bool> AddUserAsync(User user)
        {
            try
            {
                // Check if the username exists
                if (await UsernameExistsAsync(user.Username))
                {
                    return false; // Username already exists
                }

                // Hash the password before saving
                //user.Password = PasswordUtils.HashPassword(user.Password);

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                return true; // User successfully added
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Validate login credentials
        public async Task<bool> ValidateLoginAsync(string username, string password)
        {
            try
            {
                var customer = await _context.Users.FirstOrDefaultAsync(c => c.Username == username);
                if (customer != null)
                {

                    if (customer.Password == password)
                    {
                        return true; // Login successful
                    }
                }
                return false; // Login failed
            }
            catch (Exception)
            {
                Console.WriteLine("error");
                return false;
            }

        }

        #region hidden
        // Get user by username
        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
        #endregion

        // Delete user by username
        public async Task DeleteUserAsync(string username)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username);

            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("User not found.");
            }
        }

        // Delete user by id
        public async Task DeleteUserById(int userId)
        {
            _context.Users.RemoveRange(_context.Users.Where(u => u.UserId == userId));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserCertificates(int userId)
        {
            _context.Usercertificates.RemoveRange(_context.Usercertificates.Where(u => u.UserId == userId));
            await _context.SaveChangesAsync();
        }
    }
}
