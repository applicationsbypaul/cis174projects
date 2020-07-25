using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace cis174projects.Models
{
    public class Filters
    {
        public Filters(string filterstring)
        {
            FilterString = filterstring ?? "all-all-all";
            string[] filters = FilterString.Split('-');
            SprintNumber = filters[0];
            PointValue = filters[1];
            StatusId = filters[2];
        }
        public string FilterString { get; }
        public string StatusId { get; }
        public string PointValue { get; }
        public string SprintNumber { get; }
        public bool HasPointValue => PointValue.ToLower() != "all";
        public bool HasSprintNumber => SprintNumber.ToLower() != "all";
        public bool HasStatus => StatusId.ToLower() != "all";

        public static Dictionary<string, string> PointValueFilterValues =>
            new Dictionary<string, string>
            {
                {"1" , "Low" },
                {"2" , "Medium" },
                {"3", "High" },
                {"4", "Emergency" }
            };

        public string isLow => PointValue.ToLower();
        public string isMedium => PointValue.ToLower();
        public string isHigh => PointValue.ToLower();
        public string isEmergency => PointValue.ToLower();

        public static Dictionary<string, string> SprintNumberFilterValues =>
            new Dictionary<string, string>
            {
                {"100", "Story" },
                {"200" , "Planning" },
                {"300", "Testing" },
                {"400", "Demo"}
            };

        public bool is100 => SprintNumber.ToLower() == "story";
        public bool is200 => SprintNumber.ToLower() == "planning";
        public bool is300 => SprintNumber.ToLower() == "testing";
        public bool is400 => SprintNumber.ToLower() == "demo";
       }
}
