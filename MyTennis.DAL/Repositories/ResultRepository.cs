using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyTennis.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyTennis.DAL.Repositories
{
    public class ResultRepository : IRepository<Result>
    {
        private readonly MyTennisDBContext _context;

        public ResultRepository(MyTennisDBContext context)
        {
            _context = context;
        }

        public bool Add(Result t)
        {
            try
            {
                _context.Results.Add(t);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Result FindById(int id)
        {
            return _context.Set<Result>().SingleOrDefault(e => e.Id == id);
        }

        public List<Result> GetAll()
        {
            IQueryable<Result> query = _context.Set<Result>();
            IEnumerable<Result> result = query.ToList();

            return result.ToList();
        }

        public bool Modify(Result t)
        {
            Result entity = _context.Results.Where(e => e.Id == t.Id).FirstOrDefault();
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