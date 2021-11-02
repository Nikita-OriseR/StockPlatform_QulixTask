using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockPlatform.Application.StockPlatform.Commands.CreateText;
using StockPlatform.Application.StockPlatform.Commands.DeleteText;
using StockPlatform.Application.StockPlatform.Commands.UpdateText;
using StockPlatform.WebApi.Models;
using System;
using System.Threading.Tasks;

namespace StockPlatform.WebApi.Controllers
{
    [ApiController]
    [Route("api/text")]
    public class TextController : BaseController
    {
        private readonly IMapper _mapper;

        public TextController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTextDto createTextDto)
        {
            var command = _mapper.Map<CreateTextCommand>(createTextDto);
            var textId = await Mediator.Send(command);
            return Ok(textId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTextDto updateTextDto)
        {
            var command = _mapper.Map<UpdateTextCommand>(updateTextDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteTextCommand
            {
                TextId = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
