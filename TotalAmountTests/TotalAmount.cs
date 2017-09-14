using System;
using System.Linq;

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

    public class TotalAmount
    {
        private IBudgetRepo budgetRepo;

        public TotalAmount(IBudgetRepo budgetRepo)
        {
            this.budgetRepo = budgetRepo;
        }

        public double Query(string startDate, string endDate)
        {
            var budget = budgetRepo.FindAll().FirstOrDefault();
            if (budget == null)
            {
                return 0;
            }
            else
            {
                var period = new Period(GetDateFromString(startDate), GetDateFromString(endDate));
                return budget.GetOverlappingAmount(period);
            }
        }

        private DateTime GetDateFromString(string dateInString)
        {
            return DateTime.ParseExact(dateInString, "yyyyMMdd", null);
        }
    }
}