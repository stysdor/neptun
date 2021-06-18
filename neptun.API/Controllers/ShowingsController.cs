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
    public class ShowingsController : BaseApiController
    {
        private readonly IGenericRepository<Showing> showingRepo; 
        private readonly IMapper mapper;

        public ShowingsController(IGenericRepository<Showing> repo, IMapper mapper)
        {
            this.showingRepo = repo;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ShowingDTO>>> GetCurrentShowings(
            [FromQuery] ShowingSpecParams showingParams)
        {
            showingParams.DateOfToday = DateTime.Today;
            var spec = new CurrentShowingsWithMovieAndTheatreSpecification(showingParams);
            var totalItems = await showingRepo.CountAsync(spec);
            var showings = await showingRepo.ListAsync(spec);

            var data = mapper
                .Map<IReadOnlyList<Showing>, IReadOnlyList<ShowingDTO>>(showings);
            return Ok(new Pagination<ShowingDTO>(showingParams.PageIndex, showingParams.PageSize, totalItems, data));
        }

        [HttpGet]
        [Route("today")]
        public async Task<ActionResult<ShowingDTO>> GetTodaysShowing()
        {
            var spec = new CurrentShowingsWithMovieAndTheatreSpecification(DateTime.Today);
            var showing = await showingRepo.GetEntityWithSpec(spec);

            return mapper.Map<Showing, ShowingDTO>(showing);
        }

        [HttpGet]
        [Route("tommorow")]
        public async Task<ActionResult<ShowingDTO>> GetTomorrowsShowing()
        {
            var spec = new CurrentShowingsWithMovieAndTheatreSpecification(DateTime.Today.AddDays(1));
            var showing = await showingRepo.GetEntityWithSpec(spec);

            return mapper.Map<Showing, ShowingDTO>(showing);
        }

    }
}
