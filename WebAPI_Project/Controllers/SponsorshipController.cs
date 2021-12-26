using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Final_Project_ASP_MVC.Core;
using Core;

namespace WebAPI_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class SponsorshipController : Controller
    {
        public SponsorshipController() { }

        [HttpGet]
        public ActionResult<List<Sponsorship>> GetAll() => ConnectionSponsorship.GetSponsorship();

        //[HttpGet("{id}")]
        //public ActionResult<Sponsorship> Get(int id)
        //{
        //    //var compet = ConnectionSponsorship.GetCompetId(id);

        //    if (compet == null)
        //        return NotFound();

        //    return compet;
        //}

        [HttpPost]
        public IActionResult Create(Sponsorship compet)
        {
            ConnectionSponsorship.AddSponsorship(compet);
            return NoContent();
        }

        //[HttpPut("{id}")]
        //public IActionResult Update(int id, Sponsorship competition)
        //{
        //    if (id != competition.ID)
        //        return BadRequest();

        //    var existingCompet = ConnectionCompetitions.GetCompetId(id);
        //    if (existingCompet is null)
        //        return NotFound();

        //    ConnectionCompetitions.UpdateCompet(competition);

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    //var compet = ConnectionSponsorship.(id);

        //    //if (compet is null)
        //    //    return NotFound();

        //    //ConnectionCompetitions.RemoveCompetition(id);

        //    //return NoContent();
        //}
    }
}
