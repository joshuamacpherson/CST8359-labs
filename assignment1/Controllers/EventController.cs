using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EventController : Controller
    {
        private static List<Event> _events = new()
        {
            new Event { Id = 1, Title = "Tech Conference", Date = new DateTime(2026, 11, 10), Location = "Toronto" },
            new Event { Id = 2, Title = "Hackathon 2026", Date = new DateTime(2026, 12, 5), Location = "Ottawa" },
            new Event { Id = 3, Title = "Dev Meetup", Date = new DateTime(2027, 1, 15), Location = "Hamilton" },
        };

        public IActionResult Index()
        {
            return View(_events);
        }
        public IActionResult ManageAttendees(int id)
        {
            var ev = _events.FirstOrDefault(e => e.Id == id); // searches for event id 
            if (ev == null) return NotFound();

            ViewData["EventName"] = ev.Title;
            return View(ev);
        }

        [HttpPost]
        public IActionResult ManageAttendees(int id, Attendee attendee)
        {
            var ev = _events.FirstOrDefault(e => e.Id == id);
            if (ev == null) return NotFound();

            ev.Attendees.Add(attendee);

            return RedirectToAction("ManageAttendees", new { id });
        }
    }
}