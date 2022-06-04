using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTutorial.Model
{
    public class Hotel
    {
        readonly ReservationBook _reservationBook;
        public string Name { get; }

        public Hotel(string name, ReservationBook reservationBook)
        {
            Name = name;
            _reservationBook = reservationBook;
        }
        /// <summary>
        /// </summary>
        /// <returns>All reservation.</returns>
        public async Task<IEnumerable<Reservation>> GetAllReservation()
        {
            return await _reservationBook.GetAllReservation();
        }
        public async Task MakeResevation(Reservation reservation)
        {
            await _reservationBook.AddReservation(reservation);
        }
    }
}
