using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CoreFramework;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_ASP_MVC.Controllers
{
    public class CommandsController : Controller
    {
        public IActionResult Index()
        {
            var commands = CommandStorage.commands;
            return View(commands);
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
        public IActionResult Add(Command command)
        {
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
