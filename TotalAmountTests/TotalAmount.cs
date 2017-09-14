using System;

namespace TotalAmountTests
{
    public class TotalAmount
    {
        private IBudgetRepo stubBudgetRepo;

        public TotalAmount(IBudgetRepo stubBudgetRepo)
        {
            this.stubBudgetRepo = stubBudgetRepo;
        }

        public double query(string startDate, string endDate)
        {
            return 0;
        }
    }
}