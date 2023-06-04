using System;

namespace UrlShortener.Models
{
    public class History
    {
        public int HistoryID { get; set; }
        public Link UrlVisited { get; set; }
        public User UserVisited { get; set; }
        public DateTime AccessTime { get; set; }
        public string Ip{ get; set; }
    }
}
