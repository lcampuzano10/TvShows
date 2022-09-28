using PersonalTVShows.Models.TvMazeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalTVShows.Services
{
	public interface ITvShowApiService
	{
		Task<TvShow> GetShowById(int showId);
		Task<TvShowEmbedded> GetShowPreviousNextEpisode(int showId, bool embeded = true);
	}
}
