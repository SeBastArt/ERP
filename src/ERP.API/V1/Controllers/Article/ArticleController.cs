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

namespace ERP.API.V1.Controllers
{
    /// <summary>
    /// ArticleController
    /// </summary>
    [Produces("application/json")]
    [Route("api/articles")]
    [ApiController]
    [ApiVersion("1.0")]
    [JsonException]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _itemService;
        private readonly IMediator _mediator;

        /// <summary>
        /// Constructor ArticleController
        /// </summary>
        /// <param name="itemService"></param>
        /// <param name="mediator"></param>
        public ArticleController(IArticleService itemService, IMediator mediator)
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
        [ApiConventionMethod(typeof(ArticleApiConvention), nameof(ArticleApiConvention.Get))]
        public async Task<IActionResult> Get([FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 0, [FromQuery] string sortColumn = null, [FromQuery] string sortOrder = null,
            [FromQuery] string filterColumn = null, [FromQuery] string filterQuery = null)
        {
            GetAllArticleRequest request = new GetAllArticleRequest
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                SortColumn = sortColumn,
                SortOrder = sortOrder,
                FilterColumn = filterColumn,
                FilterQuery = filterQuery,
            };
            ApiResult<ArticleResponse> result = await _mediator.Send(new GetAllArticlesQuery(request));
            return Ok();
        }

        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        [ApiConventionMethod(typeof(ArticleApiConvention), nameof(ArticleApiConvention.GetById))]
        public async Task<IActionResult> GetById(Guid id)
        {
            ArticleResponse result = await _mediator.Send(new GetArticleQuery(id));
            return Ok(result);
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ApiConventionMethod(typeof(ArticleApiConvention), nameof(ArticleApiConvention.Create))]
        public async Task<IActionResult> Post(AddArticleRequest request)
        {
            RespContainer<ArticleResponse> result = await _mediator.Send(new AddArticleCommand(request));
            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
        }

        /// <summary>
        /// Put
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        [ApiConventionMethod(typeof(ArticleApiConvention), nameof(ArticleApiConvention.Update))]
        public async Task<IActionResult> Put(Guid id, EditArticleRequest request)
        {
            request.Id = id;
            return Ok(await _mediator.Send(new EditArticleCommand(request)));
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        [ApiConventionMethod(typeof(ArticleApiConvention), nameof(ArticleApiConvention.Delete))]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteArticleRequest request = new DeleteArticleRequest { Id = id };
            return Ok(await _mediator.Send(new DelteArticleCommand(request)));
        }
    }
}