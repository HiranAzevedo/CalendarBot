using CalendarBot.Domain.Entities;
using CalendarBot.Domain.Interfaces.Repository;
using CalendarBot.Domain.Interfaces.Service;
using System.Collections.Generic;

namespace CalendarBot.Service
{
    public class CalendarService : ICalendarService
    {
        private readonly ICalendarRepository _repository;

        public CalendarService(ICalendarRepository repository)
        {
            _repository = repository;
        }

        public void Add(CalendarOfEvents obj)
        {
            _repository.Add(obj);
        }

        public CalendarOfEvents GetById(string id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<CalendarOfEvents> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(CalendarOfEvents obj)
        {
            _repository.Update(obj);
        }

        public void Remove(CalendarOfEvents obj)
        {
            _repository.Remove(obj);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public void AddEvent(EventScheduled @event, string userName)
        {
            _repository.AddEvent(@event, userName);
        }

        public void RemoveEvent(EventScheduled @event, string userName)
        {
            _repository.RemoveEvent(@event, userName);
        }

        public void UpdateEvent(EventScheduled @event, string userName)
        {
            _repository.UpdateEvent(@event, userName);
        }

        public EventScheduled GetEvent(int id, string userName)
        {
            return _repository.GetEvent(id, userName);
        }

        public int GetNextEventId(string userName)
        {
            return _repository.GetNextEventId(userName);
        }
    }
}
