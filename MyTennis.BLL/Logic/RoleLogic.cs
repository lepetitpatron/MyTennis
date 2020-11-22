using MyTennis.BLL.Utilities;
using MyTennis.Core.DTO;
using MyTennis.DAL;
using MyTennis.DAL.Entities;
using MyTennis.DAL.Repositories;
using System;
using System.Collections.Generic;

namespace MyTennis.BLL
{
    public class RoleLogic : ILogic<RoleDTO>
    {
        private readonly MyTennisDBContext _context = new MyTennisDBContext();
        private readonly RoleRepository repository;

        public RoleLogic()
        {
            repository = new RoleRepository(_context);
        }

        public bool Create(RoleDTO entity)
        {
            return repository.Add(ObjectMapper.Mapper.Map<Role>(entity));
        }

        public bool Delete(int id)
        {
            return repository.Remove(id);
        }

        public RoleDTO FindById(int id)
        {
            try
            {
                return ObjectMapper.Mapper.Map<RoleDTO>(repository.FindById(id));
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public List<RoleDTO> GetAll()
        {
            try
            {
                return ObjectMapper.Mapper.Map<List<RoleDTO>>(repository.GetAll());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Update(RoleDTO entity)
        {
            return repository.Modify(ObjectMapper.Mapper.Map<Role>(entity));
        }
    }
}
