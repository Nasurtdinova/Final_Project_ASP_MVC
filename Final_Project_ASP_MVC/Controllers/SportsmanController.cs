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
        public IActionResult Add(Sportsman sportsman)
        {
            sportsmanStorage.Add(sportsman);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            sportsmanStorage.RemoveByName(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Sportsman sportsman = Connection.GetSportsmansId(id);
            return View(sportsman);
        }

        [HttpPost]
        public IActionResult Update(Sportsman sportsman)
        {
            sportsmanStorage.Update(sportsman);
            return RedirectToAction("Index");
        }
    }
}
