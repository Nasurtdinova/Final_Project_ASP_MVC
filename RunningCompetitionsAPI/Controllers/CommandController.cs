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
    public class CommandController : ControllerBase
    {
        public CommandController() { }

        [HttpGet]
        public ActionResult<ObservableCollection<Command>> GetAll()
        {
            ObservableCollection<Command> commands = ConnectionCommands.GetCommands();
            foreach (var command in commands)
                command.Image = null;

            if (commands == null)
                return NoContent();

            return commands;
        }

        [HttpGet("{id}")]
        public ActionResult<Command> Get(int id)
        {
            var command = ConnectionCommands.GetCommandsId(id);

            if (command == null)
                return NotFound();

            return command;
        }

        [HttpPost]
        public IActionResult Create(Command command)
        {
            ConnectionCommands.AddCommand(command);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Command command)
        {
            if (id != command.idCommand)
                return BadRequest();

            var existingCommand = ConnectionCommands.GetCommandsId(id);
            if (existingCommand is null)
                return NotFound();

            ConnectionCommands.UpdateCommand(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var command = ConnectionCommands.GetCommandsId(id);

            if (command is null)
                return NotFound();

            ConnectionCommands.RemoveCommand(id);

            return NoContent();
        }
    }
}
