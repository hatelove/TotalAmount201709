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
            return budgetRepo
                .FindAll()
                .Sum(b => b.GetOverlappingAmount(new Period(startDate, endDate)));
        }
    }
}