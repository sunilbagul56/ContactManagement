
namespace ContactManagement.Storage.Repository
{
    using ContactManagement.Domain.Models;
    using ContactManagement.Storage.DbContexts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public sealed class ContactRepository : IContactRepository, IDisposable
    {
        #region Fields

        private readonly ContactDbContext _contactDbContext;

        #endregion

        #region Constructors

        public ContactRepository(ContactDbContext contactDbContext)
        {
            _contactDbContext = contactDbContext;
        }

        #endregion

        #region "Public methods"

        public IEnumerable<Contact> GetAllContacts()
        {
           return _contactDbContext.Contacts.ToList();
        }

        public Contact GetContactById(int id)
        {
            return _contactDbContext.Contacts.Where(c => c.ID == id).FirstOrDefault();
        }

        public async Task<bool> AddContactAsync(Contact contact)
        {
            _contactDbContext.Contacts.Add(contact);
            await _contactDbContext.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }
        public async Task<bool> UpdateContactAsync(Contact contact)
        {
            var contactToUpdate = GetContactById(contact.ID);
            contactToUpdate.FirstName = contact.FirstName;
            contactToUpdate.LastName = contact.LastName;
            contactToUpdate.Email = contact.Email;
            contactToUpdate.PhoneNumber = contact.PhoneNumber;
            contactToUpdate.City = contact.City;
            contactToUpdate.IsActive = contact.IsActive;
            await _contactDbContext.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }

        public async Task<bool> DeleteContactAsync(int id)
        {
            var contactToDelete = GetContactById(id);
            _contactDbContext.Contacts.Remove(contactToDelete);
            await _contactDbContext.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                _contactDbContext.Dispose();
            }
        }
    }

    #endregion
}
