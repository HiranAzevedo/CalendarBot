﻿using System;
using System.Collections.Generic;

namespace CalendarBot.Domain.Entities
{
    public class CalendarOfEvents
    {
        public CalendarOfEvents()
        {
            Events = new List<EventScheduled>();
        }

        public List<EventScheduled> Events { get; set; }

        public bool AlarmSetUp { get; set; }

        public DateTime TimeOfWaring { get; set; }

        public string OwnerUserName { get; set; }
    }
}
