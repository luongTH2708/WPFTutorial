using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTutorial.DTOs;

namespace WPFTutorial.DbContexts
{
    public class WPFTutorialDbContext : DbContext
    {
        public WPFTutorialDbContext(DbContextOptions options) : base(options) { }

        public DbSet<ReservationDTO> Reservation { get; set; }
    }
}
