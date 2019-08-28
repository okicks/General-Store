using System.ComponentModel.DataAnnotations;

namespace GeneralStore.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName => $"{FirstName} {LastName}";
    }
}