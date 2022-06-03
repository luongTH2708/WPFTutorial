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

        public Hotel(string name)
        {
            Name = name;
            _reservationBook = new ReservationBook();
        }
        /// <summary>
        /// </summary>
        /// <returns>Sll reservation.</returns>
        public IEnumerable<Reservation> GetAllReservation()
        {
            return _reservationBook.GetAllReservation();
        }
        public void MakeResevation(Reservation reservation)
        {
            _reservationBook.AddReservation(reservation);
        }
    }
}
