using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Project_ASP_MVC.Core;

namespace WebAPI_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CompetitionController : ControllerBase
    {
        public CompetitionController() { }

        [HttpGet]
        public ActionResult<List<Competition>> GetAll() => Connection.GetCompetition();

        [HttpGet("{id}")]
        public ActionResult<Competition> Get(int id)
        {
            var compet = Connection.GetCompetId(id);

            if (compet == null)
                return NotFound();

            return compet;
        }

        [HttpPost]
        public IActionResult Create(Competition compet)
        {
            Connection.AddCompetition(compet);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Competition competition)
        {
            if (id != competition.ID)
                return BadRequest();

            var existingCompet = Connection.GetCompetId(id);
            if (existingCompet is null)
                return NotFound();

            Connection.UpdateCompet(competition);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var compet = Connection.GetCompetId(id);

            if (compet is null)
                return NotFound();

            Connection.RemoveCompetition(id);

            return NoContent();
        }
    }
}
