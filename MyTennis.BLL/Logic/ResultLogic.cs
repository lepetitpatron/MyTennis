using MyTennis.BLL.Utilities;
using MyTennis.Core.DTO;
using MyTennis.DAL;
using MyTennis.DAL.Entities;
using MyTennis.DAL.Repositories;
using System;
using System.Collections.Generic;

namespace MyTennis.BLL.Logic
{
    public class ResultLogic : ILogic<ResultDTO>
    {
        private readonly MyTennisDBContext _context = new MyTennisDBContext();
        private readonly ResultRepository repository;

        public ResultLogic()
        {
            repository = new ResultRepository(_context);
        }

        public bool Create(ResultDTO entity)
        {
            return repository.Add(ObjectMapper.Mapper.Map<Result>(entity));
        }

        public bool Delete(int id)
        {
            return repository.Remove(id);
        }

        public ResultDTO FindById(int id)
        {
            try
            {
                return ObjectMapper.Mapper.Map<ResultDTO>(repository.FindById(id));
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public List<ResultDTO> GetAll()
        {
            try
            {
                return ObjectMapper.Mapper.Map<List<ResultDTO>>(repository.GetAll());
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public bool Update(ResultDTO entity)
        {
            return repository.Modify(ObjectMapper.Mapper.Map<Result>(entity));
        }
    }
}