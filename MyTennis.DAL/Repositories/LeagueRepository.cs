using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyTennis.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyTennis.DAL.Repositories
{
    public class LeagueRepository : IRepository<League>
    {
        private readonly MyTennisDBContext _context;

        public LeagueRepository(MyTennisDBContext context)
        {
            _context = context;
        }

        public bool Add(League t)
        {
            try
            {
                _context.Leagues.Add(t);
                _context.SaveChanges();

                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public League FindById(int id)
        {
            return _context.Set<League>().SingleOrDefault(e => e.Id == id);
        }

        public List<League> GetAll()
        {
            IQueryable<League> query = _context.Set<League>();
            IEnumerable<League> result = query.ToList();

            return result.ToList();
        }

        public bool Modify(League t)
        {
            League entity = _context.Leagues.Where(e => e.Id == t.Id).FirstOrDefault();
            if (entity == null) return false;

            EntityEntry entry = _context.Entry(entity);
            entry.CurrentValues.SetValues(t);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(int id)
        {
            if (_context.Set<League>().SingleOrDefault(e => e.Id == id) == null)
                return false;

            League entity = _context.Leagues.Find((byte) id);
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();

            return true;
        }
    }
}