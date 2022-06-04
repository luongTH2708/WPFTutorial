using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFTutorial.Command;
using WPFTutorial.Model;
using WPFTutorial.Services;
using WPFTutorial.Stores;

namespace WPFTutorial.ViewModels
{
    public class ReservationListingViewModel : ViewModelBase
    {
        private readonly Hotel _hotel;
        private readonly ObservableCollection<ReservationViewModel> _reservations;
        public IEnumerable<ReservationViewModel> reservations => _reservations;
        public ICommand MakeReservationCommand { get; }
        public ReservationListingViewModel(Hotel hotel, NavigationService makeReservationNavigationService)
        {
            _hotel = hotel;
            _reservations = new ObservableCollection<ReservationViewModel>();
            MakeReservationCommand = new NavigateCommand(makeReservationNavigationService);
            UpdateReservation();
        }

        private void UpdateReservation()
        {
            _reservations.Clear();
            foreach (Reservation reservation in _hotel.GetAllReservation())
            {
                ReservationViewModel reservationViewModel = new(reservation);
                _reservations.Add(reservationViewModel);
            }
        }
    }
}
