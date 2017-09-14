using System;

namespace TotalAmountTests
{
    public class Period
    {
        public Period(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public int GetOverlappingDays(Period another)
        {
            var overlapStart = this.Start > another.Start ? this.Start : another.Start;
            var overlapEnd = this.End < another.End ? this.End : another.End;
            return (overlapEnd.AddDays(1) - overlapStart).Days;
        }
    }
}