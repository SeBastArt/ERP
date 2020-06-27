using ERP.Domain.Models;
using ERP.Domain.Respositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Infrastructur.Respositories
{
    public class PersonRespository : IPersonRespository
    {
        private readonly ERPContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public PersonRespository(ERPContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Person Add(Person person)
        {
            return _context.Persons.Add(person).Entity;
        }

        public async Task<IEnumerable<Person>> GetAsync()
        {
            return await _context.Persons
                .Where(x => !x.IsInactive)
                .AsNoTracking()
                .ToListAsync();
        }

        public IQueryable<Person> GetQuery()
        {
            return _context.Persons
                .Where(x => !x.IsInactive)
                .AsNoTracking();
        }

        public async Task<Person> GetAsync(Guid id)
        {
            Person person = await _context.Persons.AsNoTracking().Where(x => x.Id == id).Include(x => x.Picture).Include(x => x.CompanyPersonRelations).FirstOrDefaultAsync();
            return person;
        }

        public Person Update(Person person)
        {
            _context.Entry(person).State = EntityState.Modified;
            return person;
        }
    }
}
