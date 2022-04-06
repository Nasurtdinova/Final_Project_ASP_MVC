using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreFramework;

namespace WebAPI_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SponsorshipController : Controller
    {
        public SponsorshipController() { }

        [HttpGet]
        public ActionResult<List<SponsorCommand>> GetAll() => ConnectionSponsorship.GetSponsorshipViewerAdmin();

        [HttpGet("{id}")]
        public ActionResult<SponsorCommand> Get(int id)
        {
            var sponship = ConnectionSponsorship.GetSponsorshipId(id);

            if (sponship == null)
                return NotFound();

            return sponship;
        }

        [HttpPost]
        public IActionResult Create(SponsorCommand compet)
        {
            ConnectionSponsorship.AddSponsorshipApi(compet);
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
