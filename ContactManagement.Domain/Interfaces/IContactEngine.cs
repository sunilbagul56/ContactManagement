
namespace ContactManagement.Domain.Interfaces
{
    using ContactManagement.Domain.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IContactEngine
    {
        Task<Contact> GetContactByIdAsync(int id);
        Task<IEnumerable<Contact>> GetAllContactsAsync();
        Task<bool> AddContactAsync(Contact contact);
        Task<bool> UpdateContactAsync(Contact contact);
        Task<bool> DeleteContactAsync(int id);
    }
}
