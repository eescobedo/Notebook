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
    }
}
