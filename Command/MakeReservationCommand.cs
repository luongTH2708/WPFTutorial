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
using WPFTutorial.Stores;
using WPFTutorial.ViewModels;

namespace WPFTutorial.Command
{
    public class MakeReservationCommand : AsyncCommandBase
    {
        private readonly MakeReservationViewModel _makeReservationViewModel;
        private readonly HotelStore _hotelStore;
        private readonly Hotel _hotel;
        private readonly NavigationService _reservationViewReservationService;

        public MakeReservationCommand(MakeReservationViewModel makeReservationViewModel,
            HotelStore hotelStore,
            NavigationService reservationViewReservationService
            )
        {
            _makeReservationViewModel = makeReservationViewModel;
            _hotelStore = hotelStore;
            _reservationViewReservationService = reservationViewReservationService;
            _makeReservationViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(
                _makeReservationViewModel.Username) &&
                _makeReservationViewModel.FloorNumber > 0 &&
                base.CanExecute(parameter);
        }
        public override async Task ExecuteAsync(object parameter)
        {
            Reservation reservation = new(
                new RoomID(_makeReservationViewModel.FloorNumber, _makeReservationViewModel.RoomNumber),
                _makeReservationViewModel.Username,
                _makeReservationViewModel.StartDate,
                _makeReservationViewModel.EndDate);

            try
            {
                await _hotelStore.MakeReservation(reservation);
                MessageBox.Show("Successfully reserved room.", 
                    "success", MessageBoxButton.OK, MessageBoxImage.Information);

                _reservationViewReservationService.Navigate();
            }
            catch (ReservationConflictException)
            {
                MessageBox.Show("This room is already taken.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to make reservation.{ex}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MakeReservationViewModel.Username) ||
                e.PropertyName == nameof(MakeReservationViewModel.FloorNumber) ||
                e.PropertyName == nameof(MakeReservationViewModel.RoomNumber))
            {
                OnCanExcuteChanged();
            }
        }

    }
}
