using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace TotalAmountTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void no_planned_budgets_AmountShouldBe_0()
        {
            var stubBudgetRepo = Substitute.For<IBudgetRepo>();
            stubBudgetRepo.FindAll().Returns(new List<Budget>());

            var totalAmount = new TotalAmount(stubBudgetRepo);

            var actual = totalAmount.query("20170620", "20170715");

            Assert.AreEqual(150, actual);
        }
    }

    public class Budget
    {
    }

    public interface IBudgetRepo
    {
        List<Budget> FindAll();
    }

    public class TotalAmount
    {
        private IBudgetRepo stubBudgetRepo;

        public TotalAmount(IBudgetRepo stubBudgetRepo)
        {
            this.stubBudgetRepo = stubBudgetRepo;
        }

        public double query(string startDate, string endDate)
        {
            throw new NotImplementedException();
        }
    }
}
