using System.ComponentModel.DataAnnotations;

namespace OData.Business.DomainClasses
{
    public class User
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
