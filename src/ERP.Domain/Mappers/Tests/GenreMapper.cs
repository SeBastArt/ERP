using ERP.Domain.Models;
using ERP.Domain.Responses;

namespace ERP.Domain.Mappers
{
    public class GenreMapper : IGenreMapper
    {
        GenreResponse IGenreMapper.Map(Genre genre)
        {
            if (genre == null)
            {
                return null;
            }

            return new GenreResponse
            {
                GenreId = genre.GenreId,
                GenreDescription = genre.GenreDescription
            };
        }
    }
}
