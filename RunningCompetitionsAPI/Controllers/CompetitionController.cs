using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreFramework;
using System.Collections.ObjectModel;
//лишние библиотеки убрать
namespace WebAPI_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompetitionController : ControllerBase
    {
        public CompetitionController() { }

        [HttpGet]
        public ActionResult<ObservableCollection<Competition>> GetAll() => ConnectionCompetitions.GetCompetition();

        [HttpGet("{id}")]
        public ActionResult<Competition> Get(int id)
        {
            var compet = ConnectionCompetitions.GetCompetId(id);

            if (compet == null)
                return NotFound();

            return compet;
        }

        [HttpPost]
        public IActionResult Create(Competition compet)
        {
            ConnectionCompetitions.AddCompetition(compet);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Competition competition)
        {
            if (id != competition.idCompetition)
                return BadRequest();

            var existingCompet = ConnectionCompetitions.GetCompetId(id);
            if (existingCompet is null)
                return NotFound();

            ConnectionCompetitions.UpdateCompet(competition);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var compet = ConnectionCompetitions.GetCompetId(id);

            if (compet is null)
                return NotFound();

            ConnectionCompetitions.RemoveCompetition(id);

            return NoContent();
        }
    }
}
