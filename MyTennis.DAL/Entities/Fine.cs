using System;

namespace MyTennis.DAL.Entities
{
    public class Fine
    {
        public int Id { get; set; }
        public int FineNumber { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public double Amount { get; set; }
        public DateTime HandoutDate { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
