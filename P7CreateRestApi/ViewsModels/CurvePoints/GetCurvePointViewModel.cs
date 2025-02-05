using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace P7CreateRestApi.ViewsModels.CurvePoints
{
    public class GetCurvePointViewModel
    {
        [Required]
        public int Id { get; set; }
        public byte? CurveId { get; set; }
        public DateTime? AsOfDate { get; set; }
        public double? Term { get; set; }
        public double? CurvePointValue { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
