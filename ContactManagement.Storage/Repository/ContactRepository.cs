
namespace ContactManagement.Storage.Repository
{
    using ContactManagement.Domain.Models;
    using ContactManagement.Storage.DbContexts;
    using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Contact>> GetAllContactsAsync()
        {
           return await _contactDbContext.Contacts.ToListAsync().ConfigureAwait(false);
        }

        public async Task<Contact> GetContactByIdAsync(int id)
        {
            return await _contactDbContext.Contacts.Where(c => c.ID == id).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<bool> AddContactAsync(Contact contact)
        {
            _contactDbContext.Contacts.Add(contact);
            await _contactDbContext.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }
        public async Task<bool> UpdateContactAsync(Contact contact)
        {
            var contactToUpdate = await GetContactByIdAsync(contact.ID);
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
            var contactToDelete = await GetContactByIdAsync(id);
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
