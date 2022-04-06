using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CoreFramework;
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
        public ActionResult<ObservableCollection<ResultCompetition>> GetAll() => ConnectionResults.GetResults();

        [HttpGet("{idCommand},{idCompetition}")]
        public ActionResult<ResultCompetition> Get(int idCommand, int idCompetition)
        {
            var result = ConnectionResults.GetResultsId(idCommand, idCompetition);

            if (result == null)
                return NotFound();

            return result;
        }

        [HttpPost]
        public IActionResult Create(ResultCompetition result)
        {
            if (ConnectionResults.isComCompetTrue(result.idCommand, result.idCompetition))
            {
                throw new Exception("!!!!");
            }
            else
            {
                ConnectionResults.AddResult(result);
            }
            return NoContent();
        }

        [HttpPut("{idCommand},{idCompetition}")]
        public IActionResult Update(int idCommand, int idCompetition, ResultCompetition result)
        {
            if (idCommand != result.idCommand && idCompetition != result.idCompetition)
                return BadRequest();

            var existingResult = ConnectionResults.GetResultsId(idCommand, idCompetition);
            if (existingResult is null)
                return NotFound();

            ConnectionResults.UpdateResult(result);

            return NoContent();
        }

        [HttpDelete("{idCommand},{idCompetition}")]
        public IActionResult Delete(int idCommand, int idCompetition)
        {
            var result = ConnectionResults.GetResultsId(idCommand, idCompetition);

            if (result is null)
                return NotFound();

            ConnectionResults.RemoveResult(idCommand, idCompetition);

            return NoContent();
        }
    }
}
