using Microsoft.AspNetCore.Components;
using PersonalTVShows.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalTVShows.Data
{
	public class SeedTvData
	{
		public static List<Show> ListOfShows => new List<Show>
		{
			new Show { ShowId = 60, ShowName = "NCIS"},
			//new Show { ShowId = 72, ShowName = "NCIS: LA"},
			new Show { ShowId = 53629, ShowName = "NCIS: Hawaii"},
			new Show { ShowId = 56, ShowName = "Chicago PD"},
			new Show { ShowId = 59, ShowName = "Chicago Fire"},
			new Show { ShowId = 28160, ShowName = "Seal Team"},
			new Show { ShowId = 28152, ShowName = "9-1-1"},
			new Show { ShowId = 21532, ShowName = "S.W.A.T."},
			new Show { ShowId = 69, ShowName = "The Blacklist"},
			new Show { ShowId = 32158, ShowName = "FBI"},
			new Show { ShowId = 53659, ShowName = "FBI: International"},
			new Show { ShowId = 46562, ShowName = "The Last of Us"},
			new Show { ShowId = 58846, ShowName = "Dexter: New Blood"},
			new Show { ShowId = 45975, ShowName = "The Cleaning Lady"},
			new Show { ShowId = 45840, ShowName = "Mayor of Kingstown"},
			new Show { ShowId = 44391, ShowName = "Walker"},
			new Show { ShowId = 60285, ShowName = "Rabbit Hole"},
		};
	}
}
