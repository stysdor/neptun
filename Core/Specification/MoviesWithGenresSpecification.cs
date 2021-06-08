using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class MoviesWithGenresSpecification: BaseSpecification<Movie>
    {
        public MoviesWithGenresSpecification(MovieSpecParams movieParams)
            : base(x =>
                (string.IsNullOrEmpty(movieParams.Search) || x.Title.ToLower().Contains
                (movieParams.Search)) //&&
           // (movieParams.GenreId.HasValue && x.Genres.Contains(new Genre { Id = (int)movieParams.GenreId} ))    
            )
        {
            ApplyPaging(movieParams.PageSize * (movieParams.PageIndex - 1),
                movieParams.PageSize);
        }
    }
}
