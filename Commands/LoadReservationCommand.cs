using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFTutorial.Models;
using WPFTutorial.Stores;
using WPFTutorial.ViewModels;

namespace WPFTutorial.Commands
{
    public class LoadReservationCommand : AsyncCommandBase
    {
        private readonly ReservationListingViewModel _viewModel;
        private readonly HotelStore _hotelStore;

        public LoadReservationCommand(
            ReservationListingViewModel viewModel, 
            HotelStore hotelStore)
        {
            _hotelStore = hotelStore;
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _hotelStore.Load();
                _viewModel.UpdateReservations(_hotelStore.Reservations);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Failed to Load reservations. {ex}", "Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}
