using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Project_ASP_MVC.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommandController : ControllerBase
    {
        public CommandController() { }

        [HttpGet]
        public ActionResult<List<Command>> GetAll() => Connection.GetCommands();

        [HttpGet("{id}")]
        public ActionResult<Command> Get(int id)
        {
            var command = Connection.GetCommandsId(id);

            if (command == null)
                return NotFound();

            return command;
        }

        [HttpPost]
        public IActionResult Create(Command command)
        {
            Connection.AddCommand(command);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Command command)
        {
            if (id != command.ID)
                return BadRequest();

            var existingCommand = Connection.GetCommandsId(id);
            if (existingCommand is null)
                return NotFound();

            Connection.UpdateCommand(existingCommand);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var command = Connection.GetCommandsId(id);

            if (command is null)
                return NotFound();

            Connection.RemoveCommand(id);

            return NoContent();
        }
    }
}
