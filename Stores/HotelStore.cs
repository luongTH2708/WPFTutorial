using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTutorial.Models;

namespace WPFTutorial.Stores
{
    public class HotelStore
    {
        private readonly Hotel _hotel;
        private readonly List<Reservation> _reservations;
        private readonly Lazy<Task> _Initializelazy;
        public List<Reservation> Reservations => _reservations;

        public HotelStore(Hotel hotel)
        {
            _hotel = hotel;
            _reservations = new List<Reservation>();
            _Initializelazy = new Lazy<Task>(Initialize);
        }
        public async Task Load()
        {
            await _Initializelazy.Value;
        }
        public async Task MakeReservation(Reservation reservation)
        {
            await _hotel.MakeResevation(reservation);
            _reservations.Add(reservation);
        }

        private async Task Initialize()
        {
            IEnumerable<Reservation> reservations = await _hotel.GetAllReservation();
            _reservations.Clear();
            _reservations.AddRange(reservations);
        }
    }
}
