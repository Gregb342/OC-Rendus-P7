using System;
using System.ComponentModel.DataAnnotations;

namespace P7CreateRestApi.ViewsModels.Trades
{
    public class UpdateTradeViewModel
    {
        [Required]
        public int TradeId { get; set; }

        [Required]
        public string Account { get; set; }

        [Required]
        public string AccountType { get; set; }

        public double? BuyQuantity { get; set; }
        public double? SellQuantity { get; set; }
        public double? BuyPrice { get; set; }
        public double? SellPrice { get; set; }

        public DateTime? TradeDate { get; set; }

        [Required]
        public string TradeSecurity { get; set; }

        [Required]
        public string TradeStatus { get; set; }

        [Required]
        public string Trader { get; set; }

        public string Benchmark { get; set; }
        public string Book { get; set; }
        public string CreationName { get; set; }
        public DateTime? CreationDate { get; set; }
        public string RevisionName { get; set; }
        public DateTime? RevisionDate { get; set; }
        public string DealName { get; set; }
        public string DealType { get; set; }
        public string SourceListId { get; set; }
        public string Side { get; set; }
    }
}
