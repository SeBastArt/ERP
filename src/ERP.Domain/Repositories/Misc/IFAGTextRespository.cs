using ERP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Respositories
{
    public interface IFAGTextRespository : IRespository
    {
        Task<IEnumerable<FAGText>> GetAsync();
        IQueryable<FAGText> GetQuery();
        Task<FAGText> GetAsync(Guid id);
        FAGText Add(FAGText item);
        FAGText Update(FAGText item);
    }
}
