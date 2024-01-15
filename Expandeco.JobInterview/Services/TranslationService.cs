using System.Linq;
using Expandeco.JobInterview.Data;
using Microsoft.EntityFrameworkCore;

namespace Expandeco.JobInterview.Services
{
    public interface ITranslationService
    {
        IQueryable<Translation> SelectForLoggedUser(LoggedUser loggedUser);
    }
    
    public class TranslationService : ITranslationService
    {
        private readonly ApplicationDbContext _dbContext;
        
        public TranslationService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public IQueryable<Translation> SelectForLoggedUser(LoggedUser loggedUser)
        {
            IQueryable<Translation> translations = _dbContext.Translations
                .Include(x => x.SourceLanguage)
                .Include(x => x.TargetLanguage)
                .Include(x => x.CreatedBy)
                .Include(x => x.AssignedTo);

            switch (loggedUser.TypeId)
            {
                case (int) UserTypeId.Customer:
                    translations = translations.Where(x => x.CreatedById == loggedUser.Id);
                    break;
                case (int) UserTypeId.Translator:
                    translations = translations.Where(x => x.AssignedToId == loggedUser.Id);
                    break;
            }

            return translations;
        }
    }
}
