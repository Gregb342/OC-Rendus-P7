using System.ComponentModel.DataAnnotations;

namespace P7CreateRestApi.ViewsModels.Bids
{
    public class GetBidViewModel
    {
        [Required]
        public int BidId { get; set; }
        [Required]
        public string Account { get; set; }
        public string BidType { get; set; }
        public double? BidQuantity { get; set; }
        public string Commentary { get; set; }
    }
}
