
namespace ContactManagement.Domain.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Contact
    {
        [Display(Name = "Index")]
        public int ID { get; set; }

        [Required()]
        [StringLength(50)]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Must be character")]
        public string FirstName { get; set; }

        [Required()]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Must be character")]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be 10 digit")]
        [Display(Name = "Phone")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Must be character")]
        public string City { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }
    }
}
