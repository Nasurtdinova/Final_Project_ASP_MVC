using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Project_ASP_MVC.Core;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_ASP_MVC.Controllers
{
    public class CompetitionController : Controller
    {
        public IActionResult Index()
        {
           var competitions = CompetitionStorage.competition;
            return View(competitions);
        }
    }
}
