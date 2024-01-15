using System.ComponentModel.DataAnnotations;

namespace Expandeco.JobInterview.Data
{
    public class Translation
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Text { get; set; }

        public string TranslatedText { get; set; }
        
        [Required]
        public int SourceLanguageId { get; set; }
        
        [Required]
        public int TargetLanguageId { get; set; }
        
        [Required]
        public int CreatedById { get; set; }
        
        public int? AssignedToId { get; set; }

        public virtual Language SourceLanguage { get; set; }
        public virtual Language TargetLanguage { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual User AssignedTo { get; set; }
    }
}
