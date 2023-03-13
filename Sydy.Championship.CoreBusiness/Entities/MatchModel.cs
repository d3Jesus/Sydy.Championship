namespace Sydy.Championship.CoreBusiness.Entities
{
    public class MatchModel
    {
        public int Id { get; set; }
        public int FirstTeamId { get; set; }
        public TeamModel FirstTeam { get; set; }
        public int FirstTeamGoals { get; set; }
        public int SecondTeamId { get; set; }
        public static TeamModel SecondTeam { get; set; }
        public int SecondTeamGoals { get; set; }
        public DateTime Date { get; set; }

        public int ChampionshipId { get; set; }
        public virtual ChampionshipModel Championship { get; set; }

    }
}
