using Texts.API.Application.Commands;
using Texts.API.Application.Commands.DeleteText;
using Texts.API.Application.Commands.UpdateText;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Texts.API.Application.Commands.CreateText;

namespace Texts.API.Controllers
{
    public class TextController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateTextCommand command)
        {
            var textId = await Mediator.Send(command);

            return Ok(textId); 
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update(UpdateTextCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteTextCommand { TextId = id });

            return NoContent();
        }
    }
}