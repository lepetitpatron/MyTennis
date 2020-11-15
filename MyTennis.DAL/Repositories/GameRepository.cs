using MyTennis.DAL.Entities;
using System;
using System.Collections.Generic;

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
            throw new NotImplementedException();
        }

        public Game FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Game> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Modify(Game t)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
