using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Vinynvest.Application.Treasurie.Dto
{
    public class TreasuriesDto
    {
        [JsonProperty("tds")]
        public List<Treasurie> Treasuries { get; set; }
    }

    public class Treasurie
    {
        [JsonProperty("valorInvestido")]
        public decimal InvestedAmount { get; set; }
        [JsonProperty("valorTotal")]
        public decimal TotalAmount { get; set; }
        [JsonProperty("vencimento")]
        public DateTime DueDate { get; set; }
        [JsonProperty("dataDeCompra")]
        public DateTime PurchaseDate { get; set; }
        [JsonProperty("iof")]
        public decimal FinancialTransactionTax { get; set; }
        [JsonProperty("indice")]
        public string Index { get; set; }
        [JsonProperty("tipo")]
        public string Type { get; set; }
        [JsonProperty("nome")]
        public string Name { get; set; }
    }
}
