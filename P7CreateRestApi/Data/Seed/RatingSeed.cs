using Dot.Net.WebApi.Controllers.Domain;
using Microsoft.EntityFrameworkCore;

namespace P7CreateRestApi.Data.Seed
{
    public class RatingSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rating>().HasData(
                new Rating
                {
                    Id = 1,
                    MoodysRating = "Aaa",
                    SandPRating = "AAA",
                    FitchRating = "AAA",
                    OrderNumber = 1
                },
                new Rating
                {
                    Id = 2,
                    MoodysRating = "Baa1",
                    SandPRating = "BBB",
                    FitchRating = "BBB",
                    OrderNumber = 2
                }
            );
        }
    }
}
