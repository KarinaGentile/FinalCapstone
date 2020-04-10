using System;
using System.Collections.Generic;
using System.Text;

namespace SmalltownCinemaShowtimeGeneration
{
    public class Screen
    {
        public int Runtime { get; private set; }
        public int Gap { get; } = 15;
        public List<DateTime> StartTimes { get; set; }

        public Screen(int runtime)
        {
            this.Runtime = runtime;
            StartTimes = new List<DateTime>();
        }

        public void AddShowtimes()
        {
            DateTime startDate = DateTime.Now.Date;
            DateTime currDate = startDate;
            DateTime startTime = currDate.AddHours(10);

            while (currDate.AddDays(1) < startDate.AddDays(7))
            {
                
                DateTime latestStart = currDate.AddHours(22);
                

                if (CanAnotherShowtimeBeAdded(latestStart))
                {
                    StartTimes.Add(startTime);
                    startTime = startTime.AddMinutes(Runtime + Gap);

                } 
                else
                {
                    currDate = currDate.AddDays(1);
                    startTime = currDate.AddHours(10);
                }
            }
        }

        public bool CanAnotherShowtimeBeAdded(DateTime latestStart)
        {
            if (StartTimes.Count == 0)
            {
                return true;
            }

            foreach (var time in StartTimes)
            {
                if (time.AddMinutes(Runtime + Gap) > latestStart)
                {
                    return false;
                }

            }

            return true;
        }

        public void PrintShowtimes()
        {
            foreach (var time in StartTimes)
            {
                Console.WriteLine(time);
            }
        }
    }
}
