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
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "La quantité doit être superieure à 0.")]
        public double? BuyQuantity { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "La quantité doit être superieure à 0.")]
        public double? SellQuantity { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "La quantité doit être superieure à 0.")]
        public double? BuyPrice { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "La quantité doit être superieure à 0.")]
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
