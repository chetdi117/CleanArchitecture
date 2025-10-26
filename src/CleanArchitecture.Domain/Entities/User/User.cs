
using System.ComponentModel.DataAnnotations;


namespace CleanArchitecture.Domain.Entities.User
{
    public class User: EntityBase<string>
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
