using System;

namespace MyTennis.DAL.Entities
{
    class Fine
    {
        public int Id { get; set; }
        public int FineNumber { get; set; }
        public Member MemberId { get; set; }
        public double Amount { get; set; }
        public DateTime HandoutDate { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
