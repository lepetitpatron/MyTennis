using MyTennis.BLL.Utilities;
using MyTennis.Core.DTO;
using MyTennis.DAL;
using MyTennis.DAL.Entities;
using MyTennis.DAL.Repositories;
using System;
using System.Collections.Generic;

namespace MyTennis.BLL.Logic
{
    public class MemberRoleLogic
    {
        private readonly MyTennisDBContext _context = new MyTennisDBContext();
        private readonly MemberRoleRepository repository;

        public MemberRoleLogic()
        {
            repository = new MemberRoleRepository(_context);
        }

        public bool Create(MemberRoleDTO entity)
        {
            return repository.Add(ObjectMapper.Mapper.Map<MemberRole>(entity));
        }

        public bool Delete(int memberId, int roleId)
        {
            return repository.Remove(memberId, roleId);
        }

        public List<MemberRoleDTO> GetAllMembers(int role)
        {
            try
            {
                return ObjectMapper.Mapper.Map<List<MemberRoleDTO>>(repository.GetAllMembers(role));
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public List<MemberRoleDTO> GetAllRoles(int role)
        {
            try
            {
                return ObjectMapper.Mapper.Map<List<MemberRoleDTO>>(repository.GetAllRoles(role));
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}