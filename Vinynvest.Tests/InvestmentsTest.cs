using System;
using Xunit;
using Vinynvest.Application;
using Vinynvest.Application.Investment.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace investments.tests
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
        Assert.AreEqual(600, result);
    }

    [Fact]
    public void MustReturnCorrectValueFixedIncome()
    {
        var result = _investmentService.IncomeTax(20000, 14000, InvestmentType.FixedIncome); 
        Assert.AreEqual(300, result);
    }

    [Fact]
    public void MustReturnCorrectValueFund()
    {
        var result = _investmentService.IncomeTax(20000, 14000, InvestmentType.Fund); 
        Assert.AreEqual(900, result);
    }

    [Fact]
    public void MustReturnIncorrectValueTreasurie()
    {
        var result = _investmentService.IncomeTax(20000, 14000, InvestmentType.Treasurie); 
        Assert.IsTrue(result != 600);
    }

    [Fact]
    public void MustReturnIncorrectValueFixedIncome()
    {
        var result = _investmentService.IncomeTax(20000, 14000, InvestmentType.FixedIncome); 
        Assert.IsTrue(result != 300);
    }

    [Fact]
    public void MustReturnIncorrectValueFund()
    {
        var result = _investmentService.IncomeTax(20000, 14000, InvestmentType.Fund); 
        Assert.IsTrue(result != 900);
    }
}
}
