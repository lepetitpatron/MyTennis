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
            return repository.Add(Utilities.Mapper.Map<LeagueDTO, League>(entity));
        }

        public bool Delete(int id)
        {
            return repository.Remove(id);
        }

        public LeagueDTO FindById(int id)
        {
            try
            {
                return Utilities.Mapper.Map<League, LeagueDTO>(repository.FindById(id));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<LeagueDTO> GetAll()
        {
            try
            {
                return Utilities.Mapper.MapList<League, LeagueDTO>(repository.GetAll());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Update(LeagueDTO entity)
        {
            return repository.Modify(Utilities.Mapper.Map<LeagueDTO, League>(entity));
        }
    }
}
