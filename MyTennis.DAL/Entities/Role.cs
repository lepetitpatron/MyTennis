using System.Collections.Generic;

namespace MyTennis.DAL.Entities
{
    class Role
    {
        public Role()
        {
            Members = new HashSet<Member>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}