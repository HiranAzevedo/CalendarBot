using CalendarBot.Domain.Entities;
using CalendarBot.Domain.Interfaces.Repository;
using CalendarBot.Repository.Context;
using System.Collections.Generic;
using System.Linq;

namespace CalendarBot.Repository.Repositories
{
    public class CalendarRepository : ICalendarRepository
    {
        private readonly DataBase _db;

        public CalendarRepository(DataBase dataBase)
        {
            _db = dataBase;
        }

        public void Add(CalendarOfEvents obj)
        {
            _db.Storage.Add(obj.OwnerUserName, obj);
        }

        public void AddEvent(EventScheduled @event, string userName)
        {
            if (_db.Storage.ContainsKey(userName))
            {
                _db.Storage[userName]?.Events.Add(@event);
            }
        }

        public void Dispose()
        {
        }

        public IEnumerable<CalendarOfEvents> GetAll()
        {
            return _db.Storage.Values;
        }

        public CalendarOfEvents GetById(string id)
        {
            if (_db.Storage.ContainsKey(id))
            {
                return _db.Storage[id];
            }

            return null;
        }

        public EventScheduled GetEvent(int id, string userName)
        {
            if (_db.Storage.ContainsKey(userName))
            {
                return _db.Storage[userName].Events.FirstOrDefault(x => x.Id == id);
            }

            return null;
        }

        public int GetNextEventId(string userName)
        {
            if (_db.Storage.ContainsKey(userName))
            {
                var maxId = _db.Storage[userName].Events.Max(x => x.Id);
                return ++maxId;
            }
            return 0;
        }

        public void Remove(CalendarOfEvents obj)
        {
            _db.Storage.Remove(obj.OwnerUserName);
        }

        public void RemoveEvent(EventScheduled @event, string userName)
        {
            if (_db.Storage.ContainsKey(userName))
            {
                _db.Storage[userName].Events.Remove(@event);
            }
        }

        public void Update(CalendarOfEvents obj)
        {
            _db.Storage.Remove(obj.OwnerUserName);
            _db.Storage.Add(obj.OwnerUserName, obj);
        }

        public void UpdateEvent(EventScheduled @event, string userName)
        {
            if (!_db.Storage.ContainsKey(userName))
            {
                return;
            }

            _db.Storage[userName].Events.Remove(_db.Storage[userName].Events.FirstOrDefault(x => x.Id == @event.Id));
            _db.Storage[userName].Events.Add(@event);
        }
    }
}
