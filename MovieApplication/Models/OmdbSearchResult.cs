using System.Collections.Generic;
namespace MovieApplication.Models
{
    public class OmdbSearchResult
    {
        public List<Movie> Search { get; set; }
    }

    public class Movie
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string imdbID { get; set; }
        public string Poster { get; set; }
    }
}
