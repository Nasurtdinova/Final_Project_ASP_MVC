using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoreFramework;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using RunningCompetitionsASP_MVC.ViewModels;

namespace RunningCompetitionsASP_MVC.Controllers
{
    public class CommandsController : Controller
    {
        public IActionResult Index()
        {
            var commands = CommandStorage.commands;
            return View(commands);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Images pic,ImageViewModel pvm)
        {
            Images person = new Images {  FileName = pvm.FileName };
            if (pvm.ImageData != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(pvm.ImageData.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)pvm.ImageData.Length);
                    //imagePath = pvm.ImageData.OpenReadStream().Read((int)pvm.ImageData.Length);
                }
                // установка массива байтов
                //person.ImagePath = imagePath;
                person.ImageData = imageData;
                Connection.AddImages(person);

                return RedirectToAction("Add");
            }            
            return View();
            //return View(pic);
        }

        public IActionResult Viewer()
        {
            var commands = CommandStorage.commands;
            return View(commands);
        }

        public IActionResult Sponsor()
        {
            var commands = CommandStorage.commands;
            return View(commands);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Command command, ImageViewModel pvm)
        {
            if (pvm.ImageData != null)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(pvm.ImageData.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)pvm.ImageData.Length);
                }
                command.Image = imageData;
            }
            CommandStorage.Add(command);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            CommandStorage.RemoveByName(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Command command = ConnectionCommands.GetCommandsId(id);
            return View(command);
        }

        [HttpPost]
        public IActionResult Update(Command command)
        {
            CommandStorage.Update(command);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult SportsmanCommand(int id)
        {
            List<Sportsman> sportCom = ConnectionCommands.GetSporCom(id);
            return View(sportCom);
        }
    }
}
