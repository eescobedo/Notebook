using CrudNotebook.Data;
using CrudNotebook.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudNotebook.Controllers
{
    public class MaintenanceController : Controller
    {
        ContactData _contactData = new ContactData();

        public IActionResult ListContacts()
        {
            // Show all contacts

            var listContacts = _contactData.ListContacts();

            return View(listContacts);
        }
        
        public IActionResult Save()
        {
            // Save a new contact



            return View();
        }
        
        [HttpPost]        
        public IActionResult Save(ModelContact contact)
        {
            // Receive contact and save to database
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = _contactData.Save(contact);

            if (result)
            {
                return RedirectToAction("ListContacts");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Edit(int IdContact)
        {
            // Edit a contact
            var contact = _contactData.GetContact(IdContact);
            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(ModelContact contact)
        {
            // Receive contact and edit to database
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = _contactData.Edit(contact);

            if (result)
            {
                return RedirectToAction("ListContacts");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Delete(int IdContact)
        {
            // Delete contact
            var contact = _contactData.GetContact(IdContact);
            return View(contact);
        }

        [HttpPost]
        public IActionResult Delete(ModelContact contact)
        {
            // Receive contact and delete to database
            var result = _contactData.Delete(contact.IdContact);

            if (result)
            {
                return RedirectToAction("ListContacts");
            }
            else
            {
                return View();
            }
        }
    }
}
