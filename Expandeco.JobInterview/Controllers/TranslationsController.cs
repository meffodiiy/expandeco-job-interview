using Expandeco.JobInterview.Data;
using Expandeco.JobInterview.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Expandeco.JobInterview.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TranslationsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<TranslationsController> _logger;
        private readonly ILoggedUserService _loggedUserService;

        public TranslationsController(ApplicationDbContext dbContext, ILogger<TranslationsController> logger, ILoggedUserService loggedUserService)
        {
            _dbContext = dbContext;
            _logger = logger;
            _loggedUserService = loggedUserService;
        }

        [HttpGet]
        public IEnumerable<Translation> Get()
        {
            var loggedUser = _loggedUserService.Get();

            return _dbContext.Translations
                .Include(x => x.SourceLanguage)
                .Include(x => x.TargetLanguage)
                .Include(x => x.CreatedBy)
                .Include(x => x.AssignedTo)
                .ToArray();
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var loggedUser = _loggedUserService.Get();

            var result = _dbContext.Translations
                .Include(x => x.SourceLanguage)
                .Include(x => x.TargetLanguage)
                .Include(x => x.CreatedBy)
                .Include(x => x.AssignedTo)
                .FirstOrDefault(x => x.Id == id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
