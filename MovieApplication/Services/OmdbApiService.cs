using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MovieApplication.Models;

namespace MovieApplication.Services
{
    public class OmdbApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "7946c653"; // Replace with your OMDB API key

        public OmdbApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        //added null last
        public async Task<OmdbApiResult> SearchMoviesAsync(string title, string year =null)
        {
            var url = $"?apikey={_apiKey}&s={title}&type=movie";

            if (!string.IsNullOrEmpty(year))
            {
                url += $"&y={year}";
            }

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var searchResult = JsonSerializer.Deserialize<OmdbApiResult>(responseBody);

            return searchResult;
        }

        public async Task<MovieDetails> GetMovieDetailsAsync(string imdbId)
        {
            var url = $"?apikey={_apiKey}&i={imdbId}&plot=full";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var movieDetails = JsonSerializer.Deserialize<MovieDetails>(responseBody);

            return movieDetails;
        }
    }
}