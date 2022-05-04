using CoreFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunningCompetitionsASP_MVC.Controllers
{
    public class SponsorshipController : Controller
    {
        public IActionResult Index()
        {
            var sponsorships = ConnectionSponsorship.GetAcceptedRequest();
            return View(sponsorships);
        }
        public IActionResult IndexAdmin()
        {
            var sponsorships = ConnectionSponsorship.GetAcceptedRequest();
            return View(sponsorships);
        }
    }
}
