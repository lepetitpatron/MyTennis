using MyTennis.BLL.Utilities;
using MyTennis.Core.DTO;
using MyTennis.DAL;
using MyTennis.DAL.Entities;
using MyTennis.DAL.Repositories;
using System;
using System.Collections.Generic;

namespace MyTennis.BLL.Logic
{
    public class GameLogic : ILogic<GameDTO>
    {
        private readonly MyTennisDBContext _context = new MyTennisDBContext();
        private readonly GameRepository repository;

        public GameLogic()
        {
            repository = new GameRepository(_context);
        }

        public bool Create(GameDTO entity)
        {
            return repository.Add(ObjectMapper.Mapper.Map<Game>(entity));
        }

        public bool Delete(int id)
        {
            return repository.Remove(id);
        }

        public GameDTO FindById(int id)
        {
            try
            {
                return ObjectMapper.Mapper.Map<GameDTO>(repository.FindById(id));
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public List<GameDTO> GetAll()
        {
            try
            {
                List<GameDTO> games = ObjectMapper.Mapper.Map<List<GameDTO>>(repository.GetAll());
                games.Sort((x, y) => x.Date.CompareTo(y.Date));

                return games;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public bool Update(GameDTO entity)
        {
            return repository.Modify(ObjectMapper.Mapper.Map<Game>(entity));
        }
    }
}
