using Dot.Net.WebApi.Controllers.Domain;
using P7CreateRestApi.ViewsModels.Ratings;

namespace P7CreateRestApi.Services.Interfaces
{
    public interface IRatingService
    {
        Task AddRating(Rating rating);
        Task<GetRatingViewModel> GetRatingByIdAsync(int id);
        Task<List<GetRatingViewModel>> GetAllRatings();
        Task<GetRatingViewModel> UpdateRating(UpdateRatingViewModel model);
        Task RemoveRating(int id);
    }
}
