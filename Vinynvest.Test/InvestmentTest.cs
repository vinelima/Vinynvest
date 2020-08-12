using System;
using Xunit;
using Vinynvest.Application;
using Vinynvest.Application.Investment.Enums;

namespace Vinynvest.Test
{
    public class InvestmentTest
    {
        public readonly InvestmentService _investmentService;
        public InvestmentTest()
        {
            _investmentService = new InvestmentService();
        }
        [Fact]
        public void IncomeTaxMustReturnCorrectValueTreasurie()
        {
            var result = _investmentService.IncomeTax(20000, 14000, InvestmentType.Treasurie); 
            Assert.Equal(600, result);
        }
        [Fact]
        public void IncomeTaxMustReturnCorrectValueFixedIncome()
        {
            var result = _investmentService.IncomeTax(20000, 14000, InvestmentType.FixedIncome); 
            Assert.Equal(300, result);
        }

        [Fact]
        public void IncomeTaxMustReturnCorrectValueFund()
        {
            var result = _investmentService.IncomeTax(20000, 14000, InvestmentType.Fund); 
            Assert.Equal(900, result);
        }

        [Fact]
        public void IncomeTaxMustReturnIncorrectValueTreasurie()
        {
            var result = _investmentService.IncomeTax(20000, 14001, InvestmentType.Fund); 
            Assert.False(result == 599.9m);
        }

        [Fact]
        public void IncomeTaxMustReturnIncorrectValueFixedIncome()
        {
            var result = _investmentService.IncomeTax(20000, 14005, InvestmentType.Treasurie); 
            Assert.False(result == 299.75m);
        }

        [Fact]
        public void IncomeTaxMustReturnIncorrectValueFund()
        {
            var result = _investmentService.IncomeTax(20000, 14010, InvestmentType.FixedIncome); 
            Assert.False(result == 898.5m);
        }

        [Fact]
        public void RedemptionValueMustReturnCorrectValueMoreThanHalfTheTimeInCustody()
        {
            var result = _investmentService.RedemptionValue(new DateTime(2019, 1, 1), new DateTime(2021, 12, 31), 14000); 
            Assert.Equal(11900, result);
        }
        [Fact]
        public void RedemptionValueMustReturnCorrectValueThreeMonthsToExpire()
        {
            var result = _investmentService.RedemptionValue(new DateTime(2020, 6, 1), new DateTime(2020, 10, 31), 14000); 
            Assert.Equal(13160, result);
        }

        [Fact]
        public void RedemptionValueMustReturnCorrectValueOthers()
        {
            var result = _investmentService.RedemptionValue(new DateTime(2020, 6, 1), new DateTime(2021, 12, 31), 14000); 
            Assert.Equal(9800, result);
        }

        [Fact]
        public void RedemptionValueMustReturnIncorrectValueMoreThanHalfTheTimeInCustody()
        {
            var result = _investmentService.RedemptionValue(new DateTime(2020, 6, 1), new DateTime(2021, 12, 31), 14000); 
            Assert.False(result == 11900);
        }

        [Fact]
        public void RedemptionValueMustReturnIncorrectValueThreeMonthsToExpire()
        {
            var result = _investmentService.RedemptionValue(new DateTime(2020, 1, 1), new DateTime(2021, 12, 31), 14000); 
            Assert.False(result == 13160);
        }

        [Fact]
        public void RedemptionValueMustReturnIncorrectValueOthers()
        {
            var result = _investmentService.RedemptionValue(new DateTime(2020, 6, 1), new DateTime(2020, 10, 31), 14000); 
            Assert.False(result == 9800);
        }
    }
}
