using Dot.Net.WebApi.Controllers.Domain;
using P7CreateRestApi.Repositories.Interfaces;
using P7CreateRestApi.Services.Interfaces;
using P7CreateRestApi.ViewsModels.Ratings;

namespace P7CreateRestApi.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public async Task AddRating(Rating rating)
        {
            await _ratingRepository.AddAsync(rating);
        }

        public async Task<List<GetRatingViewModel>> GetAllRatings()
        {
            var ratings = await _ratingRepository.GetAllAsync();
            return ratings.Select(r => new GetRatingViewModel
            {
                Id = r.Id,
                MoodysRating = r.MoodysRating,
                SandPRating = r.SandPRating,
                FitchRating = r.FitchRating,
                OrderNumber = r.OrderNumber
            }).ToList();
        }

        public async Task<GetRatingViewModel> GetRatingByIdAsync(int id)
        {
            var rating = await _ratingRepository.GetByIdAsync(id)
                         ?? throw new KeyNotFoundException($"Le rating avec l'ID {id} n'existe pas.");
            return new GetRatingViewModel
            {
                Id = rating.Id,
                MoodysRating = rating.MoodysRating,
                SandPRating = rating.SandPRating,
                FitchRating = rating.FitchRating,
                OrderNumber = rating.OrderNumber
            };
        }

        public async Task<GetRatingViewModel> UpdateRating(UpdateRatingViewModel model)
        {
            var rating = await _ratingRepository.GetByIdAsync(model.Id)
                         ?? throw new KeyNotFoundException($"Le rating avec l'ID {model.Id} n'existe pas.");
            rating.MoodysRating = model.MoodysRating;
            rating.SandPRating = model.SandPRating;
            rating.FitchRating = model.FitchRating;
            rating.OrderNumber = model.OrderNumber;

            await _ratingRepository.UpdateAsync(rating);

            return new GetRatingViewModel
            {
                Id = rating.Id,
                MoodysRating = rating.MoodysRating,
                SandPRating = rating.SandPRating,
                FitchRating = rating.FitchRating,
                OrderNumber = rating.OrderNumber
            };
        }

        public async Task RemoveRating(int id)
        {
            var rating = await _ratingRepository.GetByIdAsync(id)
                         ?? throw new KeyNotFoundException($"Le rating avec l'ID {id} n'existe pas.");
            await _ratingRepository.DeleteAsync(rating.Id);
        }
    }
}
