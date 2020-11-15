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

        public bool Delete(int entity)
        {
            throw new NotImplementedException();
        }

        public MemberDTO FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<MemberDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(MemberDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
