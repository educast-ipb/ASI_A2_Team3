namespace Educast.Models
{
    public class Chapter
    {
        public long id { get; set; }
        public string title { get; set; }
        public int startTimeSec { get; set; }
        public int endTimeSec { get; set; }
    }
}