using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoreFramework;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using RunningCompetitionsASP_MVC.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace RunningCompetitionsASP_MVC.Controllers
{
    public class CommandsController : Controller
    {
        public IActionResult Index()
        {
            var commands = ConnectionCommands.GetCommands();
            return View(commands);
        }

        public IActionResult Viewer()
        {
            var commands = ConnectionCommands.GetCommands();
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
            if (ModelState.IsValid)
            {
                ConnectionCommands.AddCommand(command);
                return RedirectToAction("Index");
            }
            else
            {
                return View(command);
            }
            
        }

        public IActionResult Remove(int id)
        {
            ConnectionCommands.RemoveCommand(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Command command = ConnectionCommands.GetCommandsId(id);                          
            return View(command);
        }

        [HttpGet]
        public IActionResult AttachImage(int id)
        {
            Command command = ConnectionCommands.GetCommandsId(id);
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
                ConnectionCommands.UpdateImageCommand(id, imageData);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Command command)
        {
            if (ModelState.IsValid)
            {
                ConnectionCommands.UpdateCommand(command);
                return RedirectToAction("Index");
            }
            else
            {
                return View(command);
            }
        }

        [HttpGet]
        public IActionResult SportsmanCommand(int id)
        {
            List<Sportsman> sportCom = ConnectionCommands.GetSporCom(id);
            return View(sportCom);
        }
    }
}
