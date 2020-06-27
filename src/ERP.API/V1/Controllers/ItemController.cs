using ERP.API.Conventions;
using ERP.API.Filters;
using ERP.Domain.Mediator.Queries;
using ERP.Domain.Mediator.Commands;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using ERP.Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace ERP.API.V1.Controllers
{
    /// <summary>
    /// ItemController
    /// </summary>
    [Produces("application/json")]
    [Route("api/items")]
    [ApiController]
    [ApiVersion("1.0")]
    [JsonException]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly IMediator _mediator;

        /// <summary>
        /// Constructor ItemController
        /// </summary>
        /// <param name="itemService"></param>
        /// <param name="mediator"></param>
        public ItemController(IItemService itemService, IMediator mediator)
        {
            _itemService = itemService;
            _mediator = mediator;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="sortColumn"></param>
        /// <param name="sortOrder"></param>
        /// <param name="filterColumn"></param>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpGet]
        //[Authorize(Policy = "Claim.Email")]
        [ApiConventionMethod(typeof(ItemApiConvention), nameof(ItemApiConvention.Get))]
        public async Task<IActionResult> Get([FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 0, [FromQuery] string sortColumn = null, [FromQuery] string sortOrder = null,
            [FromQuery] string filterColumn = null, [FromQuery] string filterQuery = null)
        {
            GetAllItemRequest request = new GetAllItemRequest
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                SortColumn = sortColumn,
                SortOrder = sortOrder,
                FilterColumn = filterColumn,
                FilterQuery = filterQuery,
            };
            ApiResult<ItemResponse> result = await _mediator.Send(new GetAllItemsQuery(request));
            return Ok(result);
        }

        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        [ItemExists]
        [ApiConventionMethod(typeof(ItemApiConvention), nameof(ItemApiConvention.GetById))]
        public async Task<IActionResult> GetById(Guid id)
        {
            ItemResponse result = await _mediator.Send(new GetItemQuery(id));
            return Ok(result);
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ApiConventionMethod(typeof(ItemApiConvention), nameof(ItemApiConvention.Create))]
        public async Task<IActionResult> Post(AddItemRequest request)
        {
            RespContainer<ItemResponse> result = await _mediator.Send(new AddItemCommand(request));
            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
        }

        /// <summary>
        /// Put
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        [ItemExists]
        [ApiConventionMethod(typeof(ItemApiConvention), nameof(ItemApiConvention.Update))]
        public async Task<IActionResult> Put(Guid id, EditCompanyRequest request)
        {
            request.Id = id;
            return Ok(await _mediator.Send(new EditCompanyCommand(request)));
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        [ItemExists]
        [ApiConventionMethod(typeof(ItemApiConvention), nameof(ItemApiConvention.Delete))]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteItemRequest request = new DeleteItemRequest { Id = id };
            return Ok(await _mediator.Send(new DelteItemCommand(request)));
        }
    }
}