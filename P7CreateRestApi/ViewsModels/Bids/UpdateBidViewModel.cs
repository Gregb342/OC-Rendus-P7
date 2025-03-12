using System.ComponentModel.DataAnnotations;

namespace P7CreateRestApi.ViewsModels
{
    public class UpdateBidViewModel
    {
        [Required]
        public int BidId { get; set; }
        [Required]
        public string Account { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "La quantité doit être superieure à 0.")]
        public double BidQuantity { get; set; }
        public string BidType { get; set; }
        public string Commentary { get; set; }
    }
}
