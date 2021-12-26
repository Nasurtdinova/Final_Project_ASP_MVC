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
        public IActionResult Index()
        {
            var sportsmans = SportsmanStorage.sportsmans;
            return View(sportsmans);
        }

        public IActionResult Viewer()
        {
            var sportsmans = SportsmanStorage.sportsmans;
            return View(sportsmans);
        }

        public IActionResult Sponsor()
        {
            var sportsmans = SportsmanStorage.sportsmans;
            return View(sportsmans);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Sportsman sportsman)
        {
            SportsmanStorage.Add(sportsman);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            SportsmanStorage.RemoveByName(id);
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
            SportsmanStorage.Update(sportsman);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ViewerView(int id)
        {
            Sportsman sportsman = Connection.GetSportsmansId(id);
            return View(sportsman);
        }
    }
}
