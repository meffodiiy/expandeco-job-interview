using System.ComponentModel.DataAnnotations;

namespace Expandeco.JobInterview.Data
{
    public class UserType
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }
    }

    public enum UserTypeId
    {
        Manager = 1,
        Translator = 2,
        Customer = 3
    }
}
