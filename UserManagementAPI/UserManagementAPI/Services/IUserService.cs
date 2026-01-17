using UserManagementAPI.Dto;
using UserManagementAPI.Models;

namespace UserManagementAPI.Services
{
    public interface IUserService
    {
        public Task<List<User>> GetAllUsersAsync();
        public Task<User?> GetUserByIdAsync(int id);
        public Task<User?> CreateUserAsync(CreateUserRequest newUser);
        public Task<User?> UpdateUserAsync(int id, UpdateUserRequest updatedUser);
        public Task<bool> DeleteUserAsync(int id);
    }
}
