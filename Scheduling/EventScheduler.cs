using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace ScreenCapture.Scheduling
{
    public class EventScheduler
    {
        List<Timer> scheduledTimers = new();
        Dictionary<Timer, string> timers = new Dictionary<Timer, string>();

        public void ScheduleEvent(DateTime time, Action OnEvent)
        {
            Timer timer = new Timer();
            double interval = (time - DateTime.Now).TotalMilliseconds;
            if (interval < 0)
            {
                //Log message failed to fire event
                return;
            }
            timer.Interval = (int)interval;

            timer.Start();
            AddScheduledCapture(timer, time.ToString("HH:mm:ss"));
            timer.Tick += (sender, e) =>
            {
                RemoveScheduledTimer(timer);
                timer.Stop();
                OnEvent?.Invoke();   
            };
        }

        public void ScheduleEvents(List<DateTime> events, Action OnEvent) 
        {
            foreach(DateTime time in events)
            {
                ScheduleEvent(time, OnEvent);
            }
        }

        private void RemoveScheduledTimer(Timer timer)
        {
            scheduledTimers.Remove(timer);
            timers.Remove(timer);
            timer.Dispose();
        }

        private void AddScheduledCapture(Timer timer, string value)
        {
            scheduledTimers.Add(timer);
            timers.Add(timer, value);
        }

        public List<Timer> ScheduledTimers { get {  return scheduledTimers; } }

        public List<string> GetTimes()
        {
            return timers.Values.ToList();
        }
    }
}
