
namespace ContactManagement.Contract.Models
{
    public class Contact
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string City { get; set; }

        public bool IsActive { get; set; }
    }
}
