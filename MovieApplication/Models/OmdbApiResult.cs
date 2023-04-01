namespace MovieApplication.Models
{
    public class OmdbApiResult
    {
        public List<MovieSummary> Search { get; set; }
        public string TotalResults { get; set; }
        public string Response { get; set; }
    }
}
