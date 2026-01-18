using System.ComponentModel.DataAnnotations;

namespace UserManagementAPI.Dto
{
    public class UpdateUserRequest
    {
        [Required] public int Id { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Role { get; set; }
        public DateOnly DateOfBirth { get; set; } = new DateOnly();
        public bool IsActive { get; set; } = true;

    }
}
