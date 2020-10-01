namespace MyTennis.DAL.Entities
{
    class Result
    {
        public int Id { get; set; }
        public Game GameId { get; set; }
        public int SetNr { get; set; }
        public int ScoreTeamMember { get; set; }
        public int ScoreOpponent { get; set; }
    }
}
