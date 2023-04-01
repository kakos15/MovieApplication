using System;
using System.Net.Http;

namespace MovieApplication.Services
{
    public static class OmdbApiServiceFactory
    {
        private static readonly Lazy<OmdbApiService> _lazyOmdbApiService = new Lazy<OmdbApiService>(() =>
        {
            var httpClient = new HttpClient { BaseAddress = new Uri("http://www.omdbapi.com/") };
            return new OmdbApiService(httpClient);
        });

        public static OmdbApiService Instance => _lazyOmdbApiService.Value;
    }
}