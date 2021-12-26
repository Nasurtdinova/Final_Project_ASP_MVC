using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Final_Project_ASP_MVC.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResultController : ControllerBase
    {
        public ResultController() { }

        [HttpGet]
        public ActionResult<List<Result>> GetAll() => ConnectionResults.GetResults();

        [HttpGet("{id}")]
        public ActionResult<Result> Get(int id)
        {
            var result = ConnectionResults.GetResultsId(id);

            if (result == null)
                return NotFound();

            return result;
        }

        [HttpPost]
        public IActionResult Create(Result result)
        {
            ConnectionResults.AddResult(result);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Result result)
        {
            if (id != result.ID)
                return BadRequest();

            var existingResult = ConnectionResults.GetResultsId(id);
            if (existingResult is null)
                return NotFound();

            ConnectionResults.UpdateResult(existingResult);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = ConnectionResults.GetResultsId(id);

            if (result is null)
                return NotFound();

            ConnectionResults.RemoveResult(id);

            return NoContent();
        }
    }
}
