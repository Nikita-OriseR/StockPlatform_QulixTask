using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockPlatform.Application.StockPlatform.Commands.CreateAuthor;
using StockPlatform.Application.StockPlatform.Commands.DeleteAuthor;
using StockPlatform.Application.StockPlatform.Commands.UpdateAuthor;
using StockPlatform.WebApi.Models;
using System;
using System.Threading.Tasks;

namespace StockPlatform.WebApi.Controllers
{
    [ApiController]
    [Route("api/author")]
    public class AuthorController : BaseController
    {
        private readonly IMapper _mapper;

        public AuthorController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAuthorDto createAuthorDto)
        {
            var command = _mapper.Map<CreateAuthorCommand>(createAuthorDto);
            var authorId = await Mediator.Send(command);
            return Ok(authorId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAuthorDto updateAuthorDto)
        {
            var command = _mapper.Map<UpdateAuthorCommand>(updateAuthorDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteAuthorCommand
            {
                AuthorId = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
