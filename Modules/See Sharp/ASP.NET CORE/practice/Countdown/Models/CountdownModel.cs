using System;

namespace Countdown.Models
{
    public class CountdownModel
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan TimeRemaining => EndTime - StartTime;
    }
}