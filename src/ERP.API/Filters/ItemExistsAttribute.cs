using ERP.Domain.Extensions;
using ERP.Domain.Responses;
using ERP.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace ERP.API.Filters
{
    /// <summary>
    /// ItemExistsAttribute
    /// </summary>
    public sealed class ItemExistsAttribute : TypeFilterAttribute
    {
        /// <summary>
        /// ItemExistsAttribute
        /// </summary>
        public ItemExistsAttribute() : base(typeof(ItemExistsFilterImpl))
        { }

        /// <summary>
        /// ItemExistsFilterImpl
        /// </summary>
        public class ItemExistsFilterImpl : IAsyncActionFilter
        {
            private readonly IItemService _itemService;

            /// <summary>
            /// ItemExistsFilterImpl
            /// </summary>
            /// <param name="itemService"></param>
            public ItemExistsFilterImpl(IItemService itemService)
            {
                _itemService = itemService;
            }

            /// <summary>
            /// OnActionExecutionAsync
            /// </summary>
            /// <param name="context"></param>
            /// <param name="next"></param>
            /// <returns></returns>
            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                if (!(context.ActionArguments["id"] is Guid id))
                {
                    throw new StackException("id is not a valid Guid");
                }

                ItemResponse result = await _itemService.GetItemAsync(id);

                if (result == null)
                {
                    throw new NotFoundException($"Item with id { id } not exist.");
                }

                await next();
            }
        }
    }
}
