
namespace ContactManagement.Test
{
    using ContactManagement.Domain.Models;

    public class BaseMockData
    {
        public Contact CreateContact()
        {
            return new Contact
            {
                FirstName = "Test",
                LastName = "Test",
                City = "Pune",
                Email = "test@info.com",
                PhoneNumber = "1234567891",
                IsActive = true
            };
        }
    }
}
