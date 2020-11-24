using MyTennis.BLL.Utilities;
using MyTennis.Core.DTO;
using MyTennis.DAL;
using MyTennis.DAL.Entities;
using MyTennis.DAL.Repositories;
using System;
using System.Collections.Generic;

namespace MyTennis.BLL.Logic
{
    public class MemberLogic : ILogic<MemberDTO>
    {
        private readonly MyTennisDBContext _context = new MyTennisDBContext();
        private readonly MemberRepository repository;

        public MemberLogic()
        {
            repository = new MemberRepository(_context);       
        }

        public bool Create(MemberDTO entity)
        {
            return repository.Add(ObjectMapper.Mapper.Map<Member>(entity));
        }

        public bool Delete(int id)
        {
            return repository.Remove(id);
        }

        public MemberDTO FindById(int id)
        {
            try
            {
                return ObjectMapper.Mapper.Map<MemberDTO>(repository.FindById(id));
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public List<MemberDTO> GetAll()
        {
            try
            {
                return ObjectMapper.Mapper.Map<List<MemberDTO>>(repository.GetAll());
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public bool Update(MemberDTO entity)
        {
            return repository.Modify(ObjectMapper.Mapper.Map<Member>(entity));
        }
    }
}
