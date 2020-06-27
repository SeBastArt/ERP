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
    /// CompanyController
    /// </summary>
    [Produces("application/json")]
    [Route("api/companies")]
    [ApiController]
    [ApiVersion("1.0")]
    [JsonException]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _itemService;
        private readonly IMediator _mediator;

        /// <summary>
        /// Constructor CompanyController
        /// </summary>
        /// <param name="itemService"></param>
        /// <param name="mediator"></param>
        public CompanyController(ICompanyService itemService, IMediator mediator)
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
        [ApiConventionMethod(typeof(CompanyApiConvention), nameof(CompanyApiConvention.Get))]
        public async Task<IActionResult> Get([FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 0, [FromQuery] string sortColumn = null, [FromQuery] string sortOrder = null,
            [FromQuery] string filterColumn = null, [FromQuery] string filterQuery = null)
        {
            GetAllCompanyRequest request = new GetAllCompanyRequest
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                SortColumn = sortColumn,
                SortOrder = sortOrder,
                FilterColumn = filterColumn,
                FilterQuery = filterQuery,
            };
            ApiResult<CompanyResponse> result = await _mediator.Send(new GetAllCompaniesQuery(request));
            return Ok();
        }

        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        [ApiConventionMethod(typeof(CompanyApiConvention), nameof(CompanyApiConvention.GetById))]
        public async Task<IActionResult> GetById(Guid id)
        {
            CompanyResponse result = await _mediator.Send(new GetCompanyQuery(id));
            return Ok(result);
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ApiConventionMethod(typeof(CompanyApiConvention), nameof(CompanyApiConvention.Create))]
        public async Task<IActionResult> Post(AddCompanyRequest request)
        {
            RespContainer<CompanyResponse> result = await _mediator.Send(new AddCompanyCommand(request));
            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
        }

        /// <summary>
        /// Put
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        [ApiConventionMethod(typeof(CompanyApiConvention), nameof(CompanyApiConvention.Update))]
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
        [ApiConventionMethod(typeof(CompanyApiConvention), nameof(CompanyApiConvention.Delete))]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteCompanyRequest request = new DeleteCompanyRequest { Id = id };
            return Ok(await _mediator.Send(new DelteCompanyCommand(request)));
        }
    }
}