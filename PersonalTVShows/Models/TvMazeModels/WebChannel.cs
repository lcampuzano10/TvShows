namespace PersonalTVShows.Models.TvMazeModels
{
    public class WebChannel
	{
        public int Id { get; set; }
        public string name { get; set; }
        public Country country { get; set; }
        public string officialSite { get; set; }
    }
}
