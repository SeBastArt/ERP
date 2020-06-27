using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using System.Linq;

namespace ERP.Domain.Mappers
{
    public interface IItemMapper
    {
        Item Map(AddItemRequest request);
        Item Map(EditItemRequest request);
        ItemResponse Map(Item item);
        IQueryable<ItemResponse> Map(IQueryable<Item> item);
    }
}
