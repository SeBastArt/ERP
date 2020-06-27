using ERP.Domain.Models;
using ERP.Domain.Responses;

namespace ERP.Domain.Mappers
{
    public class ArtistMapper : IArtistMapper
    {
        public ArtistResponse Map(Artist artist)
        {
            if (artist == null)
            {
                return null;
            }

            return new ArtistResponse
            {
                ArtistId = artist.ArtistId,
                ArtistName = artist.ArtistName
            };
        }
    }
}
