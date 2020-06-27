using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;

namespace ERP.Domain.Mappers
{
    public interface IPersonMapper
    {
        Person Map(AddPersonRequest request);
        Person Map(EditPersonRequest request);
        PersonResponse Map(Person person);
    }
}
