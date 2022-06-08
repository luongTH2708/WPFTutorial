using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPFTutorial.DbContexts;
using WPFTutorial.Model;
using WPFTutorial.Services;
using WPFTutorial.Services.ReservationConflictValidator;
using WPFTutorial.Services.ReservationCreators;
using WPFTutorial.Services.ReservationProviders;
using WPFTutorial.Stores;
using WPFTutorial.ViewModels;

namespace WPFTutorial
{
    public partial class App : Application
    {
        private const string CONNECTION_STRING = @"Data Source=WPFTutorial.db";
        private readonly Hotel _hotel;
        private readonly NavigationStore _navigationStore;
        private readonly WPFTutorialDbContextFactory _WPFTutorialDbContextFactory;

        public App()
        {
            _WPFTutorialDbContextFactory = new WPFTutorialDbContextFactory(CONNECTION_STRING);
            IReservationProvider reservationProvider = new DatabaseReservationProvider(_WPFTutorialDbContextFactory);
            IReservationCreator reservationCreator = new DatabaseReservationCreator(_WPFTutorialDbContextFactory);
            IReservationConflictValidator reservationConflictValidator = new DatabaseReservationConflictValidator(_WPFTutorialDbContextFactory);
            ReservationBook reservationBook = new(
                reservationProvider,
                reservationCreator,
                reservationConflictValidator);
            _hotel = new Hotel("T700", reservationBook);
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            //using (WPFTutorialDbContext dbContext = _WPFTutorialDbContextFactory.CreateDbContext())
            //{
            //    dbContext.Database.Migrate();
            //}
            _navigationStore.CurrentViewModel = CreateReservationViewModel();
           
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
        private MakeReservationViewModel CreateMakeReservationViewModel()
        {
            return new MakeReservationViewModel(_hotel,
                new NavigationService(_navigationStore,CreateReservationViewModel));
        }
        private ReservationListingViewModel CreateReservationViewModel()
        {
            return ReservationListingViewModel.LoadViewModel(_hotel,
                new NavigationService(
                    _navigationStore, 
                    CreateMakeReservationViewModel));
        }
    }
}
