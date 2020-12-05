using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyTennis.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyTennis.DAL.Repositories
{
    public class MemberRoleRepository
    {
        private readonly MyTennisDBContext _context;

        public MemberRoleRepository(MyTennisDBContext context)
        {
            _context = context;
        }

        public bool Add(MemberRole t)
        {
            try
            {
                _context.MemberRole.Add(t);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<MemberRole> GetAllMembers(int role)
        {
            return _context.MemberRole.FromSqlRaw($"SELECT * FROM MemberRole WHERE RoleId = {role}").ToList();
        }

        public List<MemberRole> GetAllRoles(int member)
        {
            return _context.MemberRole.FromSqlRaw($"SELECT * FROM MemberRole WHERE MemberId = {member}").ToList();
        }

        public bool Remove(int memberId, int roleId)
        {
            MemberRole entity = _context.MemberRole.FromSqlRaw($"SELECT * FROM MemberRole WHERE MemberId = {memberId} AND RoleId = {roleId} AND EndDate = '9999-1-1'").FirstOrDefault();
            if (entity == null) return false;

            MemberRole removedMemberRole = _context.MemberRole.FromSqlRaw($"SELECT * FROM MemberRole WHERE MemberId = {memberId} AND RoleId = {roleId} AND EndDate = '9999-1-1'").FirstOrDefault();
            removedMemberRole.EndDate = DateTime.Today;

            EntityEntry entry = _context.Entry(entity);
            entry.CurrentValues.SetValues(removedMemberRole);
            _context.SaveChanges();

            return true;
        }
    }
}