using ERP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Respositories
{
    public interface IArtistRespository : IRespository
    {
        Task<IEnumerable<Artist>> GetAsync();
        IQueryable<Artist> GetQuery();
        Task<Artist> GetAsync(Guid id);
        Artist Add(Artist artist);
    }
}
