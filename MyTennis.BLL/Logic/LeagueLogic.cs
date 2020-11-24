using MyTennis.BLL.Utilities;
using MyTennis.Core.DTO;
using MyTennis.DAL;
using MyTennis.DAL.Entities;
using MyTennis.DAL.Repositories;
using System;
using System.Collections.Generic;

namespace MyTennis.BLL
{
    public class LeagueLogic : ILogic<LeagueDTO>
    {
        private readonly MyTennisDBContext _context = new MyTennisDBContext();
        private readonly LeagueRepository repository;

        public LeagueLogic()
        {
            repository = new LeagueRepository(_context);
        }

        public bool Create(LeagueDTO entity)
        {
            return repository.Add(ObjectMapper.Mapper.Map<League>(entity));
        }

        public bool Delete(int id)
        {
            return repository.Remove(id);
        }

        public LeagueDTO FindById(int id)
        {
            try
            {
                return ObjectMapper.Mapper.Map<LeagueDTO>(repository.FindById(id));
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public List<LeagueDTO> GetAll()
        {
            try
            {
                return ObjectMapper.Mapper.Map<List<LeagueDTO>>(repository.GetAll());
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public bool Update(LeagueDTO entity)
        {
            return repository.Modify(ObjectMapper.Mapper.Map<League>(entity));
        }
    }
}
