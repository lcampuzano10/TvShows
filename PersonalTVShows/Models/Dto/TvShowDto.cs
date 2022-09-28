using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalTVShows.Models.Dto
{
	public class TvShowDto
	{
		public string ShowName { get; set; }
		public string LastEpisode { get; set; }
		public string LastEpisodeName { get; set; }
		public string NextEpisode { get; set; }
		public string NextEpisodeName { get; set; }
		public string PictureSmallUrl { get; set; }
		public string LastEpisodeDate { get; set; }
		public string NextEpisodeDate { get; set; }
	}
}
