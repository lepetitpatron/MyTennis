using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyTennis.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyTennis.DAL.Repositories
{
    public class GameRepository : IRepository<Game>
    {
        private readonly MyTennisDBContext _context;

        public GameRepository(MyTennisDBContext context)
        {
            _context = context;
        }

        public bool Add(Game t)
        {
            try
            {
                _context.Games.Add(t);
                _context.SaveChanges();

                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public Game FindById(int id)
        {
            return _context.Set<Game>().SingleOrDefault(e => e.Id == id);
        }

        public List<Game> GetAll()
        {
            IQueryable<Game> query = _context.Set<Game>();
            IEnumerable<Game> result = query.ToList();

            return result.ToList();
        }

        public bool Modify(Game t)
        {
            Game entity = _context.Games.Where(e => e.Id == t.Id).FirstOrDefault();
            if (entity == null) return false;

            EntityEntry entry = _context.Entry(entity);
            entry.CurrentValues.SetValues(t);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(int id)
        {
            if (_context.Set<Game>().SingleOrDefault(e => e.Id == id) == null)
                return false;

            Game entity = _context.Games.Find(id);
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();

            return true;
        }
    }
}
