using ERP.API.Filters;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using ERP.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.API.V1.Controllers
{
    /// <summary>
    /// GenreController
    /// </summary>
    [Route("api/genre")]
    [ApiVersion("1.0")]
    [ApiController]
    [JsonException]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        /// <summary>
        /// Constructor GenreController
        /// </summary>
        /// <param name="genreService"></param>
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
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
            IQueryable<GenreResponse> genresQuery = _genreService.GetGenresQuery();
            ApiResult<GenreResponse> pagedResults = await ApiResult<GenreResponse>.CreateAsync(
                genresQuery,
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
            GenreResponse result = await _genreService.GetGenreAsync(new GetGenreRequest { Id = id });
            return Ok(result);
        }

        /// <summary>
        /// GetItemById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}/items")]
        public async Task<IActionResult> GetItemById(Guid id)
        {
            System.Collections.Generic.IEnumerable<ItemResponse> result = await _genreService.GetItemByGenreIdAsync(new GetGenreRequest { Id = id });
            return Ok(result);
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(AddGenreRequest request)
        {
            GenreResponse result = await _genreService.AddGenreAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = result.GenreId }, null);
        }
    }
}