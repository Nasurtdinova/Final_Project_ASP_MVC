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
            var results = ConnectionResults.GetResults();
            return View(results);
        }

        public IActionResult Viewer()
        {
            var results = ConnectionResults.GetResults();
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
                if (!ConnectionResults.IsComCompetTrue(Convert.ToInt32(result.idCommand), Convert.ToInt32(result.idCompetition)))
                {
                    ModelState.AddModelError("", "Такие данные уже существуют");
                }
                else if (!ConnectionResults.IsRankTrue(Convert.ToInt32(result.Rank), Convert.ToInt32(result.idCompetition)))
                {
                    ModelState.AddModelError("", $"В соревновании такое место уже заняли");
                }               
                else
                {
                    ConnectionResults.AddResult(result);
                    return RedirectToAction("Index");
                }
            }
            return View(result);
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
            if (ModelState.IsValid)
            {
                if (!ConnectionResults.IsRankTrue(Convert.ToInt32(result.Rank), Convert.ToInt32(result.idCompetition)))
                {
                    ModelState.AddModelError("", $"В соревновании такое место уже заняли");
                }
                else if (!ConnectionResults.IsComCompetTrue(Convert.ToInt32(result.idCommand), Convert.ToInt32(result.idCompetition)))
                {
                    ModelState.AddModelError("", "Такие данные уже существуют");
                }
                else
                {
                    ConnectionResults.UpdateResult(result);
                    return RedirectToAction("Index");
                }                  
            }
            return View(result);
        }

        public IActionResult Remove(int idCommand, int idCompetition)
        {
            ConnectionResults.RemoveResult(idCommand, idCompetition);
            return RedirectToAction("Index");
        }
    }
}
