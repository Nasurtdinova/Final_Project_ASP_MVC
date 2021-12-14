using Final_Project_ASP_MVC.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project_ASP_MVC.Controllers
{
    public class CommandsViewer : Controller
    {
        CommandStorage commandStorage = CScopy.commandStorage;
        public IActionResult Index()
        {
            return View(commandStorage);
        }
    }
}
