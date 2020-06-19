using cis174projects.Models;
using Microsoft.AspNetCore.Mvc;

namespace cis174projects.Controllers
{
    public class PersonHomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Name = "";
            ViewBag.Age = "";
            return View();
        }
        /// <summary>
        /// Comfirms that the input is valid
        /// if not, set the variables to default. 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index(Person model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Name = model.Name;
                ViewBag.Age = model.CalculateAge();
            }
            else
            {
                ViewBag.Name = "";
                ViewBag.Age = "";
            }
            return View(model);
        }
    }
}

