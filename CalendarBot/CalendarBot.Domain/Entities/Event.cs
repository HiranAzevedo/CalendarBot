using System;

namespace CalendarBot.Domain
{
    public class Event
    {
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
