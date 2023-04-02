namespace Zaj2.Models
{
    public class Photos
    {
        public Urls urls { get; set; }
        public class Urls
        {
            public string full { get; set; }
            public string thumb { get; set; }
        }
    }
}
