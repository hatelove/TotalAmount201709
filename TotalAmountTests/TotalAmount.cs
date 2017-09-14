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
                var isBeforeMonth = GetDateFromString(endDate) < budget.GetStartDate();
                var isAfterMonth = GetDateFromString(startDate) > budget.GetEndDate();

                if (isBeforeMonth || isAfterMonth)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }

        private DateTime GetDateFromString(string dateInString)
        {
            return DateTime.ParseExact(dateInString, "yyyyMMdd", null);
        }
    }
}