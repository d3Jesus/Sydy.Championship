namespace Sydy.Championship.Application.ViewModels.Championship
{
    public class GetChampionshipViewModel
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public string Champion { get; set; }
        public string Vice { get; set; }
        public string ThirdPlace { get; set; }
        public IEnumerable<GetVwMatchResultsViewModel> MatchesResult { get; set; }
    }
}
