using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyDotNetApi.Data;
using MyDotNetApi.Models;

namespace MyDotNetApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserControllerEFCore : ControllerBase
    {
        private readonly DataContextEF _context;

        public UserControllerEFCore(DataContextEF context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetAllUsers()
        {
            var users = await _context.UsersTable.ToListAsync();
            return users;
        }
    }
}
