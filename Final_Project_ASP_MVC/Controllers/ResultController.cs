using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
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

        public IActionResult Remove(int idResult)
        {
            ResultStorage.RemoveByName(idResult);
            return RedirectToAction("Index");
        }
    }
}
