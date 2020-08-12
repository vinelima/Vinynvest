using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Vinynvest.Application.Investment.Dto;

namespace Vinynvest.Application
{
    public interface IInvestmentService
    {
        void InitializeClient(string apiUrl);
        InvestmentsDto ReturnInvestments();
    } 
}
