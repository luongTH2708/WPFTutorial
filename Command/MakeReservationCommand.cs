using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFTutorial.Exceptions;
using WPFTutorial.Model;
using WPFTutorial.Services;
using WPFTutorial.ViewModels;

namespace WPFTutorial.Command
{
    public class MakeReservationCommand : CommandBase
    {
        private readonly MakeReservationViewModel _makeReservationViewModel;
        private readonly Hotel _hotel;
        private readonly NavigationService _reservationViewReservationService;

        public MakeReservationCommand(MakeReservationViewModel makeReservationViewModel, 
            Hotel hotel,
            NavigationService reservationViewReservationService
            )
        {
            _makeReservationViewModel = makeReservationViewModel;
            _hotel = hotel;
            _reservationViewReservationService = reservationViewReservationService;
            _makeReservationViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_makeReservationViewModel.Username) && 
                _makeReservationViewModel.RoomNumber > 0 &&
                _makeReservationViewModel.FloorNumber >0 &&
                base.CanExecute(parameter);
        }
        public override void Execute(object parameter)
        {
            Reservation reservation = new(
                new RoomID(_makeReservationViewModel.FloorNumber, _makeReservationViewModel.RoomNumber),
                _makeReservationViewModel.Username,
                _makeReservationViewModel.StartDate,
                _makeReservationViewModel.EndDate);

            try
            {
                _hotel.MakeResevation(reservation);
                MessageBox.Show("Successfully reserved room.", 
                    "success", MessageBoxButton.OK, MessageBoxImage.Information);

                _reservationViewReservationService.Navigate();
            }
            catch (ReservationConflictException)
            {
                MessageBox.Show("This room is already taken.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MakeReservationViewModel.Username))
            {
                OnCanExcuteChanged();
            }
        }

    }
}
