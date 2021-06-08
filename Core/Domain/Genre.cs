using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain
{
    /// <summary>
    /// Represents Category table from datebase.
    /// </summary>
    [Microsoft.EntityFrameworkCore.Index(nameof(Name),IsUnique = true)]
    public class Genre : EntityBase
    {
        public Genre()
        {
            this.Movies = new HashSet<Movie>();
        }
        
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
