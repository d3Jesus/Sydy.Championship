namespace Sydy.Championship.CoreBusiness.Entities
{
    public class VwMatchResultsModel
    {
        public int Id { get; set; }
        public string Teams { get; set; }
        public string Results { get; set; }
        public DateTime Date { get; set; }

        public int ChampionshipId { get; set; }

        public virtual ChampionshipModel VwChampionship { get; set; }
    }
}
