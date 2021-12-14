using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Project_ASP_MVC.Core;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_ASP_MVC.Controllers
{
    public class CommandsController : Controller
    {
        CommandStorage commandStorage = CScopy.commandStorage;
        public IActionResult Index()
        {
            return View(commandStorage);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Command command)
        {
            commandStorage.Add(command);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            commandStorage.RemoveByName(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Command command = Connection.GetCommandsId(id);
            return View(command);
        }

        [HttpPost]
        public IActionResult Update(Command command)
        {
            commandStorage.Update(command);
            return RedirectToAction("Index");
        }
    }
}
