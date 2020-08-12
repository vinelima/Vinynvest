using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Vinynvest.Application.Investment.Dto
{
    public class InvestmentsDto
    {
        [JsonProperty("")]
        public decimal TotalAmount { get; set; }

        [JsonProperty("")]
        public List<Investment> Investments { get; set; }
    }
    public class Investment
    {
        [JsonProperty("")]
        public string Name { get; set; }
        [JsonProperty("")]
        public decimal InvestedAmount { get; set; }
        [JsonProperty("")]
        public decimal TotalAmount { get; set; }
        [JsonProperty("")]
        public DateTime DueDate { get; set; }
        [JsonProperty("")]
        public decimal IncomeTax { get; set; }
        [JsonProperty("")]
        public decimal RedemptionValue { get; set; }
    }
}
