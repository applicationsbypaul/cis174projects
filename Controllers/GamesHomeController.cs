using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cis174projects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

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
            //store selected selected games and sports ID's in a view bag
            ViewBag.ActiveGame = activeGame;
            ViewBag.ActiveSport = activeSport;

            //get list of games and sports from databse
            List<Game> games = context.Games.ToList();
            List<Sport> sports = context.Sports.ToList();

            //insert default "All" value at front of each list
            games.Insert(0, new Game { GameID = "all", Name = "All" });
            sports.Insert(0, new Sport { SportID = "all", SportName = "All" });

            //store lists in viewbag
            ViewBag.Games = games;
            ViewBag.sports = sports;

            //get coutnries - filter by game and category
            IQueryable<Country> query = context.Countries;
            if (activeGame != "all")
                query = query.Where(
                    t => t.Game.GameID.ToLower() == activeGame.ToLower());
            if (activeSport != "all")
                query = query.Where(
                    t => t.Sport.SportID.ToLower() == activeSport.ToLower());

            //pass teams to view as model
            var teams = query.ToList();
            return View(teams);
        }
    }
}
