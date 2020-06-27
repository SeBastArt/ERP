using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Domain.Mappers
{
    public class FAGTextMapper : IFAGTextMapper
    {
        public FAGText Map(AddFAGTextRequest request)
        {
            if (request == null)
            {
                return null;
            }

            FAGText fagText = new FAGText
            {
                Text = request.Text,
                TextRTF = request.TextRTF,
                Iso3cc = request.Iso3cc,
                Iso2cc = request.Iso2cc,
            };

            return fagText;
        }

        public FAGText Map(EditFAGTextRequest request)
        {
            if (request == null)
            {
                return null;
            }

            FAGText fagText = new FAGText
            {
                Id = request.Id,
                Text = request.Text,
                TextRTF = request.TextRTF,
                Iso3cc = request.Iso3cc,
                Iso2cc = request.Iso2cc,
            };

            return fagText;
        }

        public FAGTextResponse Map(FAGText fagText)
        {
            if (fagText == null)
            {
                return null;
            };

            FAGTextResponse response = new FAGTextResponse
            {
                Id = fagText.Id,
                Text = fagText.Text,
                TextRTF = fagText.TextRTF,
                Iso3cc = fagText.Iso3cc,
                Iso2cc = fagText.Iso2cc
            };

            return response;
        }

        public IQueryable<FAGTextResponse> Map(IQueryable<FAGText> fagText)
        {

            if (fagText == null)
            {
                return null;
            };

            IQueryable<FAGTextResponse> response = fagText.Select(x => new FAGTextResponse()
            {
                Id = x.Id,
                Text = x.Text,
                TextRTF = x.TextRTF,
                Iso3cc = x.Iso3cc,
                Iso2cc = x.Iso2cc
            });

            return response;
        }
    }
}
