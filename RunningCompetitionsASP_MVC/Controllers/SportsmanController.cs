using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoreFramework;
using Microsoft.AspNetCore.Mvc;
using RunningCompetitionsASP_MVC.ViewModels;

namespace RunningCompetitionsASP_MVC.Controllers
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

        [HttpGet]
        public IActionResult AttachImage(int id)
        {
            Sportsman command = ConnectionSportsmans.GetSportsmansId(id);
            if (command == null)
                return NotFound();
            return View(command);
        }

        [HttpPost]
        public IActionResult AttachImage(int id, ImageViewModel pvm)
        {
            if (pvm.ImageData != null)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(pvm.ImageData.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)pvm.ImageData.Length);
                }
                ConnectionSportsmans.UpdateImageSportsman(id, imageData);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Add(Sportsman sportsman, ImageViewModel pvm)
        {          
            if (ModelState.IsValid)
            {
                if (pvm.ImageData != null)
                {
                    byte[] imageData = null;
                    using (var binaryReader = new BinaryReader(pvm.ImageData.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)pvm.ImageData.Length);
                    }
                    sportsman.Image = imageData;
                }
                SportsmanStorage.Add(sportsman);
                return RedirectToAction("Index");
            }
            else
            {
                return View(sportsman);
            }
        }

        public IActionResult Remove(int id)
        {
            SportsmanStorage.RemoveByName(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Sportsman sportsman = ConnectionSportsmans.GetSportsmansId(id);
            return View(sportsman);
        }

        [HttpPost]
        public IActionResult Update(Sportsman sportsman)
        {
            if (ModelState.IsValid)
            {
                SportsmanStorage.Update(sportsman);
                return RedirectToAction("Index");
            }
            else
            {
                return View(sportsman);
            }
        }

        [HttpGet]
        public IActionResult ViewerView(int id)
        {
            Sportsman sportsman = ConnectionSportsmans.GetSportsmansId(id);
            return View(sportsman);
        }
    }
}
