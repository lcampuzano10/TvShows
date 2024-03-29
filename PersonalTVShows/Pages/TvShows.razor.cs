﻿using Microsoft.AspNetCore.Components;
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

        private List<TvShowDto> ListShowsDto { get; set; } = new();

        private List<int> ListOfShowsIds { get; set; } = new();

        public bool IsBusy { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;
            LoadIdsOfShows();

            await LoadApiShowInfo();

            IsBusy = false;

            StateHasChanged();
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
            int listCount = 1;
            string nextEpisodeName = string.Empty;
            string nextEpisode = string.Empty;
            string nextEpisodeDate = string.Empty;
            string airTime = string.Empty;
            string networkChannel = string.Empty;
            //! Single Load Show
            //var loadshow = LoadShows().FirstOrDefault();
            //var response = await _tvShowApiService.GetShowById(loadshows.ShowId);
            //var response = await _tvShowApiService.GetShowPreviousNextEpisode(loadshow.ShowId);

            //var loadshows = LoadShows();

            try
            {
                foreach (var (show, index) in ListOfShowsIds.Select((value, i) => (value, i)))
                {
                    if (index is not 0 && index % 20 == 0)
                        await Task.Delay(TimeSpan.FromSeconds(15));

                    TvShowEmbedded response = await _tvShowApiService.GetShowPreviousNextEpisode(show);

                    string dayOfWeek = response.schedule.days[0];

                    if (response._embedded.nextepisode is not null)
                    {
                        nextEpisode = $"{response._embedded.nextepisode.season} x {response._embedded.nextepisode.number}";
                        nextEpisodeName = response._embedded.nextepisode.name;
                        nextEpisodeDate = response._embedded.nextepisode.airdate;
                    }

                    if (!string.IsNullOrWhiteSpace(response.schedule.time))
                        airTime = Convert.ToDateTime(response.schedule.time).ToShortTimeString();

                    if (response.network is not null && !string.IsNullOrEmpty(response.network.name))
                        networkChannel = response.network.name;
                    else
                    {
                        if (!string.IsNullOrEmpty(response.webChannel.name))
                            networkChannel = response.webChannel.name;
                    }

                    TvShowDto tvShowDto = new TvShowDto
                    {
                        Id = listCount,
                        ShowName = response.name,
                        LastEpisodeName = response._embedded.previousepisode.name,
                        LastEpisode = $"{response._embedded.previousepisode.season} x {response._embedded.previousepisode.number}",
                        NextEpisodeName = nextEpisodeName,
                        NextEpisode = nextEpisode,
                        LastEpisodeDate = response._embedded.previousepisode.airdate,
                        NextEpisodeDate = nextEpisodeDate,
                        PictureSmallUrl = response.image.medium,
                        WeekDayAndTime = $"{dayOfWeek} - {airTime}",
                        NetworkChannelName = networkChannel,
                    };

                    ListShowsDto.Add(tvShowDto);

                    listCount++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
    }
}