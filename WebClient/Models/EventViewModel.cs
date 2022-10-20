using System;

namespace WebClient.Models
{
    public class EventViewModel
    {
        public Int64 eventID { get; set; }

        public string title { get; set; }

        public DateTime start { get; set; }

        public DateTime end { get; set; }

        public bool isFullDay { get; set; }
    }
}
