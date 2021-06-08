using Core.Domain;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace neptun.API.Controllers
{
    public class ShowingsController : BaseApiController
    {
        private readonly IGenericRepository<Showing> showingRepo;

        public ShowingsController(IGenericRepository<Showing> repo)
        {
            this.showingRepo = repo;
        }


        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Showing>>> GetShowings()
        {
            return Ok(await showingRepo.ListAllAsync());
        }
    }
}
