using Final_Project_ASP_MVC.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class SportsmanController : ControllerBase
    {
        public SportsmanController() {}

        [HttpGet]
        public ActionResult<List<Sportsman>> GetAll() => Connection.GetSportsmans();

        [HttpGet("{id}")]
        public ActionResult<Sportsman> Get(int id)
        {
            var sportsman = Connection.GetSportsmansId(id);

            if (sportsman == null)
                return NotFound();

            return sportsman;
        }

        [HttpPost]
        public IActionResult Create(Sportsman sportsman)
        {
            Connection.AddSportsman(sportsman);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Sportsman sportsman)
        {
            if (id != sportsman.ID)
                return BadRequest();

            var existingProject = Connection.GetSportsmansId(id);
            if (existingProject is null)
                return NotFound();

            Connection.UpdateSportsman(sportsman);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var project = Connection.GetSportsmansId(id);

            if (project is null)
                return NotFound();

            Connection.RemoveSportsman(id);

            return NoContent();
        }
    }
}
