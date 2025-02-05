using System.ComponentModel.DataAnnotations;

namespace P7CreateRestApi.ViewsModels.CurvePoints
{
    public class AddCurvePointViewModel
    {
        [Required]
        public byte? CurveId { get; set; }

        public DateTime? AsOfDate { get; set; }

        public double? Term { get; set; }

        public double? CurvePointValue { get; set; }
    }
}
