﻿using System;

namespace TotalAmountTests
{
    public class Budget
    {
        public double Amount { get; set; }
        public string Month { get; set; }

        public double GetOverlappingAmount(Period period)
        {
            var periodOfBudget = new Period(this.GetStartDate(), this.GetEndDate());
            var overlappingDays = period.GetOverlappingDays(periodOfBudget);
            var dailyAmount = this.GetDailyAmount();

            return overlappingDays * dailyAmount;
        }

        private double GetDailyAmount()
        {
            var dailyAmount = this.Amount / this.GetEndDate().Day;
            return dailyAmount;
        }

        private DateTime GetEndDate()
        {
            var startDate = GetStartDate();
            var endDay = DateTime.DaysInMonth(startDate.Year, startDate.Month);
            return new DateTime(startDate.Year, startDate.Month, endDay);
        }

        private DateTime GetStartDate()
        {
            var dateInString = this.Month + "01";
            return DateTime.ParseExact(dateInString, "yyyyMMdd", null);
        }
    }
}