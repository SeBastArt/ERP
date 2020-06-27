using ERP.API.Filters;
using ERP.Domain.Extensions;
using ERP.Domain.Responses;
using ERP.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ERP.API.Tests.Filters
{
    public class ItemExistsAttributeTests
    {
        [Fact]
        public async Task Should_continue_pipeline_when_id_is_not_present()
        {
            Guid existingId = Guid.NewGuid();
            Mock<IItemService> itemService = new Mock<IItemService>();
            itemService
                .Setup(x => x.GetItemAsync(It.IsAny<Guid>()))
                .ReturnsAsync(() => null);

            ItemExistsAttribute.ItemExistsFilterImpl filter = new ItemExistsAttribute.ItemExistsFilterImpl(itemService.Object);


            ActionExecutingContext actionExecutedContext = new ActionExecutingContext(
                new ActionContext(new DefaultHttpContext(), new RouteData(), new ActionDescriptor()),
                new List<IFilterMetadata>(),
                new Dictionary<string, object>
                {
                    {"id", existingId}
                }, new object());

            Mock<ActionExecutionDelegate> nextCallback = new Mock<ActionExecutionDelegate>();
            await Task.Run(() => filter.OnActionExecutionAsync(actionExecutedContext, nextCallback.Object).ShouldThrow<NotFoundException>());
            //nextCallback.Verify(executionDelegate => executionDelegate(), Times.Once);
        }

        [Fact]
        public async Task Should_continue_pipeline_when_id_is_present()
        {
            Guid id = Guid.NewGuid();

            Mock<IItemService> itemService = new Mock<IItemService>();
            itemService
                .Setup(x => x.GetItemAsync(It.IsAny<Guid>()))
                .ReturnsAsync(new ItemResponse { Id = id });

            ItemExistsAttribute.ItemExistsFilterImpl filter = new ItemExistsAttribute.ItemExistsFilterImpl(itemService.Object);


            ActionExecutingContext actionExecutedContext = new ActionExecutingContext(
                new ActionContext(new DefaultHttpContext(), new RouteData(), new ActionDescriptor()),
                new List<IFilterMetadata>(),
                new Dictionary<string, object>
                {
                    {"id", id}
                }, new object());

            Mock<ActionExecutionDelegate> nextCallback = new Mock<ActionExecutionDelegate>();
            await filter.OnActionExecutionAsync(actionExecutedContext, nextCallback.Object);

            nextCallback.Verify(executionDelegate => executionDelegate(), Times.Once);
        }
    }
}

