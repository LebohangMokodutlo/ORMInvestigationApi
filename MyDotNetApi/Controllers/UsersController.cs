using Microsoft.AspNetCore.Mvc;
using MyDotNetApi.DTOs.UserDtos;
using MyDotNetApi.Models;
using MyDotNetApi.Services;
using System.Collections.Generic;

namespace MyDotNetApi.Controllers
{
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Users>> GetUsers()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<Users> GetUsersById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] CreateUserDto user)
        {
            if (_userService.AddUser(user))
            {
                return Ok();
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create user");
        }

        [HttpPut("{id}")]
        public IActionResult EditUser(int id, [FromBody] UpdateUserDto user)
        {
            if (_userService.EditUser(id, user))
            {
                return Ok();
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update user");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (_userService.DeleteUser(id))
            {
                return Ok();
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete user");
        }
    }
}
