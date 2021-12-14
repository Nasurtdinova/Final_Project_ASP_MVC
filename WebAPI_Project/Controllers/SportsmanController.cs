using Final_Project_ASP_MVC.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Project.Service;

namespace WebAPI_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class SportsmanController : ControllerBase
    {
        public SportsmanController() {}
        [HttpGet]
        public ActionResult<List<Sportsman>> GetAll() => SportsmanService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Sportsman> Get(int id)
        {
            var sportsman = SportsmanService.Get(id);

            if (sportsman == null)
                return NotFound();

            return sportsman;
        }

        [HttpPost]
        public IActionResult Create(Sportsman sportsman)
        {
            SportsmanService.Add(sportsman);
            return CreatedAtAction(nameof(Create), new { id = sportsman.ID }, sportsman);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Sportsman sportsman)
        {
            if (id != sportsman.ID)
                return BadRequest();

            var existingProject = SportsmanService.Get(id);
            if (existingProject is null)
                return NotFound();

            SportsmanService.Update(sportsman);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var project = SportsmanService.Get(id);

            if (project is null)
                return NotFound();

            SportsmanService.Delete(id);

            return NoContent();
        }


    }
}
