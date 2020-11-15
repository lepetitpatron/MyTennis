using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyTennis.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyTennis.DAL.Repositories
{
    public class FineRepository : IRepository<Fine>
    {
        private readonly MyTennisDBContext _context;

        public FineRepository(MyTennisDBContext context)
        {
            _context = context;
        }

        public bool Add(Fine t)
        {
            try
            {
                _context.Fines.Add(t);
                _context.SaveChanges();

                return true;
            }
            catch(Exception)
            {
                return false;
            }

        }

        public Fine FindById(int id)
        {
            return _context.Set<Fine>().SingleOrDefault(e => e.Id == id);
        }

        public List<Fine> GetAll()
        {
            IQueryable<Fine> query = _context.Set<Fine>();
            IEnumerable<Fine> result = query.ToList();

            return result.ToList();
        }

        public bool Modify(Fine t)
        {
            Fine entity = _context.Fines.Where(e => e.Id == t.Id).FirstOrDefault();
            if (entity == null) return false;

            EntityEntry entry = _context.Entry(entity);
            entry.CurrentValues.SetValues(t);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(int id)
        {
            return false;
        }
    }
}
