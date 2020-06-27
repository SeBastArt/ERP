using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Domain.Mappers
{
    public class FAGBinaryMapper : IFAGBinaryMapper
    {
        public FAGBinary Map(AddFAGBinaryRequest request)
        {
            if (request == null)
            {
                return null;
            }

            FAGBinary fagBinary = new FAGBinary
            {
                FileName = request.FileName,
                Data = request.Data,
            };

            return fagBinary;
        }

        public FAGBinary Map(EditFAGBinaryRequest request)
        {
            if (request == null)
            {
                return null;
            }

            FAGBinary fagBinary = new FAGBinary
            {
                Id = request.Id,
                FileName = request.FileName,
                Data = request.Data,
            };

            return fagBinary;
        }

        public FAGBinaryResponse Map(FAGBinary fagBinary)
        {
            if (fagBinary == null)
            {
                return null;
            };

            FAGBinaryResponse response = new FAGBinaryResponse
            {
                Id = fagBinary.Id,
                FileName = fagBinary.FileName,
                Data = fagBinary.Data
            };

            return response;
        }

        public IQueryable<FAGBinaryResponse> Map(IQueryable<FAGBinary> fagBinary)
        {

            if (fagBinary == null)
            {
                return null;
            };

            IQueryable<FAGBinaryResponse> response = fagBinary.Select(x => new FAGBinaryResponse()
            {
                Id = x.Id,
                FileName = x.FileName,
                Data = x.Data,
            });

            return response;
        }
    }
}
