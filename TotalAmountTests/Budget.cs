using System;

namespace TotalAmountTests
{
    public class Budget
    {
        public string Month { get; set; }
        public double Amount { get; set; }

        public DateTime GetStartDate()
        {
            var dateInString = this.Month + "01";
            return DateTime.ParseExact(dateInString, "yyyyMMdd", null);
        }

        public DateTime GetEndDate()
        {
            var startDate = GetStartDate();
            var endDay = DateTime.DaysInMonth(startDate.Year, startDate.Month);
            return new DateTime(startDate.Year, startDate.Month, endDay);
        }

        public double GetDailyAmount()
        {
            var dailyAmount = this.Amount / this.GetEndDate().Day;
            return dailyAmount;
        }

        public double GetOverlappingAmount(Period period)
        {
            var hasOverlap = this.HasOverlap(period);
            if (hasOverlap)
            {
                return 0;
            }
            else
            {
                var daysOfPeriod = this.GetOverlappingDays(period);
                var dailyAmount = this.GetDailyAmount();

                return daysOfPeriod * dailyAmount;
            }
        }

        private int GetOverlappingDays(Period period)
        {
            var overlapStart = period.Start > this.GetStartDate() ? period.Start : this.GetStartDate();
            var overlapEnd = period.End < this.GetEndDate() ? period.End : this.GetEndDate();
            var daysOfPeriod = (overlapEnd.AddDays(1) - overlapStart).Days;
            return daysOfPeriod;
        }

        public bool HasOverlap(Period period)
        {
            var isBeforeMonth = period.End < this.GetStartDate();
            var isAfterMonth = period.Start > this.GetEndDate();

            var hasOverlap = isBeforeMonth || isAfterMonth;
            return hasOverlap;
        }
    }
}