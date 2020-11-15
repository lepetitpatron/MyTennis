using MyTennis.DAL.Entities;
using System;
using System.Collections.Generic;

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
            throw new NotImplementedException();
        }

        public Fine FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Fine> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Modify(Fine t)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
