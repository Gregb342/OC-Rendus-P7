using System.ComponentModel.DataAnnotations;

namespace P7CreateRestApi.ViewsModels.Ratings
{
    public class AddRatingViewModel
    {
        [Required]
        public string MoodysRating { get; set; }

        [Required]
        public string SandPRating { get; set; }

        [Required]
        public string FitchRating { get; set; }

        public byte? OrderNumber { get; set; }
    }
}
