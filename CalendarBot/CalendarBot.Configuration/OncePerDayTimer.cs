using System;
using System.Threading;

namespace CalendarBot.Configuration
{
    public class OncePerDayTimer : IDisposable
    {
        private DateTime _lastRunDate;
        private readonly TimeSpan _time;
        private Timer _timer;
        private readonly Action _callback;

        public string UserName { get; set; }

        public OncePerDayTimer(TimeSpan time, Action callbak)
        {
            _time = time;
            _timer = new Timer(CheckTime, null, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
            _callback = callbak;

        }

        private void CheckTime(object state)
        {
            if (_lastRunDate == DateTime.Today)
            {
                return;
            }

            if (DateTime.Now.TimeOfDay < _time)
            {
                return;
            }

            _lastRunDate = DateTime.Today;
            _callback();
        }

        public void Dispose()
        {
            if (_timer == null)
            {
                return;
            }

            _timer.Dispose();
            _timer = null;
        }
    }
}
