using System.Linq;
using AutoMapper;
using Expandeco.JobInterview.Data;
using Expandeco.JobInterview.Data.DTO;
using Microsoft.EntityFrameworkCore;

namespace Expandeco.JobInterview.Services
{
    public interface ITranslationService
    {
        IQueryable<Translation> SelectForLoggedUser(LoggedUser loggedUser);
        
        Translation FindOneForLoggedUser(int id, LoggedUser loggedUser);

        void Create(Translation translation);

        void Update(TranslationUpdateDto translationUpdateDto);
    }
    
    public class TranslationService : ITranslationService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        
        public TranslationService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        private IQueryable<Translation> GetFullTranslations()
        {
            return _dbContext.Translations
                .Include(x => x.SourceLanguage)
                .Include(x => x.TargetLanguage)
                .Include(x => x.CreatedBy)
                .Include(x => x.AssignedTo);
        }
        
        public IQueryable<Translation> SelectForLoggedUser(LoggedUser loggedUser)
        {
            var translations = GetFullTranslations();

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

        public Translation FindOneForLoggedUser(int id, LoggedUser loggedUser)
        {
            Translation translation;
            var translations = GetFullTranslations();
            
            switch (loggedUser.TypeId)
            {
                case (int) UserTypeId.Manager:
                    translation = translations.First(x => x.Id == id);
                    break;
                case (int) UserTypeId.Customer:
                    translation = translations.First(x => x.Id == id && x.CreatedById == loggedUser.Id);
                    break;
                case (int) UserTypeId.Translator:
                    translation = translations.First(x => x.Id == id && x.AssignedToId == loggedUser.Id);
                    break;
                default:
                    return null;
            }

            return translation;
        }

        public void Create(Translation translation)
        {
            _dbContext.Add(translation);
            _dbContext.SaveChanges();
        }

        public void Update(TranslationUpdateDto translationUpdateDto)
        {
            var translation = _dbContext.Find<Translation>(translationUpdateDto.Id);
            translation = _mapper.Map(translationUpdateDto, translation);
            
            _dbContext.Update(translation);
            _dbContext.SaveChanges();
        }
    }
}
