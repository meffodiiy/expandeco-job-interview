using Expandeco.JobInterview.Data;
using Expandeco.JobInterview.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using Microsoft.IdentityModel.Tokens;

namespace Expandeco.JobInterview.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TranslationsController : ControllerBase
    {
        private readonly ILogger<TranslationsController> _logger;
        private readonly ILoggedUserService _loggedUserService;
        private readonly ITranslationService _translationService;

        public TranslationsController(ILogger<TranslationsController> logger, ILoggedUserService loggedUserService,
            ITranslationService translationService)
        {
            _logger = logger;
            _loggedUserService = loggedUserService;
            _translationService = translationService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var loggedUser = _loggedUserService.Get();

            if (loggedUser == null)
                return Unauthorized();

            var translations = _translationService.SelectForLoggedUser(loggedUser);

            if (translations.IsNullOrEmpty())
                return NoContent();

            return Ok(translations.ToArray());
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var loggedUser = _loggedUserService.Get();
            
            if (loggedUser == null)
                return Unauthorized();

            var result = _translationService.SelectForLoggedUser(loggedUser)
                .FirstOrDefault(x => x.Id == id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}