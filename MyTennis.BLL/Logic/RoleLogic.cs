using MyTennis.Core;
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
            return repository.Add(Utilities.Mapper.Map<RoleDTO, Role>(entity));
        }

        public bool Delete(int id)
        {
            return repository.Remove(id);
        }

        public RoleDTO FindById(int id)
        {
            try
            {
                return Utilities.Mapper.Map<Role, RoleDTO>(repository.FindById(id));
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
                return Utilities.Mapper.MapList<Role, RoleDTO>(repository.GetAll());
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public bool Update(RoleDTO entity)
        {
            return repository.Modify(Utilities.Mapper.Map<RoleDTO, Role>(entity));
        }
    }
}
