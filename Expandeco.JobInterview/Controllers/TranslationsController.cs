using Expandeco.JobInterview.Data;
using Expandeco.JobInterview.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using Expandeco.JobInterview.Data.DTO;
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

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var loggedUser = _loggedUserService.Get();
            
            if (loggedUser == null)
                return Unauthorized();

            var result = _translationService.FindOneForLoggedUser(id, loggedUser);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromForm] Translation translation)
        {
            var loggedUser = _loggedUserService.Get();
            
            if (loggedUser == null)
                return Unauthorized();
            
            translation.CreatedById = loggedUser.Id;

            try
            {
                _translationService.Create(translation);
            }
            catch (DbUpdateException e)
            {;
                const string errorMessage = "Failed to add translation";
                _logger.LogError(errorMessage + ": " + e.Message);
                
                return Problem(errorMessage);
            }
            
            return Ok();
        }
        
        [HttpPatch]
        [Route("update")]
        public IActionResult Update([FromForm] TranslationUpdateDto translationUpdateDto)
        {
            var loggedUser = _loggedUserService.Get();
            
            if (loggedUser == null)
                return Unauthorized();

            if (loggedUser.TypeId == (int) UserTypeId.Customer)
                return Forbid();

            try
            {
                _translationService.Update(translationUpdateDto);
            }
            catch (DbUpdateException e)
            {;
                const string errorMessage = "Failed to update translation";
                _logger.LogInformation(errorMessage + ": " + e.Message);
                
                return Problem(errorMessage);
            }
            
            return Ok();
        }
    }
}