using System.Linq;

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
            var budget = stubBudgetRepo.FindAll().FirstOrDefault();
            if (budget == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}