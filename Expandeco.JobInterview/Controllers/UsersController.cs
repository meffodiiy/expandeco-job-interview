using Expandeco.JobInterview.Data;
using Expandeco.JobInterview.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Expandeco.JobInterview.Data.DTO;

namespace Expandeco.JobInterview.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<UsersController> _logger;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;

        public UsersController(ApplicationDbContext dbContext, ILogger<UsersController> logger, IJwtService jwtService, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _jwtService = jwtService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _dbContext.Users.Include(x => x.Type).ToArray();
        }

        [HttpGet]
        [Route("Translators")]
        public IEnumerable<TranslatorDto> GetTranslators()
        {
            var users = _dbContext.Users.Where(x => x.TypeId == (int) UserTypeId.Translator);
            var translatorDtos = _mapper.Map<List<User>, List<TranslatorDto>>(users.ToList());
            return translatorDtos.ToArray();
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
