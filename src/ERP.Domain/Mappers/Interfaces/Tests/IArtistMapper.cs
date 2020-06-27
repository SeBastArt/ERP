using ERP.Domain.Models;
using ERP.Domain.Responses;

namespace ERP.Domain.Mappers
{
    public interface IArtistMapper
    {
        ArtistResponse Map(Artist artist);
    }
}
