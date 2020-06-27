using ERP.API.Filters;
using ERP.Domain.Mediator.Queries;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using ERP.Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RiskFirst.Hateoas;
using System;
using System.Threading.Tasks;

namespace ERP.API.V1.Controllers
{
    /// <summary>
    /// ItemsHateoasController
    /// </summary>
    [Route("api/hateoas/items")]
    [ApiController]
    [JsonException]
    public class ItemsHateoasController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly ILinksService _linksService;
        private readonly IMediator _mediator;

        /// <summary>
        /// ItemsHateoasController
        /// </summary>
        /// <param name="linkService"></param>
        /// <param name="itemService"></param>
        /// <param name="mediator"></param>
        public ItemsHateoasController(ILinksService linkService, IItemService itemService, IMediator mediator)
        {
            _linksService = linkService;
            _itemService = itemService;
            _mediator = mediator;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="_pageSize"></param>
        /// <param name="_pageIndex"></param>
        /// <returns></returns>
        [HttpGet(Name = nameof(Get))]
        public async Task<IActionResult> Get([FromQuery] int _pageSize = 10, [FromQuery] int _pageIndex = 0)
        {
            GetAllItemsHateoasQuery query = new GetAllItemsHateoasQuery(new GetAllItemRequest { PageIndex = _pageIndex, PageSize = _pageSize });
            ApiResult<HateoasResponse<ItemResponse>> result = await _mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}", Name = nameof(GetById))]
        [ItemExists]
        public async Task<IActionResult> GetById(Guid id)
        {
            ItemResponse result = await _itemService.GetItemAsync(id);
            HateoasResponse<ItemResponse> hateoasResult = new HateoasResponse<ItemResponse> { Data = result };
            await _linksService.AddLinksAsync(new HateoasResponse<ItemResponse> { Data = result });
            return Ok(hateoasResult);
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost(Name = nameof(Post))]
        public async Task<IActionResult> Post(AddItemRequest request)
        {
            ItemResponse result = await _itemService.AddItemAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, null);
        }

        /// <summary>
        /// Put
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id:guid}", Name = nameof(Put))]
        [ItemExists]
        public async Task<IActionResult> Put(Guid id, EditItemRequest request)
        {
            request.Id = id;
            ItemResponse result = await _itemService.EditItemAsync(request);

            HateoasResponse<ItemResponse> hateoasResult = new HateoasResponse<ItemResponse> { Data = result };
            await _linksService.AddLinksAsync(hateoasResult);

            return Ok(hateoasResult);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:guid}", Name = nameof(Delete))]
        [ItemExists]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteItemRequest request = new DeleteItemRequest { Id = id };
            await _itemService.DeleteItemAsync(request);
            return NoContent();
        }
    }
}