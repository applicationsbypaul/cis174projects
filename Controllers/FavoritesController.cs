using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cis174projects.Models;
using Microsoft.AspNetCore.Mvc;

namespace cis174projects.Controllers
{
    public class FavoritesController : Controller
    {
        [HttpGet]
       public ViewResult Index()
        {
            var session = new CountrySession(HttpContext.Session);
            var model = new CountryListViewModel
            {
                ActiveGame = session.GetActiveGame(),
                ActiveSport = session.GetActiveSport(),
                Countries = session.GetMyCountries()
            };
            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Delete()
        {
            var session = new CountrySession(HttpContext.Session);
            session.RemoveMyCountries();

            TempData["message"] = "Favorite Countries cleared";

            return RedirectToAction("Index", "GamesHome",
                new
                {
                    ActiveGame = session.GetActiveGame(),
                    ActiveSport = session.GetActiveSport()
                });
        }

        public RedirectToActionResult Details()
        {
            return RedirectToAction("Index", "Favorites");
        }
    }
}
