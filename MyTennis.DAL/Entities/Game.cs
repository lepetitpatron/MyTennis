using System;

namespace MyTennis.DAL.Entities
{
    class Game
    {
        public int Id { get; set; }
        public string GameNumber { get; set; }
        public Member Member { get; set; }
        public League League { get; set; }
        public DateTime Date { get; set; }
    }
}
