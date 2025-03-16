using System.ComponentModel.DataAnnotations;

namespace P7CreateRestApi.ViewsModels.CurvePoints
{
    public class AddCurvePointViewModel
    {
        [Required]
        public byte? CurveId { get; set; }

        public DateTime? AsOfDate { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "La quantité doit être superieure à 0.")]
        public double? Term { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "La quantité doit être superieure à 0.")]
        public double? CurvePointValue { get; set; }
    }
}
