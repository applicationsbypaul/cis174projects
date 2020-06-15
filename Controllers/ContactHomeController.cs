using cis174projects.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace cis174projects.Controllers
{
    public class ContactHomeController : Controller
    {
        private ContactContext context { get; set; }
        public ContactHomeController(ContactContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            var contacts = context.Contacts.OrderBy(m => m.Name).ToList();
            return View(contacts);
        }
    }
}
