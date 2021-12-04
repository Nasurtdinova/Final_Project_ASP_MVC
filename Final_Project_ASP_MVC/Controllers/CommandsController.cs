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
    }
}
