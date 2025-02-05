using Dot.Net.WebApi.Controllers;
using Microsoft.EntityFrameworkCore;
using System;

namespace P7CreateRestApi.Data.Seed
{
    public class RuleSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rule>().HasData(
                new Rule
                {
                    Id = 1,
                    Name = "Règle de Validation A",
                    Description = "Description de la règle A",
                    Json = "{\"key\":\"valueA\"}",
                    Template = "Template A",
                    SqlStr = "SELECT * FROM TableA",
                    SqlPart = "WHERE conditionA"
                },
                new Rule
                {
                    Id = 2,
                    Name = "Règle de Validation B",
                    Description = "Description de la règle B",
                    Json = "{\"key\":\"valueB\"}",
                    Template = "Template B",
                    SqlStr = "SELECT * FROM TableB",
                    SqlPart = "WHERE conditionB"
                }
            );
        }
    }
}
