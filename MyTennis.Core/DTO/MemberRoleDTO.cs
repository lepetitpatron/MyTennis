using System;

namespace MyTennis.Core.DTO
{
    public class MemberRoleDTO
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public MemberDTO Member { get; set; }
        public int RoleId { get; set; }
        public RoleDTO Role { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
