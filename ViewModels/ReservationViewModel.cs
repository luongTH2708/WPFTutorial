using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTutorial.Model;

namespace WPFTutorial.ViewModels
{
    public class ReservationViewModel : ViewModelBase
    {
        private readonly Reservation _reservation;

        public string RoomID => _reservation.RoomID?.ToString();
        public string Username => _reservation.Username.ToString();
        public string StartDate => _reservation.StartTime.ToString("d");
        public string EndDate => _reservation.EndTime.Date.ToString("d");
        public ReservationViewModel(Reservation reservation)
        {
            _reservation = reservation;
        }
    }
}
