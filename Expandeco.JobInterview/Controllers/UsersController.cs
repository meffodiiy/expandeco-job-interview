using Expandeco.JobInterview.Data;
using Expandeco.JobInterview.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Expandeco.JobInterview.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<UsersController> _logger;
        private readonly IJwtService _jwtService;

        public UsersController(ApplicationDbContext dbContext, ILogger<UsersController> logger, IJwtService jwtService)
        {
            _dbContext = dbContext;
            _logger = logger;
            _jwtService = jwtService;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _dbContext.Users.Include(x => x.Type).ToArray();
        }

        [HttpPost("login")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Authenticate([FromQuery] int id)
        {
            string token = _jwtService.Authenticate(id);

            if (string.IsNullOrEmpty(token))
            {
                return BadRequest(new { message = "Invalid credentials" });
            }
            return Ok(token);
        }
    }
}
