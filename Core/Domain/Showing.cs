using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    /// <summary>
    /// Represents Showing table from datebase.
    /// </summary>
    public class Showing : EntityBase
    {
        [Required]
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        [Required]
        public Theatre Theatre { get; set; }
        public int TheatreId { get; set; }
        public DateTime ShowingDateTime { get; set; }

    }
}
