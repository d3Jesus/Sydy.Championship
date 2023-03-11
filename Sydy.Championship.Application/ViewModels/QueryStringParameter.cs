namespace Sydy.Championship.Application.ViewModels
{
    public class QueryStringParameter<T> where T : class
    {
        public int PageNumber { get; set; } = 1;
        public int ItemsPerPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
