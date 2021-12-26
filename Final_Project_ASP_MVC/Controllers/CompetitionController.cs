using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Project_ASP_MVC.Core;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_ASP_MVC.Controllers
{
    public class CompetitionController : Controller
    {
        public IActionResult Index()
        {
           var competitions = CompetitionStorage.competition;
            return View(competitions);
        }

        public IActionResult Viewer()
        {
            var competitions = CompetitionStorage.competition;
            return View(competitions);
        }

        public IActionResult Sponsor()
        {
            var competitions = CompetitionStorage.competition;
            return View(competitions);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Competition compet)
        {
            CompetitionStorage.Add(compet);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Competition competition = Connection.GetCompetId(id);
            return View(competition);
        }

        [HttpPost]
        public IActionResult Update(Competition compet)
        {
            CompetitionStorage.Update(compet);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            CompetitionStorage.RemoveByName(id);
            return RedirectToAction("Index");
        }
    }
}
