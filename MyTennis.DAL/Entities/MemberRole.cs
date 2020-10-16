using System;

namespace MyTennis.DAL.Entities
{
    class MemberRole
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}