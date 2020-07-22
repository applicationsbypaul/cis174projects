using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace cis174projects.Models
{
    public class CountryListViewModel : CountryViewModel
    {
        public List<Country> Countries { get; set; }
        public string ActiveGame { get; set; }
        public string ActiveSport { get; set; }

        //make next two properties standard properties so the setter
        //can make the first item in each list "All"
        private List<Game> games;
        public List<Game> Games
        {
            get => games;
            set
            {
                games = value;
                games.Insert(0, new Game { GameID = "all", Name = "All" });
            }
        }
        private List<Sport> sports;
        public List<Sport> Sports
        {
            get => sports;
            set
            {
                sports = value; ;
                sports.Insert(0, new Sport { SportID = "All", SportName = "All" });
            }
        }

        //methods to help view determine active link
        public string CheckActiveGame(string g) =>
            g.ToLower() == ActiveGame.ToLower() ? "active" : "";
        public string CheckActiveSport(string s) =>
            s.ToLower() == ActiveSport.ToLower() ? "active" : "";
    }
}
