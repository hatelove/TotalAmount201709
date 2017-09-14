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
    }
}