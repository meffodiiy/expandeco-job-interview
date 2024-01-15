using System.ComponentModel.DataAnnotations;

namespace Expandeco.JobInterview.Data
{
    public class User
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        public int TypeId { get; set; }

        public virtual UserType Type { get; set; }
    }
}
