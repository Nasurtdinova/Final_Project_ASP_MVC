using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Project_ASP_MVC.Core;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_ASP_MVC.Controllers
{
    public class SportsmansController : Controller
    {
        SportsmanStorage sportsmanStorage = SSCopy.sportsmanStorage;
        public IActionResult Index()
        {
            return View(sportsmanStorage);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Sportsman project)
        {
            sportsmanStorage.Add(project);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(string name)
        {
            sportsmanStorage.RemoveByName(name);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Sportsman sportsman)
        {
            sportsmanStorage.Update(sportsman);
            return RedirectToAction("Index");
        }
    }
}
