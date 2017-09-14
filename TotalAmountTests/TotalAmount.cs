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
            var period = new Period(startDate, endDate);

            return budgetRepo
                .FindAll()
                .Sum(b => b.GetOverlappingAmount(period));
        }
    }
}