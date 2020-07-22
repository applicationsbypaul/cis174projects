using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public ViewResult Index(string activeGame = "all", string activeSport = "all")
        {
            var model = new CountryListViewModel
            {
                ActiveGame = activeGame,
                ActiveSport = activeSport,
                Games = context.Games.ToList(),
                Sports = context.Sports.ToList()
            };
            IQueryable<Country> query = context.Countries;
            if (activeGame != "all")
                query = query.Where(
                    t => t.Game.GameID.ToLower() == activeGame.ToLower());
            if (activeSport != "all")
                query = query.Where(
                    t => t.Sport.SportID.ToLower() == activeSport.ToLower());
            model.Countries = query.ToList();
            return View(model);
        }
        [HttpPost]
        public RedirectToActionResult Details (CountryViewModel model)
        {
            //Utility.LogCountryClick(model.Country.CountryID);
            TempData["ActiveGame"] = model.ActiveGame;
            TempData["ActiveSport"] = model.ActiveSport;
            return RedirectToAction("Details", new { ID = model.Country.CountryID });
        }
        [HttpGet]
        public ViewResult Details(string id)
        {
            var model = new CountryViewModel
            {
                Country = context.Countries
                .Include(t => t.Game)
                .Include(t => t.Sport)
                .FirstOrDefault(t => t.CountryID == id),
                ActiveGame = TempData.Peek("ActiveGame").ToString(),
                ActiveSport = TempData.Peek("ActiveSport").ToString()
            };
            return View(model);
        }
    }
}
