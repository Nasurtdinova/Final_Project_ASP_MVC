using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Project_ASP_MVC.Core;
using WebAPI_Project.Service;

namespace WebAPI_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CompetitionController : ControllerBase
    {
        public CompetitionController() { }

        [HttpGet]
        public ActionResult<List<Competition>> GetAll() => CompetitionService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Competition> Get(int id)
        {
            var compet = CompetitionService.Get(id);

            if (compet == null)
                return NotFound();

            return compet;
        }

        [HttpPost]
        public IActionResult Create(Competition compet)
        {
            CompetitionService.Add(compet);
            return NoContent();
            //return CreatedAtAction(nameof(Create), new { id = compet.ID }, compet);
        }
    }
}
