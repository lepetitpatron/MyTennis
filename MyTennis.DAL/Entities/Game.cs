using System;

namespace MyTennis.DAL.Entities
{
    class Game
    {
        public int Id { get; set; }
        public string GameNumber { get; set; }
        public Member MemberId { get; set; }
        public League LeagueId { get; set; }
        public DateTime Date { get; set; }
    }
}
