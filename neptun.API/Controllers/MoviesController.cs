using AutoMapper;
using Core.Domain;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;
using neptun.API.DTO;
using neptun.API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace neptun.API.Controllers
{
    public class MoviesController : BaseApiController
    {
        private readonly IGenericRepository<Movie> movieRepo;
        private readonly IGenericRepository<Genre> genreRepo;
        private readonly IMapper mapper;

        public MoviesController(
            IGenericRepository<Movie> movieRepo,
            IGenericRepository<Genre> genreRepo,
            IMapper mapper)
        {
            this.movieRepo = movieRepo;
            this.genreRepo = genreRepo;
        }


        [HttpGet("movies")]
        public async Task<ActionResult<Pagination<MovieDTO>>> GetMovies(
            [FromQuery] MovieSpecParams moviesParams)
        {
            var spec = new MoviesWithGenresSpecification(moviesParams);
            //var countSpec = new MoviesWithFiltersForCountSpecification(moviesParams);
            var totalItems = await movieRepo.CountAsync(spec);
            var movies = await movieRepo.ListAsync(spec);

            var data = mapper
                .Map<IReadOnlyList<Movie>, IReadOnlyList<MovieDTO>>(movies);
            return Ok(new Pagination<MovieDTO>(moviesParams.PageIndex, moviesParams.PageSize, totalItems, data));
        }

        [HttpGet("genres")]
        public async Task<ActionResult<IReadOnlyList<Movie>>> GetGenres()
        {
            return Ok(await genreRepo.ListAllAsync());
        }
    }
}

            

    

