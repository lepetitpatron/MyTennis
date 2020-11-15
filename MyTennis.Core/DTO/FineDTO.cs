using System;

namespace MyTennis.Core.DTO
{
    public class FineDTO
    {
        public int Id { get; set; }
        public int FineNumber { get; set; }
        public int MemberId { get; set; }
        public double Amount { get; set; }
        public DateTime HandoutDate { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
