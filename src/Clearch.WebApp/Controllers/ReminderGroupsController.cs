using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Clearch.Application.Abstractions;
using Clearch.Application.Abstractions.Commands;
using Clearch.Application.ReminderGroups.Commands.AddReminderItem;
using Clearch.Application.ReminderGroups.Commands.Create;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clearch.WebApp.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class ReminderGroupsController : ControllerBase
    {
        private readonly ICommandSender commandSender;

        public ReminderGroupsController(ICommandSender commandSender)
        {
            this.commandSender = commandSender;
        }

        [HttpPost("")]
        public async Task<IResult> PostReminderGroup([FromBody] CreateReminderGroupCommand command)
        {
            return await this.commandSender.SendAsync(command).ConfigureAwait(false);
        }

        [HttpPost("reminderItems")]
        public async Task<IResult> PostReminderItem(AddReminderItemCommand command)
        {
            return await this.commandSender.SendAsync(command).ConfigureAwait(false);
        }
    }
}