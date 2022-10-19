using System;

namespace WebClient.Models
{
    public class EventViewModel
    {
        public Int64 EventID { get; set; }

        public String Subject { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public bool IsFullDay { get; set; }
    }
}
