
namespace ContactManagement.Client.Controllers
{
    using ContactManagement.Client.Models;
    using ContactManagement.Domain.Models;
    using ContactManagement.MvcClient.Helper;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using Serilog;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class ContactController : Controller
    {
        #region Fields

        private const string CONTACT_BASE_URI = "http://localhost/ContactManagement.API/";

        #endregion

        #region Constructors
        public ContactController()
        {
        }

        #endregion

        #region "Public methods"
        // GET: Contact
        public async Task<IActionResult> Index()
        {
            Log.Information($"{nameof(ContactController)} - {nameof(Index)}");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(CONTACT_BASE_URI);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Response = await client.GetAsync("api/contact/GetAllContacts");

                //Check response status
                if (Response.IsSuccessStatusCode)
                {
                    var contactResponse = Response.Content.ReadAsStringAsync().Result;
                    var contacts = JsonConvert.DeserializeObject<List<Contact>>(contactResponse);
                    return View(contacts);
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        private async Task<Contact> GetContactByIDAsync(int contactId)
        {
            Log.Information($"{nameof(ContactController)} - {nameof(GetContactByIDAsync)}");

            Contact contacts = null;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new System.Uri(CONTACT_BASE_URI);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Response = await client.GetAsync("api/contact/GetContactById?Id=" + contactId);

                if (Response.IsSuccessStatusCode)
                {
                    var ResultSet = Response.Content.ReadAsStringAsync().Result;
                    contacts = JsonConvert.DeserializeObject<Contact>(ResultSet);
                }
                return contacts;
            }
        }

        //GET: Contact/Details
        public async Task<ActionResult> Details([FromRoute] int id)
        {
            var contact = await GetContactByIDAsync(id);
            if (contact == null)
            {
                Log.Information($"{nameof(ContactController)} - {nameof(Details)}- Contact not found");
                return NotFound();
            }
            return View(contact);
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        public async Task<ActionResult> Create(Contact contact)
        {
            Log.Information($"{nameof(ContactController)} - {nameof(Create)}");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri(CONTACT_BASE_URI);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage request = HttpRequestHelper.CreateHttpRequest(HttpMethod.Post, new System.Uri(CONTACT_BASE_URI + "api/Contact/AddContact"), contact);

                HttpResponseMessage Response = await client.SendAsync(request);

                if (Response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    Log.Information($"{nameof(ContactController)} - {nameof(Create)}- Create request failed");
                    ModelState.AddModelError(string.Empty, "Unable to add contact");
                    return BadRequest();
                }
            }
        }

        // GET: Contact/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Contact contact = await GetContactByIDAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        // POST: Contact/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Contact contact)
        {
            Log.Information($"{nameof(ContactController)} - {nameof(Edit)}");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri(CONTACT_BASE_URI);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage request = HttpRequestHelper.CreateHttpRequest(HttpMethod.Put, new System.Uri(CONTACT_BASE_URI + "api/Contact/UpdateContact"), contact);

                HttpResponseMessage Response = await client.SendAsync(request);

                if (Response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    Log.Information($"{nameof(ContactController)} - {nameof(Create)}- Update request failed");
                    ModelState.AddModelError(string.Empty, "Unable to update contact");
                    return BadRequest();
                }
            }
        }

        // GET: Contact/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Contact contact = await GetContactByIDAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteContact(int id)
        {
            Log.Information($"{nameof(ContactController)} - {nameof(DeleteContact)}");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new System.Uri(CONTACT_BASE_URI);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Response = await client.DeleteAsync("api/Contact/DeleteContact?id=" + id);

                if (Response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    Log.Information($"{nameof(ContactController)} - {nameof(DeleteContact)}- Delete request failed");
                    ModelState.AddModelError(string.Empty, "Delete request failed");
                    return BadRequest();
                }
            }
        }

        #endregion

        #region "Handle Error"
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
    }
}