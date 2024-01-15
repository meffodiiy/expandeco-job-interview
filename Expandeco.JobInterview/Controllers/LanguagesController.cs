using Expandeco.JobInterview.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Expandeco.JobInterview.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LanguagesController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<LanguagesController> _logger;

        public LanguagesController(ApplicationDbContext dbContext, ILogger<LanguagesController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Language> Get()
        {
            return _dbContext.Languages.ToArray();
        }
    }
}
