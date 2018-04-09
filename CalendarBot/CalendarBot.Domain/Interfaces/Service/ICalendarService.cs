using CalendarBot.Domain.Entities;

namespace CalendarBot.Domain.Interfaces.Service
{
    public interface ICalendarService : IServiceBase<CalendarOfEvents>
    {
        void AddEvent(EventScheduled @event, string userName);

        void RemoveEvent(EventScheduled @event, string userName);

        void UpdateEvent(EventScheduled @event, string userName);

        EventScheduled GetEvent(int id, string userName);

        int GetNextEventId(string userName);
    }
}
