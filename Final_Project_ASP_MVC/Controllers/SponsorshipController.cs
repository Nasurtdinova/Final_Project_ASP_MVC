using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core;
using Final_Project_ASP_MVC.Core;

namespace Final_Project_ASP_MVC.Controllers
{
    public class SponsorshipController : Controller
    {
        public IActionResult Index()
        {
            var sponsorships = ConnectionSponsorship.GetSponsorship(Connection.idUser);
            return View(sponsorships);
        }

        public IActionResult IndexAdmin()
        {
            var sponsorships = ConnectionSponsorship.GetSponsorshipViewerAdmin();
            return View(sponsorships);
        }
        public IActionResult IndexViewer()
        {
            var sponsorships = ConnectionSponsorship.GetSponsorshipViewerAdmin();
            return View(sponsorships);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Sponsorship sponship)
        {
            ConnectionSponsorship.AddSponsorship(sponship);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            ConnectionSponsorship.RemoveSponsorship(id);
            return RedirectToAction("Index");
        }
    }
}
