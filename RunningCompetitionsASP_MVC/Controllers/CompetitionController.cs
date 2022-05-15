using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreFramework;
using Microsoft.AspNetCore.Mvc;

namespace RunningCompetitionsASP_MVC.Controllers
{
    public class CompetitionController : Controller
    {
        public IActionResult Index()
        {
           var compet = ConnectionCompetitions.GetCompetitions();
            return View(compet);
        }

        public IActionResult Viewer()
        {
            var compet = ConnectionCompetitions.GetCompetitions();
            return View(compet);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Competition compet)
        {
            if (ModelState.IsValid)
            {
                ConnectionCompetitions.AddCompetition(compet);
                return RedirectToAction("Index");
            }
            else
            {
                return View(compet);
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Competition competition = ConnectionCompetitions.GetCompetId(id);
            return View(competition);
        }

        [HttpPost]
        public IActionResult Update(Competition compet)
        {
            if (ModelState.IsValid)
            {
                ConnectionCompetitions.UpdateCompet(compet);
                return RedirectToAction("Index");
            }
            else
            {
                return View(compet);
            }
        }

        public IActionResult Remove(int id)
        {
            ConnectionCompetitions.RemoveCompetition(id);
            return RedirectToAction("Index");
        }
    }
}
