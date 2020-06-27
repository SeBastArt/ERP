using ERP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Respositories
{
    public interface IGenreRespository : IRespository
    {
        Task<IEnumerable<Genre>> GetAsync();
        IQueryable<Genre> GetQuery();
        Task<Genre> GetAsync(Guid id);
        Genre Add(Genre genre);
    }
}
