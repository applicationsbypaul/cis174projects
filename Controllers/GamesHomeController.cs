using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cis174projects.Migrations.Country;
using cis174projects.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.IdentityModel.Tokens;

namespace cis174projects.Controllers
{
    public class GamesHomeController : Controller
    {
        private CountryContext context;

        public GamesHomeController(CountryContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index(CountryListViewModel model)
        {
            model.Games = context.Games.ToList();
            model.Sports = context.Sports.ToList();



            IQueryable<Country> query = context.Countries;
            if (model.ActiveGame != "all")
                query = query.Where(
                    t => t.Game.GameID.ToLower() == model.ActiveGame.ToLower());
            if (model.ActiveSport != "all")
                query = query.Where(
                    t => t.Sport.SportID.ToLower() == model.ActiveSport.ToLower());
            model.Countries = query.ToList();
            return View(model);
        }
        [HttpPost]
        public RedirectToActionResult Details(CountryViewModel model)
        {
            //Utility.LogCountryClick(model.Country.CountryID);
            TempData["ActiveGame"] = model.ActiveGame;
            TempData["ActiveSport"] = model.ActiveSport;
            return RedirectToAction("Details", new { ID = model.Country.CountryID });
        }
        [HttpGet]
        public ViewResult Details(string id)
        {
            var session = new CountrySession(HttpContext.Session);
            var model = new CountryViewModel
            {
                Country = context.Countries
                .Include(t => t.Game)
                .Include(t => t.Sport)
                .FirstOrDefault(t => t.CountryID == id),
                ActiveGame = session.GetActiveGame(),
                ActiveSport = session.GetActiveSport()
            };
            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Add(CountryViewModel model)
        {
            model.Country = context.Countries
                .Include(t => t.Game)
                .Include(t => t.Sport)
                .Where(t => t.CountryID == model.Country.CountryID)
                .FirstOrDefault();

            var session = new CountrySession(HttpContext.Session);
            var countries = session.GetMyCountries();
            countries.Add(model.Country);
            session.SetMyCountries(countries);

            TempData["message"] = $"{model.Country.Name} added to your favorites";

            return RedirectToAction("Index",
                new
                {
                    ActiveGame = session.GetActiveGame(),
                    ActiveSport = session.GetActiveSport()
                });
        }
    }
}
