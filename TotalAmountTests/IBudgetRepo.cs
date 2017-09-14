using System.Collections.Generic;

namespace TotalAmountTests
{
    public interface IBudgetRepo
    {
        List<Budget> FindAll();
    }
}