namespace MyTennis.DAL.Entities
{
    class Result
    {
        public int Id { get; set; }
        public Game Game { get; set; }
        public byte SetNr { get; set; }
        public byte ScoreTeamMember { get; set; }
        public byte ScoreOpponent { get; set; }
    }
}
