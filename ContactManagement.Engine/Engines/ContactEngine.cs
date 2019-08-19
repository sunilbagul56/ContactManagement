﻿
namespace ContactManagement.Engine.Engines
{
    using ContactManagement.Domain.Interfaces;
    using ContactManagement.Domain.Models;
    using ContactManagement.Storage.Repository;
    using Serilog;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ContactEngine : IContactEngine
    {
        #region Fields

        private readonly IContactRepository _contactRepository;

        #endregion

        #region Constructors

        public ContactEngine(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
        }

        #endregion

        #region "Public methods"

        public async Task<IEnumerable<Contact>> GetAllContactsAsync()
        {
            try
            {
                return await _contactRepository.GetAllContactsAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Log.Information($"{nameof(ContactEngine)} - {nameof(GetAllContactsAsync)}- Unable to fetch cantacts- {ex.Message}");
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Contact> GetContactByIdAsync(int id)
        {
            try
            {
                return await _contactRepository.GetContactByIdAsync(id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Log.Information($"{nameof(ContactEngine)} - {nameof(GetContactByIdAsync)}- Unable to fetch cantact- {ex.Message}");
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> AddContactAsync(Contact contact)
        {
            try
            {
                return await _contactRepository.AddContactAsync(contact).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Log.Information($"{nameof(ContactEngine)} - {nameof(AddContactAsync)}- Unable to save cantact- {ex.Message}");
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> UpdateContactAsync(Contact contact)
        {
            try
            {
                return await _contactRepository.UpdateContactAsync(contact).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Log.Information($"{nameof(ContactEngine)} - {nameof(UpdateContactAsync)}- Unable to update cantact- {ex.Message}");
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> DeleteContactAsync(int id)
        {
            try
            {
                await _contactRepository.DeleteContactAsync(id).ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                Log.Information($"{nameof(ContactEngine)} - {nameof(DeleteContactAsync)}- Unable to save cantact- {ex.Message}");
                throw new Exception(ex.Message, ex);
            }
        }

        #endregion
    }
}
