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
        public void MustReturnCorrectValueTreasurie()
        {
            var result = _investmentService.IncomeTax(20000, 14000, InvestmentType.Treasurie); 
            Assert.Equal(600, result);
        }
        [Fact]
        public void MustReturnCorrectValueFixedIncome()
        {
            var result = _investmentService.IncomeTax(20000, 14000, InvestmentType.FixedIncome); 
            Assert.Equal(300, result);
        }

        [Fact]
        public void MustReturnCorrectValueFund()
        {
            var result = _investmentService.IncomeTax(20000, 14000, InvestmentType.Fund); 
            Assert.Equal(900, result);
        }

        [Fact]
        public void MustReturnIncorrectValueTreasurie()
        {
            var result = _investmentService.IncomeTax(20000, 14001, InvestmentType.Treasurie); 
            Assert.True(result != 600);
        }

        [Fact]
        public void MustReturnIncorrectValueFixedIncome()
        {
            var result = _investmentService.IncomeTax(20000, 14005, InvestmentType.FixedIncome); 
            Assert.True(result != 300);
        }

        [Fact]
        public void MustReturnIncorrectValueFund()
        {
            var result = _investmentService.IncomeTax(20000, 14010, InvestmentType.Fund); 
            Assert.True(result != 900);
        }
    }
}
