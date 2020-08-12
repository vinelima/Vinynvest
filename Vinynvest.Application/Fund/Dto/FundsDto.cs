using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Vinynvest.Application.Fund.Dto
{
    public class FundsDto
    {
        [JsonProperty("fundos")]
        public List<Fund> Funds { get; set; }
    }

    public class Fund
    {
        [JsonProperty("capitalInvestido")]
        public decimal InvestedAmount { get; set; }
        [JsonProperty("valorAtual")]
        public decimal CurrentAmount { get; set; }
        [JsonProperty("dataResgate")]
        public DateTime RedemptionDate { get; set; }
        [JsonProperty("dataCompra")]
        public DateTime PurchaseDate { get; set; }
        [JsonProperty("iof")]
        public decimal FinancialTransactionTax { get; set; }
        [JsonProperty("nome")]
        public string Name { get; set; }
        [JsonProperty("totalTaxas")]
        public decimal TotalFees { get; set; }
        public int Quantity { get; set; }
    }
}
