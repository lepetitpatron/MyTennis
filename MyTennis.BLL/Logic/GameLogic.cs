using MyTennis.Core.DTO;
using MyTennis.DAL;
using MyTennis.DAL.Repositories;
using System;
using System.Collections.Generic;

namespace MyTennis.BLL.Logic
{
    class GameLogic : ILogic<GameDTO>
    {
        private readonly MyTennisDBContext _context = new MyTennisDBContext();
        private readonly GameRepository repository;

        public GameLogic()
        {
            repository = new GameRepository(_context);
        }

        public bool Create(GameDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int entity)
        {
            throw new NotImplementedException();
        }

        public GameDTO FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<GameDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(GameDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
