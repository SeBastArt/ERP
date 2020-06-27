using ERP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Respositories
{
    public interface IFAGBinaryRespository : IRespository
    {
        Task<IEnumerable<FAGBinary>> GetAsync();
        IQueryable<FAGBinary> GetQuery();
        Task<FAGBinary> GetAsync(Guid id);
        FAGBinary Add(FAGBinary item);
        FAGBinary Update(FAGBinary item);
    }
}