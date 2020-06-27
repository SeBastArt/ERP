using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.API.Conventions;
using ERP.API.Filters;
using ERP.Domain.Mediator.Commands;
using ERP.Domain.Mediator.Queries;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using ERP.Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ERP.API.V1.Controllers
{
    /// <summary>
    /// CompanyTypeController
    /// </summary>
    [Produces("application/json")]
    [Route("api/company/types")]
    [ApiController]
    [ApiVersion("1.0")]
    [JsonException]
    public class CompanyTypeController : ControllerBase
    {
        private readonly ICompanyTypeService _itemService;
        private readonly IMediator _mediator;

        /// <summary>
        /// Constructor CompanyTypeController
        /// </summary>
        /// <param name="itemService"></param>
        /// <param name="mediator"></param>
        public CompanyTypeController(ICompanyTypeService itemService, IMediator mediator)
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
        [ApiConventionMethod(typeof(CompanyTypeApiConvention), nameof(CompanyTypeApiConvention.Get))]
        public async Task<IActionResult> Get([FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 0, [FromQuery] string sortColumn = null, [FromQuery] string sortOrder = null,
            [FromQuery] string filterColumn = null, [FromQuery] string filterQuery = null)
        {
            GetAllCompanyTypeRequest request = new GetAllCompanyTypeRequest
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                SortColumn = sortColumn,
                SortOrder = sortOrder,
                FilterColumn = filterColumn,
                FilterQuery = filterQuery,
            };
            ApiResult<CompanyTypeResponse> result = await _mediator.Send(new GetAllCompanyTypesQuery(request));
            return Ok();
        }

        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        [ApiConventionMethod(typeof(CompanyTypeApiConvention), nameof(CompanyTypeApiConvention.GetById))]
        public async Task<IActionResult> GetById(Guid id)
        {
            CompanyTypeResponse result = await _mediator.Send(new GetCompanyTypeQuery(id));
            return Ok(result);
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ApiConventionMethod(typeof(CompanyTypeApiConvention), nameof(CompanyTypeApiConvention.Create))]
        public async Task<IActionResult> Post(AddCompanyTypeRequest request)
        {
            RespContainer<CompanyTypeResponse> result = await _mediator.Send(new AddCompanyTypeCommand(request));
            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
        }

        /// <summary>
        /// Put
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        [ApiConventionMethod(typeof(CompanyTypeApiConvention), nameof(CompanyTypeApiConvention.Update))]
        public async Task<IActionResult> Put(Guid id, EditCompanyTypeRequest request)
        {
            request.Id = id;
            return Ok(await _mediator.Send(new EditCompanyTypeCommand(request)));
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        [ApiConventionMethod(typeof(CompanyTypeApiConvention), nameof(CompanyTypeApiConvention.Delete))]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteCompanyTypeRequest request = new DeleteCompanyTypeRequest { Id = id };
            return Ok(await _mediator.Send(new DelteCompanyTypeCommand(request)));
        }
    }
}
