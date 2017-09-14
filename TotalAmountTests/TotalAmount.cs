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
                DateTime end = GetDateFromString(endDate);
                if (end < budget.GetStartDate())
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
            var date = DateTime.ParseExact(dateInString, "yyyyMMdd", null);
            return date;
        }
    }
}