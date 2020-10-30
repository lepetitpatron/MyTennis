using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyTennis.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyTennis.DAL.Repositories
{
    public class RoleRepository : IRepository<Role>
    {
        private readonly MyTennisDBContext _context;

        public RoleRepository(MyTennisDBContext context)
        {
            _context = context;
        }

        public bool Add(Role t)
        {
            try
            {
                _context.Roles.Add(t);
                _context.SaveChanges();

                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public Role FindById(int? id)
        {
            return _context.Set<Role>().SingleOrDefault(e => e.Id == id);
        }

        public List<Role> GetAll()
        {
            IQueryable<Role> query = _context.Set<Role>();
            IEnumerable<Role> result = query.ToList();

            return result.ToList();
        }

        public bool Modify(Role t)
        {
            Role entity = _context.Roles.Where(e => e.Id == t.Id).FirstOrDefault();
            if (entity == null) return false;

            EntityEntry entry = _context.Entry(entity);
            entry.CurrentValues.SetValues(t);
            _context.SaveChanges();

            return true;
        }

        public void Remove(Role t)
        {
            throw new System.NotImplementedException();
        }
    }
}
