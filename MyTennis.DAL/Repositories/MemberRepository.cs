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
            IQueryable<Member> query = _context.Set<Member>().Where(m => m.IsActive);
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
            Member entity = _context.Members.Where(e => e.Id == id).FirstOrDefault();
            if (entity == null) return false;

            Member removedMember = _context.Set<Member>().SingleOrDefault(e => e.Id == id);
            removedMember.IsActive = false;

            EntityEntry entry = _context.Entry(entity);
            entry.CurrentValues.SetValues(removedMember);
            _context.SaveChanges();

            return true;
        }
    }
}