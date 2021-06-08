using Core.Domain;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class MoviesController : BaseApiController
    {
        private readonly IGenericRepository<Movie> movieRepo;

        public MoviesController(IGenericRepository<Movie> movieRepo)
        {
            this.movieRepo = movieRepo;
        }


        [HttpGet("movies")]
        public async Task<ActionResult<IReadOnlyList<Movie>>> GetMovies()
        {
            return Ok(await movieRepo.ListAllAsync());
        }
    }
}

            

    

