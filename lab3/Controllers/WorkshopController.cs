using lab3.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab3.Controllers
{
    public class WorkshopController : Controller
    {

        private static List<Rsvp> _registrations = new List<Rsvp>
    {
        new Rsvp { fullName = "Laughing", workshopTitle = "ASP.NET for Experts", needsAccommodation = false },
        new Rsvp { fullName = "Jeffery", workshopTitle = "Blazor Intro", needsAccommodation = true },
    };
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RsvpForm()
        {
            return View();
        }

        public IActionResult Confirm(Rsvp model)
        {
            _registrations.Add(model);
            ViewData["Message"] = $"Thanks for registering, {model.fullName}!";
            return View(model);
        }

        public IActionResult Registrations()
        {
            return View(_registrations);
        }
    }
}
