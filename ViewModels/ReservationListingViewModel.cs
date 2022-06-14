using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFTutorial.Commands;
using WPFTutorial.Models;
using WPFTutorial.Services;
using WPFTutorial.Stores;

namespace WPFTutorial.ViewModels
{
    public class ReservationListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ReservationViewModel> _reservations;
        public IEnumerable<ReservationViewModel> Reservations => _reservations;
        public ICommand LoadReservationCommand { get; }
        public ICommand MakeReservationCommand { get; }
        public ReservationListingViewModel(HotelStore hotelStore, 
            NavigationService makeReservationNavigationService)
        {
            _reservations = new ObservableCollection<ReservationViewModel>();
            LoadReservationCommand = new LoadReservationCommand(this, hotelStore);
            MakeReservationCommand = new NavigateCommand(makeReservationNavigationService);
        }
        public static ReservationListingViewModel LoadViewModel(HotelStore hotelStore, 
            NavigationService makeReservationNavigationService)
        {
            ReservationListingViewModel viewModel = new(
                hotelStore, makeReservationNavigationService);
            viewModel.LoadReservationCommand.Execute(null);
            return viewModel;
        }
        public void UpdateReservations(IEnumerable<Reservation> reservations)
        {
            _reservations.Clear();
            foreach (Reservation reservation in reservations)
            {
                ReservationViewModel reservationViewModel = new(reservation);
                _reservations.Add(reservationViewModel);
            }
        }
    }
}
