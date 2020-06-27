using ERP.Domain.Models;
using ERP.Domain.Requests;
using ERP.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Domain.Mappers
{
    public class PersonMapper : IPersonMapper
    {
        private readonly IFAGBinaryMapper _fagBinaryMapper;

        public PersonMapper(IFAGBinaryMapper fagBinaryMapper)
        {
            _fagBinaryMapper = fagBinaryMapper;
        }

        public Person Map(AddPersonRequest request)
        {
            if (request == null)
            {
                return null;
            }

            Person person = new Person
            {
                LastName = request.LastName,
                FirstName = request.FirstName,
                Sex = request.Sex,
                Department = request.Department,
                PhoneOffice = request.PhoneOffice,
                PhonePrivate = request.PhonePrivate,
                Email = request.Email,
                PictureId = request.PictureId
            };

            return person;
        }

        public Person Map(EditPersonRequest request)
        {
            if (request == null)
            {
                return null;
            }

            Person person = new Person
            {
                Id = request.Id,
                LastName = request.LastName,
                FirstName = request.FirstName,
                Sex = request.Sex,
                Department = request.Department,
                PhoneOffice = request.PhoneOffice,
                PhonePrivate = request.PhonePrivate,
                Email = request.Email,
                PictureId = request.PictureId
            };

            return person;
        }

        public PersonResponse Map(Person person)
        {
            if (person == null)
            {
                return null;
            };

            PersonResponse response = new PersonResponse
            {
                Id = person.Id,
                LastName = person.LastName,
                FirstName = person.FirstName,
                Sex = person.Sex,
                Department = person.Department,
                PhoneOffice = person.PhoneOffice,
                PhonePrivate = person.PhonePrivate,
                Email = person.Email,
                PictureId = (Guid)person.PictureId,
                Picture = _fagBinaryMapper.Map(person.Picture)
            };
            return response;
        }

        public IQueryable<PersonResponse> Map(IQueryable<Person> person)
        {

            if (person == null)
            {
                return null;
            };

            IQueryable<PersonResponse> response = person.Select(x => new PersonResponse()
            {
                Id = x.Id,
                LastName = x.LastName,
                FirstName = x.FirstName,
                Sex = x.Sex,
                Department = x.Department,
                PhoneOffice = x.PhoneOffice,
                PhonePrivate = x.PhonePrivate,
                Email = x.Email,
                PictureId = (Guid)x.PictureId,
                Picture = _fagBinaryMapper.Map(x.Picture)
            });

            return response;
        }
    }
}
