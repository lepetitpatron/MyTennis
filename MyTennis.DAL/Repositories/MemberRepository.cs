using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyTennis.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyTennis.DAL.Repositories
{
    public class MemberRepository : IRepository<Member>
    {
        private readonly MyTennisDBContext _context;

        public MemberRepository(MyTennisDBContext context)
        {
            _context = context;
        }

        public bool Add(Member t)
        {
            try
            {
                _context.Members.Add(t);
                _context.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Member FindById(int id)
        {
            return _context.Set<Member>().SingleOrDefault(e => e.Id == id);
        }

        public List<Member> GetAll()
        {
            IQueryable<Member> query = _context.Set<Member>();
            IEnumerable<Member> result = query.ToList();

            return result.ToList();
        }

        public bool Modify(Member t)
        {
            Member entity = _context.Members.Where(e => e.Id == t.Id).FirstOrDefault();
            if (entity == null) return false;

            EntityEntry entry = _context.Entry(entity);
            entry.CurrentValues.SetValues(t);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(int id)
        {
            if (_context.Set<Member>().SingleOrDefault(e => e.Id == id) == null)
                return false;

            Member entity = _context.Members.Find(id);
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();

            return true;
        }
    }
}