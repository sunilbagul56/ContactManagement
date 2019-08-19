
namespace ContactManagement.Storage.Repository
{
    using ContactManagement.Domain.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllContactsAsync();
        Task<Contact> GetContactByIdAsync(int id);
        Task<bool> AddContactAsync(Contact contact);
        Task<bool> UpdateContactAsync(Contact contact);
        Task<bool> DeleteContactAsync(int id);
    }
}
