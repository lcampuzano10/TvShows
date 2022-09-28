using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalTVShows.Models.TvMazeModels
{

	public class TvShowEmbedded : TvShow
	{
		public Embedded? _embedded { get; set; }
	}
#pragma warning restore IDE1006 // Naming Styles
}
