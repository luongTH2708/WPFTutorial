using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFTutorial.Model;
using WPFTutorial.ViewModels;

namespace WPFTutorial.Command
{
    public class LoadReservationCommand : AsyncCommandBase
    {
        private readonly ReservationListingViewModel _viewModel;
        private readonly Hotel _hotel;

        public LoadReservationCommand(
            ReservationListingViewModel viewModel, 
            Hotel hotel)
        {
            _hotel = hotel;
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                IEnumerable<Reservation> reservations = await _hotel.GetAllReservation();
                _viewModel.UpdateReservations(reservations);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Failed to Load reservations. {ex}", "Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}
