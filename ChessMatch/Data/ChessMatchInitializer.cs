using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ChessMatch.Models;

namespace ChessMatch.Data

{
    public class ChessMatchInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider, bool DeleteDatabase = false, bool UseMigrations = true, bool SeedSampleData = true)
        {
            using var context = new ChessMatchContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ChessMatchContext>>());

            #region Prepare the Database
            try
            {
                //Note: .CanConnect() will return false if the database is not there!
                if (DeleteDatabase || !context.Database.CanConnect())
                {
                    context.Database.EnsureDeleted(); //Delete the existing version 
                    if (UseMigrations)
                    {
                        context.Database.Migrate(); //Create the Database and apply all migrations
                    }
                    else
                    {
                        context.Database.EnsureCreated(); //Create and update the database as per the Model
                    }
                }
                else //The database is already created
                {
                    if (UseMigrations)
                    {
                        context.Database.Migrate(); //Apply all migrations
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.GetBaseException().Message);
            }
            #endregion
            try
            {
                if (!context.Countries.Any())
                {
                    context.Countries.AddRange(
                        new Country { Name = "United States" },
                        new Country { Name = "India" },
                        new Country { Name = "Germany" },
                        new Country { Name = "Russia" },
                        new Country { Name = "China" },
                        new Country { Name = "France" },
                        new Country { Name = "Brazil" },
                        new Country { Name = "United Kingdom" },
                        new Country { Name = "Canada" },
                        new Country { Name = "Japan" },
                        new Country { Name = "Australia" },
                        new Country { Name = "South Korea" },
                        new Country { Name = "Argentina" },
                        new Country { Name = "Spain" },
                        new Country { Name = "Italy" },
                        new Country { Name = "Mexico" },
                        new Country { Name = "Turkey" },
                        new Country { Name = "Netherlands" },
                        new Country { Name = "Poland" },
                        new Country { Name = "Norway" },
                        new Country { Name = "Sweden" },
                        new Country { Name = "Switzerland" },
                        new Country { Name = "Ukraine" },
                        new Country { Name = "Philippines" },
                        new Country { Name = "Indonesia" },
                        new Country { Name = "Egypt" },
                        new Country { Name = "South Africa" }
                    );
                    context.SaveChanges();
                }

                if (!context.Players.Any())
                {
                    context.Players.AddRange(
                        new Player { Name = "Mad Max", Rating = 2000, Age = 26, Wins = 10, Losses = 5, Draws = 3, CountryID = context.Countries.FirstOrDefault(c => c.Name == "India").ID },
                        new Player { Name = "John Doe", Rating = 1800, Age = 24, Wins = 8, Losses = 7, Draws = 2, CountryID = context.Countries.FirstOrDefault(c => c.Name == "Argentina").ID },
                        new Player { Name = "Alice Smith", Rating = 1900, Age = 27, Wins = 9, Losses = 6, Draws = 4, CountryID = context.Countries.FirstOrDefault(c => c.Name == "France").ID },
                        new Player { Name = "Bob Johnson", Rating = 1750, Age = 25, Wins = 7, Losses = 9, Draws = 2, CountryID = context.Countries.FirstOrDefault(c => c.Name == "Australia").ID },
                        new Player { Name = "Elena White", Rating = 2100, Age = 28, Wins = 12, Losses = 4, Draws = 1, CountryID = context.Countries.FirstOrDefault(c => c.Name == "India").ID },
                        new Player { Name = "Chris Brown", Rating = 1850, Age = 23, Wins = 6, Losses = 8, Draws = 3, CountryID = context.Countries.FirstOrDefault(c => c.Name == "Brazil").ID },
                        new Player { Name = "Sophia Green", Rating = 1950, Age = 22, Wins = 10, Losses = 5, Draws = 3, CountryID = context.Countries.FirstOrDefault(c => c.Name == "Australia").ID },
                        new Player { Name = "Daniel Black", Rating = 1700, Age = 29, Wins = 5, Losses = 10, Draws = 2, CountryID = context.Countries.FirstOrDefault(c => c.Name == "China").ID },
                        new Player { Name = "Olivia Gray", Rating = 2000, Age = 24, Wins = 11, Losses = 5, Draws = 3, CountryID = context.Countries.FirstOrDefault(c => c.Name == "Germany").ID },
                        new Player { Name = "Liam Scott", Rating = 1800, Age = 21, Wins = 9, Losses = 6, Draws = 2, CountryID = context.Countries.FirstOrDefault(c => c.Name == "Russia").ID },
                        new Player { Name = "Noah Smith", Rating = 2050, Age = 23, Wins = 13, Losses = 4, Draws = 2, CountryID = context.Countries.FirstOrDefault(c => c.Name == "Japan").ID },
                        new Player { Name = "Emma Jones", Rating = 1750, Age = 26, Wins = 8, Losses = 7, Draws = 2, CountryID = context.Countries.FirstOrDefault(c => c.Name == "Canada").ID },
                        new Player { Name = "Mason Lee", Rating = 1950, Age = 27, Wins = 10, Losses = 5, Draws = 3, CountryID = context.Countries.FirstOrDefault(c => c.Name == "United States").ID },
                        new Player { Name = "Ava Walker", Rating = 1700, Age = 22, Wins = 6, Losses = 9, Draws = 1, CountryID = context.Countries.FirstOrDefault(c => c.Name == "South Korea").ID },
                        new Player { Name = "Lucas Hall", Rating = 1850, Age = 28, Wins = 11, Losses = 5, Draws = 4, CountryID = context.Countries.FirstOrDefault(c => c.Name == "Spain").ID },
                        new Player { Name = "Mia Adams", Rating = 1900, Age = 23, Wins = 7, Losses = 7, Draws = 5, CountryID = context.Countries.FirstOrDefault(c => c.Name == "Italy").ID },
                        new Player { Name = "Logan King", Rating = 1800, Age = 24, Wins = 9, Losses = 6, Draws = 3, CountryID = context.Countries.FirstOrDefault(c => c.Name == "Mexico").ID },
                        new Player { Name = "Charlotte Wright", Rating = 2000, Age = 25, Wins = 12, Losses = 4, Draws = 3, CountryID = context.Countries.FirstOrDefault(c => c.Name == "Turkey").ID },
                        new Player { Name = "Ethan Green", Rating = 1700, Age = 29, Wins = 5, Losses = 10, Draws = 2, CountryID = context.Countries.FirstOrDefault(c => c.Name == "Netherlands").ID },
                        new Player { Name = "Amelia Harris", Rating = 1900, Age = 21, Wins = 8, Losses = 7, Draws = 4, CountryID = context.Countries.FirstOrDefault(c => c.Name == "Poland").ID },
                        new Player { Name = "James Lewis", Rating = 1850, Age = 28, Wins = 10, Losses = 6, Draws = 3, CountryID = context.Countries.FirstOrDefault(c => c.Name == "Norway").ID },
                        new Player { Name = "Isabella Young", Rating = 1750, Age = 22, Wins = 7, Losses = 8, Draws = 3, CountryID = context.Countries.FirstOrDefault(c => c.Name == "Sweden").ID },
                        new Player { Name = "Benjamin Turner", Rating = 2000, Age = 24, Wins = 11, Losses = 5, Draws = 4, CountryID = context.Countries.FirstOrDefault(c => c.Name == "Switzerland").ID },
                        new Player { Name = "Harper Campbell", Rating = 1800, Age = 23, Wins = 9, Losses = 6, Draws = 3, CountryID = context.Countries.FirstOrDefault(c => c.Name == "Ukraine").ID },
                        new Player { Name = "Henry Mitchell", Rating = 1900, Age = 27, Wins = 10, Losses = 5, Draws = 4, CountryID = context.Countries.FirstOrDefault(c => c.Name == "Philippines").ID },
                        new Player { Name = "Evelyn Perez", Rating = 1700, Age = 25, Wins = 6, Losses = 9, Draws = 2, CountryID = context.Countries.FirstOrDefault(c => c.Name == "Indonesia").ID },
                        new Player { Name = "Sebastian Cox", Rating = 1850, Age = 26, Wins = 9, Losses = 7, Draws = 3, CountryID = context.Countries.FirstOrDefault(c => c.Name == "Egypt").ID },
                        new Player { Name = "Abigail Morgan", Rating = 2000, Age = 22, Wins = 12, Losses = 4, Draws = 3, CountryID = context.Countries.FirstOrDefault(c => c.Name == "South Africa").ID },
                        new Player { Name = "Carter Rogers", Rating = 1950, Age = 23, Wins = 11, Losses = 5, Draws = 4, CountryID = context.Countries.FirstOrDefault(c => c.Name == "United Kingdom").ID },
                        new Player { Name = "Grace Hughes", Rating = 1800, Age = 24, Wins = 9, Losses = 6, Draws = 3, CountryID = context.Countries.FirstOrDefault(c => c.Name == "Canada").ID },
                        new Player { Name = "Michael Reed", Rating = 1750, Age = 26, Wins = 8, Losses = 7, Draws = 3, CountryID = context.Countries.FirstOrDefault(c => c.Name == "Russia").ID },
                        new Player { Name = "Zoe Baker", Rating = 1850, Age = 28, Wins = 10, Losses = 5, Draws = 4, CountryID = context.Countries.FirstOrDefault(c => c.Name == "Germany").ID },
                        new Player { Name = "William Price", Rating = 1950, Age = 27, Wins = 11, Losses = 4, Draws = 4, CountryID = context.Countries.FirstOrDefault(c => c.Name == "United States").ID },
                        new Player { Name = "Victoria James", Rating = 1800, Age = 21, Wins = 9, Losses = 6, Draws = 3, CountryID = context.Countries.FirstOrDefault(c => c.Name == "United Kingdom").ID },
                        new Player { Name = "Leo Bennett", Rating = 1900, Age = 29, Wins = 10, Losses = 5, Draws = 4, CountryID = context.Countries.FirstOrDefault(c => c.Name == "Mexico").ID },
                        new Player { Name = "Aria Foster", Rating = 2000, Age = 22, Wins = 12, Losses = 3, Draws = 4, CountryID = context.Countries.FirstOrDefault(c => c.Name == "France").ID },
                        new Player { Name = "Wyatt Simmons", Rating = 1750, Age = 24, Wins = 7, Losses = 9, Draws = 3, CountryID = context.Countries.FirstOrDefault(c => c.Name == "Turkey").ID },
                        new Player { Name = "Chloe Patterson", Rating = 1850, Age = 23, Wins = 9, Losses = 6, Draws = 4, CountryID = context.Countries.FirstOrDefault(c => c.Name == "Japan").ID },
                        new Player { Name = "Jack Kelly", Rating = 1800, Age = 25, Wins = 8, Losses = 6, Draws = 5, CountryID = context.Countries.FirstOrDefault(c => c.Name == "Philippines").ID },
                        new Player { Name = "Avery Russell", Rating = 1900, Age = 26, Wins = 11, Losses = 5, Draws = 3, CountryID = context.Countries.FirstOrDefault(c => c.Name == "Spain").ID },
                        new Player { Name = "Gabriel Torres", Rating = 1700, Age = 29, Wins = 6, Losses = 10, Draws = 2, CountryID = context.Countries.FirstOrDefault(c => c.Name == "South Korea").ID },
                        new Player { Name = "Ella Peterson", Rating = 1850, Age = 28, Wins = 10, Losses = 6, Draws = 3, CountryID = context.Countries.FirstOrDefault(c => c.Name == "Switzerland").ID },
                        new Player { Name = "Hudson Ward", Rating = 2000, Age = 24, Wins = 13, Losses = 3, Draws = 4, CountryID = context.Countries.FirstOrDefault(c => c.Name == "Indonesia").ID },
                        new Player { Name = "Lily Jenkins", Rating = 1800, Age = 27, Wins = 9, Losses = 7, Draws = 3, CountryID = context.Countries.FirstOrDefault(c => c.Name == "Egypt").ID },
                        new Player { Name = "Dylan Cox", Rating = 1900, Age = 22, Wins = 10, Losses = 5, Draws = 3, CountryID = context.Countries.FirstOrDefault(c => c.Name == "Ukraine").ID },
                        new Player { Name = "Scarlett Perry", Rating = 1950, Age = 25, Wins = 11, Losses = 4, Draws = 3, CountryID = context.Countries.FirstOrDefault(c => c.Name == "Poland").ID },
                        new Player { Name = "Nathan Powell", Rating = 1850, Age = 23, Wins = 9, Losses = 6, Draws = 4, CountryID = context.Countries.FirstOrDefault(c => c.Name == "Norway").ID },
                        new Player { Name = "Luna Bell", Rating = 2000, Age = 21, Wins = 13, Losses = 3, Draws = 4, CountryID = context.Countries.FirstOrDefault(c => c.Name == "Sweden").ID }
                    );
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.GetBaseException().Message);
            }
        }
    }
}
