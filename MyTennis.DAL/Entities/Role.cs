using System.Collections.Generic;

namespace MyTennis.DAL.Entities
{
    class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<MemberRole> MemberRoles { get; set; }
    }
}