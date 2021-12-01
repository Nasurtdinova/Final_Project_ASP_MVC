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
        SportsmanStorage projectStorage = PSCope.sportsmanStorage;
        public IActionResult Index()
        {
            return View(projectStorage);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Final_Project_ASP_MVC.Core.Sportsman project)
        {

            projectStorage.Add(project);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(string name)
        {
            projectStorage.RemoveByName(name);
            return RedirectToAction("Index");
        }
    }
}
