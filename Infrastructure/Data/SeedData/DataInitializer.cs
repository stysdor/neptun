using Core.Domain;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.SeedData
{
    public class DataInitializer
    {
        public static async Task SeedDataAsync(CinemaAppContext context, ILoggerFactory loggerFactory)
        {
            try
             {
                if (!context.Movies.Any())
                {
                    await MoviesInitialize(context);
                }

                if (!context.Theatres.Any())
                {  
                    await context.Theatres.AddRangeAsync(TheatreInitialize());
                    await context.SaveChangesAsync();
                }

                if (!context.RowSeats.Any())
                {
                    await context.RowSeats.AddRangeAsync(SeatsInitialize());
                    await context.SaveChangesAsync();
                }
                
                if (!context.Showings.Any() || context.Showings.Count(x => x.ShowingDateTime > DateTime.Now) < 7)
                {
                    await context.Showings.AddRangeAsync(ShowingsInitialize(context));
                    await context.SaveChangesAsync();
                }

                
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<DataInitializer>();
                logger.LogError(ex.Message);
            }


        }

        private static List<Showing> ShowingsInitialize(CinemaAppContext context)
        {
            DateTime baseDateTime = DateTime.Now.Date.Add(new TimeSpan(19, 0, 0));
            List<Showing> showings = new();
            Random rand;
            int movieNumber;

            for (int i = 1; i < 15; i++)
            {
                rand = new Random();
                movieNumber = rand.Next(0, context.Movies.Count() -1);
                showings.Add(new Showing()
                {
                    Movie = context.Movies.Skip(movieNumber).Take(1).First(),
                    ShowingDateTime = baseDateTime.AddDays(i),
                    Theatre = context.Theatres.Skip(i%2).Take(1).First(),
                }
                ); 
            }
            return showings;

        }

        private static List<RowSeat> SeatsInitialize()
        {
            List<RowSeat> seats = new();
            for (int i = 1; i < 16; i++)
            {
                for (int j = 1; j < 15; j++)
                {
                    seats.Add(new RowSeat() { RowNumber = i, SeatNumber = j });
                }
            }
            return seats;
        }

        private static List<Theatre> TheatreInitialize()
        {
            List<Theatre> theatres = new();
            theatres.Add(new Theatre() { Name = "Sala morska" });
            theatres.Add(new Theatre() { Name = "Sala okrętowa" });
            return theatres;
        }

        private async static Task MoviesInitialize(CinemaAppContext context)
        {
            string moviesJSON = File.ReadAllText("../Infrastructure/Data/SeedData/movies.json");

            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new CustomDateTimeConverter());
            //settings.ContractResolver = new CustomContractResolver();

            List<MovieJSONRoot> moviesJSONRootList = JsonConvert.DeserializeObject<List<MovieJSONRoot>>(moviesJSON, settings);
            List<Movie> movies = new();
            foreach (MovieJSONRoot movieJSONRoot in moviesJSONRootList)
            {
                movies.Add(new Movie()
                {
                    Title = movieJSONRoot.title,
                    Description = movieJSONRoot.overview,
                    PictureUrl = movieJSONRoot.poster,
                    ReleaseDate = movieJSONRoot.release_date,
                    Genres = new List<Genre>()
                });

                foreach (string genreString in movieJSONRoot.genres)
                {
                    if (!context.Genres.Any(g => g.Name == genreString))
                    {
                        Genre genre = new() { Name = genreString };
                        await context.Genres.AddAsync(genre);
                        await context.SaveChangesAsync();
                    }
                    movies.Last().Genres.Add(context.Genres.FirstOrDefault(g => g.Name == genreString));
                }
            }

            await context.Movies.AddRangeAsync(movies);
            await context.SaveChangesAsync();
        }

    }
}
