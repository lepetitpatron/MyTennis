using MyTennis.Core.DTO;
using MyTennis.DAL;
using MyTennis.DAL.Repositories;
using System;
using System.Collections.Generic;

namespace MyTennis.BLL.Logic
{
    class ResultLogic : ILogic<ResultDTO>
    {
        private readonly MyTennisDBContext _context = new MyTennisDBContext();
        private readonly ResultRepository repository;

        public ResultLogic()
        {
            repository = new ResultRepository(_context);
        }

        public bool Create(ResultDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ResultDTO FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ResultDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(ResultDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}