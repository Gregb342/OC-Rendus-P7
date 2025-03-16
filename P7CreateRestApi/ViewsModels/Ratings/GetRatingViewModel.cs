namespace P7CreateRestApi.ViewsModels.Ratings
{
    public class GetRatingViewModel
    {
        public int Id { get; set; }
        public string MoodysRating { get; set; }
        public string SandPRating { get; set; }
        public string FitchRating { get; set; }
        public byte? OrderNumber { get; set; }
    }
}
