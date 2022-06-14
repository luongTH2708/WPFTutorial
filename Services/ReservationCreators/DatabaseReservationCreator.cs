using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTutorial.DbContexts;
using WPFTutorial.DTOs;
using WPFTutorial.Models;

namespace WPFTutorial.Services.ReservationCreators
{
    public class DatabaseReservationCreator : IReservationCreator
    {
        private readonly WPFTutorialDbContextFactory _dbContextFactory;

        public DatabaseReservationCreator(WPFTutorialDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task CreateReservation(Reservation reservation)
        {
            using WPFTutorialDbContext context = _dbContextFactory.CreateDbContext();
            ReservationDTO reservationDTO = ToReservationDTO(reservation);
            context.Reservations.Add(reservationDTO);
            await context.SaveChangesAsync();
        }

        private static ReservationDTO ToReservationDTO(Reservation reservation)
        {
            return new ReservationDTO()
            {
                FloorNumber = reservation.RoomID?.FloorNumber ?? 0,
                RoomNumber = reservation.RoomID?.RoomNumber ?? 0,
                Username = reservation.Username,
                StartTime = reservation.StartTime,
                EndTime = reservation.EndTime
            };
        }
    }
}
