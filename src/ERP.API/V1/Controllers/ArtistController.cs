using ERP.API.Filters;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using ERP.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.API.V1.Controllers
{
    /// <summary>
    /// ArtistController
    /// </summary>
    [Route("api/artist")]
    [ApiVersion("1.0")]
    [ApiController]
    [JsonException]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;
        /// <summary>
        /// Constructor ArtistController
        /// </summary>
        /// <param name="artistService"></param>
        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
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
        [MapToApiVersion("1.0")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 0, [FromQuery] string sortColumn = null, [FromQuery] string sortOrder = null,
            [FromQuery] string filterColumn = null, [FromQuery] string filterQuery = null)
        {
            IQueryable<ArtistResponse> artistQuery = _artistService.GetArtistsQuery();
            ApiResult<ArtistResponse> pagedResults = await ApiResult<ArtistResponse>.CreateAsync(
                artistQuery,
                pageIndex,
                pageSize,
                sortColumn,
                sortOrder,
                filterColumn,
                filterQuery);

            return Ok(pagedResults);
        }

        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            ArtistResponse result = await _artistService.GetArtistAsync(new GetArtistRequest { Id = id });
            return Ok(result);
        }

        /// <summary>
        /// GetItemsById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:Guid}/items")]
        public async Task<IActionResult> GetItemsById(Guid id)
        {
            IEnumerable<ItemResponse> result = await _artistService.GetItemByArtistIdAsync(new GetArtistRequest { Id = id });
            return Ok(result);
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(AddArtistRequest request)
        {
            ArtistResponse result = await _artistService.AddArtistAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = result.ArtistId }, null);
        }
    }
}