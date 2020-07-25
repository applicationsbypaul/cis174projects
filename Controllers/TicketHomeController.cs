using System;
using System.Linq;
using cis174projects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cis174projects.Controllers
{
    public class TicketHomeController : Controller
    {
        private TicketContext context;
        public TicketHomeController(TicketContext ctx) => context = ctx;
        public IActionResult Index(string id)
        {
            var filters = new Filters(id);
            ViewBag.Filters = filters;
            ViewBag.Statuses = context.StatusesP.ToList();
            ViewBag.PointValueFilters = Filters.PointValueFilterValues;
            ViewBag.SprintNumberFilters = Filters.SprintNumberFilterValues;

            IQueryable<Ticket> query = context.TicketsP
                .Include(t => t.Status);
            if (filters.HasPointValue)
            {
                query = query.Where(t => t.PointValue == filters.PointValue);
            }
            if (filters.HasSprintNumber)
            {
                query = query.Where(t => t.SprintNumber == filters.SprintNumber);
            }
            if (filters.HasStatus)
            {
                query = query.Where(t => t.StatusId == filters.StatusId);
            }
            var tickets = query.OrderBy(t => t.StatusId).ToList();
            return View(tickets);
        }

        [HttpGet]
        public IActionResult Add()
        {
          
            ViewBag.Statuses = context.StatusesP.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                context.TicketsP.Add(ticket);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Statuses = context.StatusesP.ToList();
                return View(ticket);
            }
        }

        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            string id = string.Join('-', filter);
            return RedirectToAction("Index", new { ID = id });
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] string id, Ticket selected)
        {
            if (selected.StatusId == null)
            {
                context.TicketsP.Remove(selected);
            }
            else
            {
                string newStatusId = selected.StatusId;
                selected = context.TicketsP.Find(selected.Id);
                selected.StatusId = newStatusId;
                context.TicketsP.Update(selected);
            }
            context.SaveChanges();

            return RedirectToAction("Index", new { ID = id });
        }
    }
}
