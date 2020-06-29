using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cis174projects.Models;
using Microsoft.AspNetCore.Mvc;

namespace cis174projects.Controllers
{
    public class StudentHomeController : Controller
    {

        public IActionResult Index()
        {
            Student Paul = new Student("Paul","Ford","A-");
            Student Trevor = new Student("Trevor", "Miller", "B-");
            Student Shane = new Student("Shane", "Blum", "C+");
            Student Amber = new Student("Amber", "Wells", "A");

            var students = new List<Student> 
            { Paul, Trevor, Shane, Amber};
            
            return View(students);
        }

        public IActionResult Detail(int id)
        {
            return View();
        }
    }
}
