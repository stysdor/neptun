using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class CinemaAppContext : DbContext
    {
        public CinemaAppContext([NotNullAttribute] DbContextOptions<CinemaAppContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Showing> Showings { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<RowSeat> RowSeats { get; set; }
        public DbSet<Theatre> Theatres { get; set; }
        
        

    }
}
