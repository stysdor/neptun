using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    /// <summary>
    /// Represents Movie table from datebase.
    /// </summary>
    public class Movie : EntityBase
    {
        public Movie()
        {
            this.Genres = new HashSet<Genre>();
        }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PictureUrl { get; set; }

    }
}
