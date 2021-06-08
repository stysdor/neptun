using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    /// <summary>
    /// Represents Reservation table from datebase.
    /// </summary>
    public class Reservation :EntityBase
    {
        [Required]
        public Showing Showing { get; set; }
        public int ShowingId { get; set; }
        [Required]
        public RowSeat RowSeat { get; set; }
        public int RowSeatId { get; set; }
        [Required]
        public bool IsConfirmed { get; set; }
        public DateTime ReservationDate { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }


    }
}
