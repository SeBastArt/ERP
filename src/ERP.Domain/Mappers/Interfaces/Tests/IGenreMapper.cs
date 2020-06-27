using ERP.Domain.Models;
using ERP.Domain.Responses;

namespace ERP.Domain.Mappers
{
    public interface IGenreMapper
    {
        GenreResponse Map(Genre genre);
    }
}
