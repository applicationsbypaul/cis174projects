/**************************************************************
* Name        : Person
* Author      : Paul Ford
* Created     : 5/30/2000
* Course      : CIS 174 Advance c#
* OS          : Windows 10
* Copyright   : This is my own original work based on
*               specifications issued by our instructor
* Description : Person class holds the attributes and the methods
*               needing to calculate the age.
* Academic Honesty: I attest that this is my original work.
* I have not used unauthorized source code, either modified or 
* unmodified. I have not given other fellow student(s) access to
* my program.
***************************************************************/
using System;
using System.ComponentModel.DataAnnotations;
namespace cis174projects.Models
{
    public class Person
    {
        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter the year that you were born in.")]
        [Range(1900, 2019, ErrorMessage = "Year of birth must be between 1900 and 2019")]
        public int? BirthYear { get; set; }

        public const int CurrentYear = 2020;

        /// <summary>
        /// Calculates the Age by 2020 DEC 31st
        /// </summary>
        /// <returns></returns>
        public int CalculateAge()
        {
            return CurrentYear - BirthYear.Value;
        }
    }
}
