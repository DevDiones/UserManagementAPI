using System.ComponentModel.DataAnnotations;
using UserManagementAPI.Data;

namespace UserManagementAPI.Dto
{
    public class CreateUserRequest
    {
        [Required] public required string Username { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public required string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")] public required string PasswordHash { get; set; }
        [Required] public required string FirstName { get; set; }
        [Required] public required string LastName { get; set; }
        [Required] public required string Role { get; set; }

        [DateValidation(ErrorMessage = "Date of Birth cannot be in the future.")]
        public DateOnly DateOfBirth { get; set; } = new DateOnly();
        public bool IsActive { get; set; } = true;
    }
}
