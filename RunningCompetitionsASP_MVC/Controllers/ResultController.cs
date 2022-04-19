using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreFramework;
using Microsoft.AspNetCore.Mvc;

namespace RunningCompetitionsASP_MVC.Controllers
{
    public class ResultController : Controller
    {
        public IActionResult Index()
        {
            var results = ResultStorage.results;
            return View(results);
        }

        public IActionResult Viewer()
        {
            var results = ResultStorage.results;
            return View(results);
        }

        public IActionResult Sponsor()
        {
            var results = ResultStorage.results;
            return View(results);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ResultCompetition result)
        {
            if (ModelState.IsValid)
            {
                ResultStorage.Add(result);
                return RedirectToAction("Index");
            }
            else
            {
                return View(result);
            }
        }

        [HttpGet]
        public IActionResult Update(int idCommand, int idCompetition)
        {
            ResultCompetition result = ConnectionResults.GetResultsId(idCommand, idCompetition);
            return View(result);
        }

        [HttpPost]
        public IActionResult Update(ResultCompetition result)
        {
            ResultStorage.Update(result);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int idCommand, int idCompetition)
        {
            ResultStorage.RemoveByName(idCommand, idCompetition);
            return RedirectToAction("Index");
        }
    }
}
