using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Dto;
using UserManagementAPI.Services;

namespace UserManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<UserResponse>> GetAllUserAsync()
        {
            try
            {
                var users = await service.GetAllUsersAsync();
                if (users.Count > 0)
                {
                    return Ok(users);
                }
                return NotFound("No users found.");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<ActionResult<UserResponse>> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await service.GetUserByIdAsync(id);
                if (user != null)
                {
                    return Ok(user);
                }
                return NotFound($"User with ID {id} not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<UserResponse>> CreateUserAsync([FromBody] CreateUserRequest newUser)
        {
            try
            {
                var createdUser = await service.CreateUserAsync(newUser);
                if (createdUser != null)
                {
                    return CreatedAtAction("GetUserById", new { id = createdUser.Id }, createdUser);
                }
                return BadRequest("Failed to create user.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserResponse>> UpdateUserAsync(int id, [FromBody] UpdateUserRequest updatedUser)
        {
            try
            {
                var user = await service.UpdateUserAsync(id, updatedUser);
                if (user != null)
                {
                    return Ok(user);
                }
                return NotFound($"User with ID {id} not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserAsync(int id)
        {
            try
            {
                var result = await service.DeleteUserAsync(id);
                if (result)
                {
                    return NoContent();
                }
                return NotFound($"User with ID {id} not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
