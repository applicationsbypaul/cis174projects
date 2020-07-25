using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cis174projects.Models
{
    public class Status
    {
        public string StatusId { get; set; }
        public string Name { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
