using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Final_Project_ASP_MVC.Core;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_ASP_MVC.Controllers
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
        public IActionResult Add(Result result)
        {
            ResultStorage.Add(result);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int idCommand, int idCompetition)
        {
            Result result = ConnectionResults.GetResultsId(idCommand, idCompetition);
            return View(result);
        }

        [HttpPost]
        public IActionResult Update(Result result)
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
