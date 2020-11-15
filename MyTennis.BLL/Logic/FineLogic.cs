using MyTennis.Core.DTO;
using MyTennis.DAL;
using MyTennis.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTennis.BLL.Logic
{
    class FineLogic : ILogic<FineDTO>
    {
        private readonly MyTennisDBContext _context = new MyTennisDBContext();
        private readonly FineRepository repository;

        public FineLogic()
        {
            repository = new FineRepository(_context);
        }

        public bool Create(FineDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int entity)
        {
            throw new NotImplementedException();
        }

        public FineDTO FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<FineDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(FineDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
