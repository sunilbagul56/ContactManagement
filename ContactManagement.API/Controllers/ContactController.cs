
namespace ContactManagement.API.Controllers
{
    using ContactManagement.Contract.Models;
    using ContactManagement.Domain.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Serilog;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        #region Fields

        private readonly IContactEngine _contactEngine;

        #endregion

        /// <summary>
        /// Commitment State Controller
        /// </summary>
        #region Constructors

        public ContactController(IContactEngine contactEngine)
        {
            _contactEngine = contactEngine ?? throw new ArgumentNullException(nameof(contactEngine));
        }

        #endregion

        #region "Public methods"

        // GET: api/Contact/GetAllContacts
        [HttpGet]
        [Route("GetAllContacts")]
        public ActionResult<IEnumerable<Contact>> GetAllContacts()
        {
            try
            {
                Log.Information($"{nameof(ContactController)} - {nameof(GetAllContacts)}");
                var contact = _contactEngine.GetAllContacts();
                return Ok(contact);
            }
            catch (Exception e)
            {
                return BadRequest($"Invalid request {e.Message}");
            }
        }

        // GET: api/Contact/GetContactById/5
        [HttpGet]
        [Route("GetContactById")]
        public ActionResult<Contact> GetContactById(int id)
        {
            try
            {
                if (id > 0)
                {
                    Log.Information($"{nameof(ContactController)} - {nameof(GetContactById)} - Request- ContactId: {id}");
                    var contact = _contactEngine.GetContactById(id);
                    return Ok(contact);
                }
                else
                {
                    Log.Error($"Invalid contactId: {id}");
                    return BadRequest($"Invalid contactId: {id}");
                }
            }
            catch (Exception e)
            {
                Log.Error($"Exception occured for ContactId: {id} - Exception - {e.Message}");
                return BadRequest($"Invalid request {e.Message}");
            }
        }

        // POST: api/Contact/AddContact
        [HttpPost]
        [Route("AddContact")]
        public async Task<ActionResult<bool>> AddContactAsync(Domain.Models.Contact contact)
        {
            try
            {
                Log.Information($"{nameof(ContactController)} - {nameof(AddContactAsync)} - Contact: {Newtonsoft.Json.JsonConvert.SerializeObject(contact)}");
                return await _contactEngine.AddContactAsync(contact).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Log.Error($"Exception occured while saving contact- Exception: {e.Message}");
                return BadRequest($"Invalid request {e.Message}");
            }
        }

        // PUT: api/Contact/UpdateContact/5
        [HttpPut("{id}")]
        [Route("UpdateContact")]
        public async Task<ActionResult<bool>> UpdateContactAsync(Domain.Models.Contact contact)
        {
            try
            {
                Log.Information($"{nameof(ContactController)} - {nameof(UpdateContactAsync)} - Contact: {Newtonsoft.Json.JsonConvert.SerializeObject(contact)}");
                return await _contactEngine.UpdateContactAsync(contact).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Log.Error($"Exception occured while updating contact- Exception: {e.Message}");
                return BadRequest($"Invalid request {e.Message}");
            }
        }

        // DELETE: api/Contact/DeleteContact/5
        [HttpDelete]
        [Route("DeleteContact")]
        public async Task<ActionResult<bool>> DeleteContactAsync(int id)
        {
            try
            {
                if (id > 0)
                {
                    Log.Information($"{nameof(ContactController)} - {nameof(DeleteContactAsync)} - ContactId: {id}");
                    return await _contactEngine.DeleteContactAsync(id).ConfigureAwait(false);
                }
                else
                {
                    Log.Error($"Invalid contactId: {id}");
                    return BadRequest($"Invalid contactId: {id}");
                }
            }
            catch (Exception e)
            {
                Log.Error($"Exception occured while deleting contact- Exception: {e.Message}");
                return BadRequest($"Invalid request {e.Message}");
            }
        }

        #endregion
    }
}
