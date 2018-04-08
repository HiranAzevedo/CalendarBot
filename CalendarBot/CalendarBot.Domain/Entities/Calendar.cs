using System.Collections.Generic;

namespace CalendarBot.Domain
{
    public class Calendar
    {
        public List<Event> Events { get; set; }

        public string OwnerUserName { get; set; }
    }
}
