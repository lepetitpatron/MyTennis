namespace MyTennis.Core.DTO
{
    public class ResultDTO
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public byte SetNr { get; set; }
        public byte ScoreTeamMember { get; set; }
        public byte ScoreOpponent { get; set; }
    }
}