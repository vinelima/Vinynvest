using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Vinynvest.Application.FixedIncome.Dto;
using Vinynvest.Application.Fund.Dto;
using Vinynvest.Application.Investment.Dto;
using Vinynvest.Application.Investment.Enums;
using Vinynvest.Application.Treasurie.Dto;
using Vinynvest.Infra.CrossCutting;

namespace Vinynvest.Application
{
    public class InvestmentService : IInvestmentService
    {
        private ApiClient _client;

        public InvestmentService()
        {
        }

        public void InitializeClient(string apiUrl)
        {
            _client = new ApiClient(apiUrl);
        }

        public InvestmentsDto ReturnInvestments()
        {
            InvestmentsDto investments = new InvestmentsDto { Investments = new List<Investment.Dto.Investment> { } };
            TreasuriesDto treasuriesDto = _client.Get<TreasuriesDto>($"v2/5e3428203000006b00d9632a").Result;
            FixedIncomeDto fixedIncomeDto = _client.Get<FixedIncomeDto>($"v2/5e3429a33000008c00d96336").Result;
            FundsDto fundsDto = _client.Get<FundsDto>($"v2/5e342ab33000008c00d96342").Result;
            TreasurieIterations(investments, treasuriesDto);
            FixedIncomeIterations(investments, fixedIncomeDto);
            FundIterations(investments, fundsDto);
            return investments;
        }
        public decimal IncomeTax (decimal totalAmount, decimal investedAmount, InvestmentType investmentType)
        {
            decimal profitability = totalAmount - investedAmount;
            return investmentType switch
            {
                InvestmentType.Treasurie => profitability / 100 * 10,
                InvestmentType.FixedIncome => profitability / 100 * 5,
                InvestmentType.Fund => profitability / 100 * 15,
                _ => 0,
            };
        }
        public decimal RedemptionValue (DateTime purchaseDate, DateTime dueDate, decimal investedAmount)
        {
            TimeSpan purchaseDateToDueDateDifference = dueDate.Subtract(purchaseDate);
            TimeSpan purchaseDateToNowDifference = DateTime.Now.Subtract(purchaseDate);
            TimeSpan nowToDueDateDifference = dueDate.Subtract(DateTime.Now);

            long halfTimeInCustodyDifference = TimeSpan.Compare(purchaseDateToNowDifference, purchaseDateToDueDateDifference.Divide(2));

            if (halfTimeInCustodyDifference == 1)
                return investedAmount - ((investedAmount / 100) * 15);
            else if (nowToDueDateDifference.TotalDays < 90)
                return investedAmount - ((investedAmount / 100) * 6);
            else
                return investedAmount - ((investedAmount / 100) * 30);
        }
        private void TreasurieIterations(InvestmentsDto investments, TreasuriesDto treasuriesDto)
        {
            foreach (var treasurie in treasuriesDto.Treasuries)
            {
                investments.TotalAmount += treasurie.TotalAmount;

                investments.Investments.Add(new Investment.Dto.Investment
                {
                    InvestedAmount = treasurie.InvestedAmount,
                    DueDate = DateTime.Now,
                    IncomeTax = IncomeTax(treasurie.TotalAmount, treasurie.InvestedAmount, InvestmentType.Treasurie),
                    Name = treasurie.Name,
                    TotalAmount = treasurie.TotalAmount,
                    RedemptionValue = RedemptionValue(treasurie.PurchaseDate, treasurie.DueDate, treasurie.InvestedAmount)
                });
            }
        }
        private void FixedIncomeIterations(InvestmentsDto investments, FixedIncomeDto fixedIncomeDto)
        {
            foreach (var fixedIncome in fixedIncomeDto.FixedIncomeList)
            {
                investments.TotalAmount += fixedIncome.CurrentAmount;

                investments.Investments.Add(new Investment.Dto.Investment
                {
                    InvestedAmount = fixedIncome.InvestedAmount,
                    DueDate = fixedIncome.DueDate,
                    IncomeTax = IncomeTax(fixedIncome.CurrentAmount, fixedIncome.InvestedAmount, InvestmentType.FixedIncome),
                    Name = fixedIncome.Name,
                    TotalAmount = fixedIncome.CurrentAmount,
                    RedemptionValue = RedemptionValue(fixedIncome.OperationDate, fixedIncome.DueDate, fixedIncome.InvestedAmount)
                });
            }
        }
        private void FundIterations(InvestmentsDto investments, FundsDto fundsDto)
        {
            foreach (var fund in fundsDto.Funds)
            {
                investments.TotalAmount += fund.CurrentAmount;

                investments.Investments.Add(new Investment.Dto.Investment
                {
                    InvestedAmount = fund.InvestedAmount,
                    DueDate = fund.RedemptionDate,
                    IncomeTax = IncomeTax(fund.CurrentAmount, fund.InvestedAmount, InvestmentType.Fund),
                    Name = fund.Name,
                    TotalAmount = fund.CurrentAmount,
                    RedemptionValue = RedemptionValue(fund.PurchaseDate, fund.RedemptionDate, fund.InvestedAmount)
                });
            }
        }
    }
}
