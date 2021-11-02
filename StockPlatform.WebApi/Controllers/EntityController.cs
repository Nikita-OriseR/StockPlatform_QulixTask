using Microsoft.AspNetCore.Mvc;
using StockPlatform.Application.StockPlatform.Queries.GetEntityList;
using System.Threading.Tasks;

namespace StockPlatform.WebApi.Controllers
{
    [ApiController]
    [Route("api/entity")]
    public class EntityController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<EntitiesListVm>> GetAll()
        {
            var query = new GetEntitiesListQuery { };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
