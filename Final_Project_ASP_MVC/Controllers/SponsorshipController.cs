using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core;

namespace Final_Project_ASP_MVC.Controllers
{
    public class SponsorshipController : Controller
    {
        public IActionResult Index()
        {
            var sponsorships = SponsorshipStorage.sponsorships;
            return View(sponsorships);
        }

        public IActionResult IndexAdmin()
        {
            var sponsorships = SponsorshipStorage.sponsorships;
            return View(sponsorships);
        }
        public IActionResult IndexViewer()
        {
            var sponsorships = SponsorshipStorage.sponsorships;
            return View(sponsorships);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Sponsorship ship)
        {
            SponsorshipStorage.Add(ship);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            SponsorshipStorage.RemoveByName(id);
            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public IActionResult Update(int id)
        //{
        //    Result result = Connection.GetResultsId(id);
        //    return View(result);
        //}

        //[HttpPost]
        //public IActionResult Update(Result result)
        //{
        //    ResultStorage.Update(result);
        //    return RedirectToAction("Index");
        //}
    }
}
