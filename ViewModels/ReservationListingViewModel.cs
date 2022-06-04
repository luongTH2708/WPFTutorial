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
        private readonly ObservableCollection<ReservationViewModel> _reservations;
        public IEnumerable<ReservationViewModel> Reservations => _reservations;
        public ICommand LoadReservationCommand { get; }
        public ICommand MakeReservationCommand { get; }
        public ReservationListingViewModel(
            Hotel hotel, 
            NavigationService makeReservationNavigationService)
        {
            _reservations = new ObservableCollection<ReservationViewModel>();
            LoadReservationCommand = new LoadReservationCommand(this,hotel);
            MakeReservationCommand = new NavigateCommand(makeReservationNavigationService);
        }
        public static ReservationListingViewModel LoadViewModel(
            Hotel hotel, 
            NavigationService makeReservationNavigationService)
        {
            ReservationListingViewModel viewModel = new(
                hotel, makeReservationNavigationService);
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
