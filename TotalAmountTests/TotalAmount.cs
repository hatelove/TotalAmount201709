using System;
using System.Linq;

namespace TotalAmountTests
{
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
                var start = GetDateFromString(startDate);
                var end = GetDateFromString(endDate);

                var isBeforeMonth = end < budget.GetStartDate();
                var isAfterMonth = start > budget.GetEndDate();

                if (isBeforeMonth || isAfterMonth)
                {
                    return 0;
                }
                else
                {
                    var overlapStart = start > budget.GetStartDate() ? start : budget.GetStartDate();
                    var daysOfPeriod = (end.AddDays(1) - overlapStart).Days;
                    return daysOfPeriod;
                }
            }
        }

        private DateTime GetDateFromString(string dateInString)
        {
            return DateTime.ParseExact(dateInString, "yyyyMMdd", null);
        }
    }
}