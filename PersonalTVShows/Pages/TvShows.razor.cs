using Microsoft.AspNetCore.Components;
using PersonalTVShows.Data;
using PersonalTVShows.Models.Dto;
using PersonalTVShows.Models.Entities;
using PersonalTVShows.Models.TvMazeModels;
using PersonalTVShows.Services;

namespace PersonalTVShows.Pages
{
    public partial class TvShows
    {
        [Inject]
        private ITvShowApiService _tvShowApiService { get; set; }

        [Inject]
        private IConfiguration Configuration { get; set; }

        //private List<TvShowEmbedded> ListShowsFromApi { get; set; }
        private List<TvShowDto> ListShowsDto { get; set; }

        private List<int> ListOfShowsIds;

        protected override async Task OnInitializedAsync()
        {
            LoadIdsOfShows();

            await LoadApiShowInfo();
        }

        private List<Show> LoadShows()
        {
            return SeedTvData.ListOfShows;
        }

        private void LoadIdsOfShows()
        {
            ListOfShowsIds = Configuration.GetSection("TvShows").Get<List<int>>();
        }

        private async Task LoadApiShowInfo()
        {
            //! Single Load Show
            //var loadshow = LoadShows().FirstOrDefault();
            //var response = await _tvShowApiService.GetShowById(loadshows.ShowId);
            //var response = await _tvShowApiService.GetShowPreviousNextEpisode(loadshow.ShowId);

            var loadshows = LoadShows();

            //ListShowsFromApi = new();
            ListShowsDto = new();

            try
            {
                foreach (int show in ListOfShowsIds)
                {
                    TvShowEmbedded response = await _tvShowApiService.GetShowPreviousNextEpisode(show);

                    string nextEpisodeName = string.Empty;
                    string nextEpisode = string.Empty;
                    string nextEpisodeDate = string.Empty;
                    string dayOfWeek = response.schedule.days[0];
                    string airTime = Convert.ToDateTime(response.schedule.time).ToShortTimeString();
                    //TimeOnly airTime = TimeOnly.FromDateTime(Convert.ToDateTime(response.schedule.time));

                    if (response._embedded.nextepisode is not null)
                    {
                        nextEpisode = $"{response._embedded.nextepisode.season} x {response._embedded.nextepisode.number}";
                        nextEpisodeName = response._embedded.nextepisode.name;
                        nextEpisodeDate = response._embedded.nextepisode.airdate;
                    }

                    TvShowDto tvShowDto = new TvShowDto
                    {
                        ShowName = response.name,
                        LastEpisodeName = response._embedded.previousepisode.name,
                        LastEpisode = $"{response._embedded.previousepisode.season} x {response._embedded.previousepisode.number}",
                        NextEpisodeName = nextEpisodeName,
                        NextEpisode = nextEpisode,
                        LastEpisodeDate = response._embedded.previousepisode.airdate,
                        NextEpisodeDate = nextEpisodeDate,
                        PictureSmallUrl = response.image.medium,
                        WeekDayAndTime = $"{dayOfWeek} - {airTime}"
                    };

                    //ListShowsFromApi.Add(response);
                    ListShowsDto.Add(tvShowDto);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //ListShowsDto = ListShowsFromApi.Adapt<List<TvShowDto>>();
        }
    }
}