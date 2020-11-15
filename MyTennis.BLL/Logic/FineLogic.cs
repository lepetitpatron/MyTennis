using MyTennis.BLL.Utilities;
using MyTennis.Core.DTO;
using MyTennis.DAL;
using MyTennis.DAL.Entities;
using MyTennis.DAL.Repositories;
using System;
using System.Collections.Generic;

namespace MyTennis.BLL.Logic
{
    public class FineLogic : ILogic<FineDTO>
    {
        private readonly MyTennisDBContext _context = new MyTennisDBContext();
        private readonly FineRepository repository;

        public FineLogic()
        {
            repository = new FineRepository(_context);
        }

        public bool Create(FineDTO entity)
        {
            return repository.Add(ObjectMapper.Mapper.Map<Fine>(entity));
        }

        public bool Delete(int id)
        {
            return repository.Remove(id);
        }

        public FineDTO FindById(int id)
        {
            try
            {
                return ObjectMapper.Mapper.Map<FineDTO>(repository.FindById(id));
            }
            catch(Exception)
            {
                throw new Exception();
            }
        }

        public List<FineDTO> GetAll()
        {
            try
            {
                return ObjectMapper.Mapper.Map<List<FineDTO>>(repository.GetAll());
            }
            catch(Exception)
            {
                throw new Exception();
            }
        }

        public bool Update(FineDTO entity)
        {
            return repository.Modify(ObjectMapper.Mapper.Map<Fine>(entity));
        }
    }
}
