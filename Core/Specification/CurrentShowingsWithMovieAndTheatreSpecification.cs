﻿using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class CurrentShowingsWithMovieAndTheatreSpecification: BaseSpecification<Showing>
    {
        public CurrentShowingsWithMovieAndTheatreSpecification(ShowingSpecParams showingParams)
         : base(x =>
             (x.ShowingDateTime >= showingParams.DateOfToday ) &&
             (string.IsNullOrEmpty(showingParams.Search) || x.Movie.Title.ToLower().Contains(showingParams.Search)))
        {
            AddInclude(x => x.Movie);
            AddInclude(x => x.Theatre);
            AddInclude(x => x.Movie.Genres);

            ApplyPaging(showingParams.PageSize * (showingParams.PageIndex - 1),
                showingParams.PageSize);
        }

        public CurrentShowingsWithMovieAndTheatreSpecification(DateTime date)
        : base(x => x.ShowingDateTime.Date == date)
        {
            AddInclude(x => x.Movie);
            AddInclude(x => x.Theatre);
            AddInclude(x => x.Movie.Genres);
        }
    }
}
