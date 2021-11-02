using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockPlatform.Application.StockPlatform.Commands.CreatePhoto;
using StockPlatform.Application.StockPlatform.Commands.DeletePhoto;
using StockPlatform.Application.StockPlatform.Commands.UpdatePhoto;
using StockPlatform.Application.StockPlatform.Queries.GetPhotoDetails;
using StockPlatform.Application.StockPlatform.Queries.GetPhotoList;
using StockPlatform.WebApi.Models;
using System;
using System.Threading.Tasks;


namespace StockPlatform.WebApi.Controllers
{
    [ApiController]
    [Route("api/photo")]
    public class PhotoController : BaseController
    {
        private readonly IMapper _mapper;

        public PhotoController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PhotoListVm>> GetAll()
        {
            var query = new GetPhotoListQuery { };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PhotoDetailsVm>> Get(Guid id)
        {
            var query = new GetPhotoDetailsQuery
            {
                PhotoId = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePhotoDto createPhotoDto)
        {
            var command = _mapper.Map<CreatePhotoCommand>(createPhotoDto);
            var photoId = await Mediator.Send(command);
            return Ok(photoId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePhotoDto updatePhotoDto)
        {
            var command = _mapper.Map<UpdatePhotoCommand>(updatePhotoDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeletePhotoCommand
            {
                PhotoId = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
