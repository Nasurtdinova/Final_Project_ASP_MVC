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
        public ActionResult<List<Sponsorship>> GetAll() => ConnectionSponsorship.GetSponsorshipViewerAdmin();

        //[HttpGet("{id}")]
        //public ActionResult<Sponsorship> Get(int id)
        //{
        //    //var sponship = ConnectionSponsorship.GetCompetId(id);

        //    if (sponship == null)
        //        return NotFound();

        //    return compet;
        //}

        [HttpPost]
        public IActionResult Create(Sponsorship compet)
        {
            ConnectionSponsorship.AddSponsorship(compet);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var sponship = ConnectionSponsorship.GetSponsorshipId(id);

            if (sponship is null)
                return NotFound();

            ConnectionSponsorship.RemoveSponsorship(id);

            return NoContent();
        }
    }
}
