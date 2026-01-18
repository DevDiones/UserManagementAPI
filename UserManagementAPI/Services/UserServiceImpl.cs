using Microsoft.EntityFrameworkCore;
using UserManagementAPI.Data;
using UserManagementAPI.Dto;
using UserManagementAPI.Models;

namespace UserManagementAPI.Services
{
    public class UserServiceImpl(AppDbContext context) : IUserService
    {
        public async Task<User?> CreateUserAsync(CreateUserRequest newUser)
        {
            try {
                var user = new User
                {
                    Username = newUser.Username,
                    Email = newUser.Email,
                    PasswordHash = newUser.PasswordHash,
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    Role = newUser.Role,
                    DateOfBirth = newUser.DateOfBirth,
                    DateCreated = DateOnly.FromDateTime(DateTime.UtcNow),
                    DateUpdated = DateOnly.FromDateTime(DateTime.UtcNow),
                    IsActive = newUser.IsActive,
                    IsDeleted = false
                };

                context.Users.Add(user);
                await context.SaveChangesAsync();

                return user;

            } catch (Exception ex) 
            { 
                var errorMessage = ex.Message;
                Console.WriteLine($"Error creating user: {errorMessage}");

                return null;
            }
           
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            try {
                var user = await context.Users.FindAsync(id);

                if (user == null)
                {
                    return false;
                }

                context.Users.Remove(user);

                await context.SaveChangesAsync();

                return true;
            } catch (Exception ex) 
            { 
                var errorMessage = ex.Message;
                Console.WriteLine($"Error deleting user: {errorMessage}");

                return false;
            }
           
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            try {  

                var users = await context.Users.Where(e => e.IsActive == true).ToListAsync();
                return users;

            } catch (Exception ex) 
            { 
                var errorMessage = ex.Message;
                Console.WriteLine($"Error retrieving users: {errorMessage}");
                return [];
            }
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            var user = await context.Users.FindAsync(id);

            if(user == null)
            {
                return null;
            }

            return user;
        }

        public async Task<User?> UpdateUserAsync(int id, UpdateUserRequest updatedUser)
        {
            try
            {

                var user = await context.Users.FindAsync(id);

                if (user == null)
                {
                    return null;
                }

                user.Username       = updatedUser.Username;
                user.Email          = updatedUser.Email;
                user.PasswordHash   = updatedUser.PasswordHash;
                user.FirstName      = updatedUser.FirstName;
                user.LastName       = updatedUser.LastName;
                user.Role           = updatedUser.Role;
                user.DateOfBirth    = updatedUser.DateOfBirth;
                user.IsActive       = updatedUser.IsActive;
                user.DateUpdated    = DateOnly.FromDateTime(DateTime.UtcNow);

                context.Users.Update(user);
                await context.SaveChangesAsync();

                return user;

            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message;
                Console.WriteLine($"Error updating user: {errorMessage}");
                return null;
            }
        }
    }
}
