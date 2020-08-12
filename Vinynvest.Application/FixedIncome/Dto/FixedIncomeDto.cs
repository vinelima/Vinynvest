using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Vinynvest.Application.FixedIncome.Dto
{
    public class FixedIncomeDto
    {
        [JsonProperty("lcis")]
        public List<FixedIncome> FixedIncomeList { get; set; }
    }

    public class FixedIncome
    {
        [JsonProperty("capitalInvestido")]
        public decimal InvestedAmount { get; set; }
        [JsonProperty("capitalAtual")]
        public decimal CurrentAmount { get; set; }
        [JsonProperty("quantidade")]
        public decimal Quantity { get; set; }
        [JsonProperty("vencimento")]
        public DateTime DueDate { get; set; }
        [JsonProperty("iof")]
        public decimal FinancialTransactionTax { get; set; }
        [JsonProperty("outrasTaxas")]
        public decimal OtherTaxes { get; set; }
        [JsonProperty("taxas")]
        public decimal Taxes { get; set; }
        [JsonProperty("indice")]
        public string Index { get; set; }
        [JsonProperty("tipo")]
        public string Type { get; set; }
        [JsonProperty("nome")]
        public string Name { get; set; }
        [JsonProperty("guarantidoFgc")]
        public bool GuaranteedByFGC { get; set; }
        [JsonProperty("dataOperacao")]
        public DateTime OperationDate { get; set; }
        [JsonProperty("precoUnitario")]
        public decimal UnitPrice { get; set; }
        [JsonProperty("primario")]
        public bool Primary { get; set; }
    }
}
