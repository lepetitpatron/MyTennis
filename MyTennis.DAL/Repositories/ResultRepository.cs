using MyTennis.DAL.Entities;
using System;
using System.Collections.Generic;

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
            throw new NotImplementedException();
        }

        public Result FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Result> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Modify(Result t)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
