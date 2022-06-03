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
        public IEnumerable<ReservationViewModel> reservations => _reservations;
        public ICommand MakeReservationCommand { get; }
        public ReservationListingViewModel(NavigationService makeReservationNavigationService)
        {
            _reservations = new ObservableCollection<ReservationViewModel>();
            MakeReservationCommand = new NavigateCommand(makeReservationNavigationService);
            _reservations.Add(new ReservationViewModel(
                new Reservation(
                    new RoomID(1, 2),
                    "luong",
                    DateTime.Now,
                    DateTime.Now)));
            _reservations.Add(new ReservationViewModel(
                new Reservation(
                    new RoomID(1, 2),
                    "hoang",
                    DateTime.Now,
                    DateTime.Now)));
            _reservations.Add(new ReservationViewModel(
                new Reservation(
                    new RoomID(1, 2),
                    "trinh",
                    DateTime.Now,
                    DateTime.Now)));
        }
    }
}
