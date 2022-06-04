using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTutorial.DbContexts;
using WPFTutorial.DTOs;
using WPFTutorial.Model;

namespace WPFTutorial.Services.ReservationConflictValidator
{
    public class DatabaseReservationConflictValidator : IReservationConflictValidator
    {
        private readonly WPFTutorialDbContextFactory _dbContextFactory;

        public DatabaseReservationConflictValidator(WPFTutorialDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<Reservation> GetConflictingReservation(Reservation reservation)
        {
            using WPFTutorialDbContext context = _dbContextFactory.CreateDbContext();
            ReservationDTO reservationDTO = await context.Reservation
                .Where(r => r.FloorNumber == reservation.RoomID.FloorNumber)
                .Where(r => r.RoomNumber == reservation.RoomID.RoomNumber)
                .Where(r => r.EndTime > reservation.StartTime)
                .Where(r => r.StartTime < reservation.EndTime)
                .FirstOrDefaultAsync();

            if (reservationDTO == null)
            {
                return null;
            }

            return ToReservation(reservationDTO);
        }

        private static Reservation ToReservation(ReservationDTO dto)
        {
            return new Reservation(
                                new RoomID(dto.FloorNumber, dto.RoomNumber),
                                dto.Username,
                                dto.StartTime,
                                dto.EndTime);
        }
    }
}
