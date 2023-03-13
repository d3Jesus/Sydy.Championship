namespace Sydy.Championship.CoreBusiness.Entities
{
    public class ChampionshipModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Champion { get; set; }
        public string Vice { get; set; }
        public string ThirdPlace { get; set; }

        public List<MatchModel> Matches { get; set; }
        public List<VwMatchResultsModel> MatchesResult { get; set; }
    }
}
