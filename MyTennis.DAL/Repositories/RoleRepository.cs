using MyTennis.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MyTennis.DAL.Repositories
{
    public class RoleRepository : IRepository<Role>
    {
        private readonly MyTennisDBContext _context;

        public RoleRepository(MyTennisDBContext context)
        {
            _context = context;
        }

        public int Add(Role t)
        {
            throw new System.NotImplementedException();
        }

        public Role FindById(int? id)
        {
            throw new System.NotImplementedException();
        }

        public List<Role> GetAll()
        {
            IQueryable<Role> query = _context.Set<Role>();
            IEnumerable<Role> result = query.ToList();

            return result.ToList();
        }

        public void Modify(Role t)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(Role t)
        {
            throw new System.NotImplementedException();
        }
    }
}
