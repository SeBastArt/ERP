using ERP.Domain.Requests;
using ERP.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Domain.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonResponse>> GetPersonsAsync();
        IQueryable<PersonResponse> GetPersonsQuery();
        Task<PersonResponse> GetPersonAsync(Guid id);
        Task<PersonResponse> AddPersonAsync(AddPersonRequest request);
        Task<PersonResponse> EditPersonAsync(EditPersonRequest request);
        Task<PersonResponse> DeletePersonAsync(DeletePersonRequest request);
    }
}
