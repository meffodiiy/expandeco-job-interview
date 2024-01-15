using System.ComponentModel.DataAnnotations;

namespace Expandeco.JobInterview.Data
{
    public class Language
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }
    }
}
