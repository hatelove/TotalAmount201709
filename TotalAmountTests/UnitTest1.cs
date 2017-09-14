using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Linq;

namespace TotalAmountTests
{
    [TestClass]
    public class UnitTest1
    {
        private IBudgetRepo repo = Substitute.For<IBudgetRepo>();

        [TestMethod]
        public void no_planned_budgets_AmountShouldBe_0()
        {
            GivenAllBudgets();

            EffectiveAmountShouldBe(0, "20170620", "20170715");
        }

        [TestMethod]
        public void has_a_budget_only_1_day()
        {
            GivenAllBudgets(new Budget { Month = "201707", Amount = 31 });
            EffectiveAmountShouldBe(1, "20170701", "20170701");
        }

        [TestMethod]
        public void has_a_budget_period_before_month()
        {
            GivenAllBudgets(new Budget { Month = "201707", Amount = 31 });
            EffectiveAmountShouldBe(0, "20170630", "20170630");
        }

        [TestMethod]
        public void has_a_budget_period_after_month()
        {
            GivenAllBudgets(new Budget { Month = "201707", Amount = 31 });
            EffectiveAmountShouldBe(0, "20170801", "20170801");
        }

        [TestMethod]
        public void has_a_budget_period_has_2_days()
        {
            GivenAllBudgets(new Budget { Amount = 31, Month = "201707" });
            EffectiveAmountShouldBe(2, "20170701", "20170702");

        }

        private void EffectiveAmountShouldBe(int expected, string startDate, string endDate)
        {
            var totalAmount = new TotalAmount(repo);

            var actual = totalAmount.Query(startDate, endDate);

            Assert.AreEqual(expected, actual);
        }

        private void GivenAllBudgets(params Budget[] budgets)
        {
            this.repo.FindAll().Returns(budgets.ToList());
        }
    }
}