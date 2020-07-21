using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace cis174projects.Models
{
    public class Country
    {
        public string CountryID { get; set; }
        public string Name { get; set; } 
        public string SportID { get;  set; }
        public string SportName { get; set; }
        public Sport Sport{ get; set; }
       
        public string LogoImage { get; set; }

        public string GameID { get;  set; }
        public Game Game { get; set; }
       
    }
}
