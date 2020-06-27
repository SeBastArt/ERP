using ERP.Domain.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace ERP.API.Conventions
{
    /// <summary>
    /// ArticleRangeApiConvention
    /// </summary>
    public static class ArticleRangeApiConvention
    {
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        [ProducesResponseType(typeof(ApiResult<ArticleRangeResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RespContainer<JsonException>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RespContainer<JsonException>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(RespContainer<JsonException>), StatusCodes.Status404NotFound)]
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        public static void Get([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Suffix),
                                ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
            object id)
        {
        }

        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="id"></param>
        [ProducesResponseType(typeof(ArticleRangeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RespContainer<JsonException>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RespContainer<JsonException>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(RespContainer<JsonException>), StatusCodes.Status404NotFound)]
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        public static void GetById([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Suffix),
                                    ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
            object id)
        {
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="model"></param>
        [ProducesResponseType(typeof(RespContainer<ArticleRangeResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RespContainer<JsonException>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RespContainer<JsonException>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(RespContainer<JsonException>), StatusCodes.Status404NotFound)]
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        public static void Create([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any),
                                   ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
            object model)
        {
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        [ProducesResponseType(typeof(RespContainer<ArticleRangeResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RespContainer<JsonException>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RespContainer<JsonException>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(RespContainer<JsonException>), StatusCodes.Status404NotFound)]
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        public static void Update([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Suffix),
                                   ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
            object id, [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any),
                        ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
            object model)
        {
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        [ProducesResponseType(typeof(RespContainer<EmptyResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RespContainer<JsonException>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RespContainer<JsonException>), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(RespContainer<JsonException>), StatusCodes.Status404NotFound)]
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        public static void Delete([ApiConventionNameMatch(ApiConventionNameMatchBehavior.Suffix),
                                   ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
            object id)
        {
        }
    }
}
