namespace GameStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string FullName { get; set; }

        public bool IsAdmin { get; set; }

        public IEnumerable<Order> Orders { get; set; } = new List<Order>();
    }
}
