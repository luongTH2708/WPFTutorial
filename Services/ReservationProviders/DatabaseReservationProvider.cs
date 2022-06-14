using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTutorial.DbContexts;
using WPFTutorial.DTOs;
using WPFTutorial.Models;

namespace WPFTutorial.Services.ReservationProviders
{
    public class DatabaseReservationProvider : IReservationProvider
    {
        private readonly WPFTutorialDbContextFactory _dbContextFactory;

        public DatabaseReservationProvider(WPFTutorialDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            using WPFTutorialDbContext context = _dbContextFactory.CreateDbContext();
            IEnumerable<ReservationDTO> reservationDTOs = await context.Reservations.ToListAsync();
            return reservationDTOs.Select(r => ToReservation(r));
        }
        static Reservation ToReservation(ReservationDTO dto)
        {
            return new Reservation(
                new RoomID(dto.FloorNumber, dto.RoomNumber),
                dto.Username,
                dto.StartTime,
                dto.EndTime);
        }
    }
}
