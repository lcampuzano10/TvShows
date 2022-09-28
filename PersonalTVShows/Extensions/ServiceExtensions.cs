using PersonalTVShows.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PersonalTVShows.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureAPiServices(this IServiceCollection services)
        {
            services.AddScoped<ITvShowApiService, TvMazeApiService>();
        }

        public static void ConfigureHttpClient(this IServiceCollection services)
        {
            //Add this Microsoft.Extensions.Http
            services.AddHttpClient("TvMazeApi", client =>
            {
                var baseAddress = new Uri("https://api.tvmaze.com");
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");

                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(contentType);
            });
        }
    }
}
