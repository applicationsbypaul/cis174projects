using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cis174projects.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the name of the ticket")]

        // Allow up to 50 characters.
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,50}$",
         ErrorMessage = "Characters are not allowed.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a description.")]
        [StringLength(200)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter a Sprint Number.")]
        public string SprintNumber { get; set; }

        [Required(ErrorMessage = "Please enter a Point Value.")]
        public string PointValue { get; set; }

        [Required(ErrorMessage = "Please select a Status.")]
        public string StatusId { get; set; }
        public Status Status { get; set; }
    }
}
