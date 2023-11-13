using PersonalTVShows.Models.TvMazeModels;
using System.Text.Json;

namespace PersonalTVShows.Services
{
    public class TvMazeApiService : ITvShowApiService
    {
        #region Fields

        public HttpClient _httpClient;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;
        private readonly JsonSerializerOptions _options;

        public TvMazeApiService(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
            _httpClient = _clientFactory.CreateClient("TvMazeApi");
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            };
        }

        #endregion Fields

        #region Methods

        public async Task<TvShow> GetShowById(int showId)
        {
            TvShow jsonResponse = new();
            try
            {
                HttpResponseMessage getResponse = await _httpClient.GetAsync($"shows/{showId}");

                getResponse.EnsureSuccessStatusCode();

                if (getResponse.IsSuccessStatusCode)
                {
                    var response = await getResponse.Content.ReadAsStringAsync();
                    jsonResponse = System.Text.Json.JsonSerializer.Deserialize<TvShow>(response, _options);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return jsonResponse;
        }

        public async Task<TvShowEmbedded> GetShowPreviousNextEpisode(int showId, bool embeded = true)
        {
            TvShowEmbedded jsonResponse = new();
            string embededOption = string.Empty;
            try
            {
                if (embeded)
                {
                    embededOption = "embed[]=previousepisode&embed[]=nextepisode";
                }

                HttpResponseMessage getResponse = await _httpClient.GetAsync($"shows/{showId}?{embededOption}");

                getResponse.EnsureSuccessStatusCode();

                if (getResponse.IsSuccessStatusCode)
                {
                    var response = await getResponse.Content.ReadAsStringAsync();
                    jsonResponse = JsonSerializer.Deserialize<TvShowEmbedded>(response, _options);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return jsonResponse;
        }

        #endregion Methods
    }
}