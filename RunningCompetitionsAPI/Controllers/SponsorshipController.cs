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
        public ActionResult<List<SponsorCommand>> GetAll() => ConnectionSponsorship.GetAcceptedRequest();

        [HttpGet("{id}")]
        public ActionResult<SponsorCommand> Get(int id)
        {
            var sponship = ConnectionSponsorship.GetSponsorshipId(id);

            if (sponship == null)
                return NotFound();

            return sponship;
        }
    }
}
