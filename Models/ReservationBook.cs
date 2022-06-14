using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFTutorial.Exceptions;
using WPFTutorial.Services.ReservationConflictValidator;
using WPFTutorial.Services.ReservationCreators;
using WPFTutorial.Services.ReservationProviders;

namespace WPFTutorial.Models
{
    public class ReservationBook
    {
        private readonly IReservationProvider _reservationProvider;
        private readonly IReservationCreator _reservationCreater;
        private readonly IReservationConflictValidator _reservationConflictValidator;

        public ReservationBook(
            IReservationProvider resrvationProvider, 
            IReservationCreator resrvationCreater, 
            IReservationConflictValidator reservationConflictValidator = null)
        {
            _reservationProvider = resrvationProvider;
            _reservationCreater = resrvationCreater;
            _reservationConflictValidator = reservationConflictValidator;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservation()
        {
            return await _reservationProvider.GetAllReservations();
        }
        public async Task AddReservation(Reservation reservation)
        {
            Reservation conflictingReservation =
                await _reservationConflictValidator
                .GetConflictingReservation(reservation);
            if (conflictingReservation != null)
            {
                throw new ReservationConflictException(
                    conflictingReservation,
                    reservation);
            }
            await _reservationCreater.CreateReservation(reservation);
        }
    }
}
