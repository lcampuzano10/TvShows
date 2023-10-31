using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalTVShows.Models.TvMazeModels
{
    public class TvShow
	{
		public Links? _links { get; set; }
		public int? averageRuntime { get; set; }
		public object dvdCountry { get; set; }
		public object ended { get; set; }
		public Externals? externals { get; set; }
		public string[]? genres { get; set; }
		public int? id { get; set; }
		public Image? image { get; set; }
		public string? language { get; set; }
		public string? name { get; set; }
		public Network? network { get; set; }
		public string? officialSite { get; set; }
		public string? premiered { get; set; }
		public Rating? rating { get; set; }
		public int? runtime { get; set; }
		public Schedule? schedule { get; set; }
		public string? status { get; set; }
		public string? summary { get; set; }
		public string? type { get; set; }
		public int? updated { get; set; }
		public string? url { get; set; }
		public WebChannel? webChannel { get; set; }
		public int? weight { get; set; }
	}
}
