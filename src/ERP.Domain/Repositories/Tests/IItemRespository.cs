using ERP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Respositories
{
    public interface IItemRespository : IRespository
    {
        Task<IEnumerable<Item>> GetAsync();
        IQueryable<Item> GetQuery();
        Task<Item> GetAsync(Guid id);
        Task<IEnumerable<Item>> GetItemsByArtistIdAsync(Guid id);
        Task<IEnumerable<Item>> GetItemsByGenreIdAsync(Guid id);
        Item Add(Item item);
        Item Update(Item item);
    }
}
