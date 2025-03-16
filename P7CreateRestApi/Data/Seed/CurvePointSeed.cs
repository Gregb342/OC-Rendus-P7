using Dot.Net.WebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace P7CreateRestApi.Data.Seed
{
    public class CurvePointSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurvePoint>().HasData(
                new CurvePoint
                {
                    Id = 1,
                    CurveId = 1,
                    AsOfDate = DateTime.UtcNow.AddDays(-7),
                    Term = 10.5,
                    CurvePointValue = 100.25,
                    CreationDate = DateTime.UtcNow
                },
                new CurvePoint
                {
                    Id = 2,
                    CurveId = 2,
                    AsOfDate = DateTime.UtcNow.AddDays(-5),
                    Term = 15.75,
                    CurvePointValue = 150.50,
                    CreationDate = DateTime.UtcNow
                }
            );
        }
    }
}
