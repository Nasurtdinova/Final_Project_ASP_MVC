using CoreFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ActionResult<ObservableCollection<Sportsman>> GetAll() => ConnectionSportsmans.GetSportsmans();

        [HttpGet("{id}")]
        public ActionResult<Sportsman> Get(int id)
        {
            var sportsman = ConnectionSportsmans.GetSportsmansId(id);

            if (sportsman == null)
                return NotFound();

            return sportsman;
        }

        [HttpPost]
        public IActionResult Create(Sportsman sportsman)
        {
            ConnectionSportsmans.AddSportsman(sportsman);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Sportsman sportsman)
        {
            if (id != sportsman.ID)
                return BadRequest();

            var existingSportsman = ConnectionSportsmans.GetSportsmansId(id);
            if (existingSportsman is null)
                return NotFound();

            ConnectionSportsmans.UpdateSportsman(sportsman);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var sportsman = ConnectionSportsmans.GetSportsmansId(id);

            if (sportsman is null)
                return NotFound();

            ConnectionSportsmans.RemoveSportsman(id);

            return NoContent();
        }
    }
}
