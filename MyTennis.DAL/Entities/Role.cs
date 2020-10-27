using System.Collections.Generic;

namespace MyTennis.DAL.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<MemberRole> MemberRoles { get; set; }
    }
}