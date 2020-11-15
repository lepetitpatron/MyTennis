using MyTennis.DAL.Entities;
using System;
using System.Collections.Generic;

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
            throw new NotImplementedException();
        }

        public List<Member> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Modify(Member t)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
