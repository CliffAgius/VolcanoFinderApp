using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using VolcanoFinder.Models;
using Xamarin.Forms;

namespace VolcanoFinder.ViewModels
{
    public class NewVolcanoViewModel : BaseViewModel
    {
        private string volcanoName;
        private string country;
        private string region;
        private int elevation;
        private string type;
        private string status;
        private DateTime lastKnownErruption;
        private float lat;
        private float lon;

        public NewVolcanoViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(volcanoName)
                && !String.IsNullOrWhiteSpace(country);
        }

        public string VolcanonName
        {
            get => volcanoName;
            set => SetProperty(ref volcanoName, value);
        }

        public string Country
        {
            get => country;
            set => SetProperty(ref country, value);
        }

        public string Region
        {
            get => region;
            set => SetProperty(ref region, value);
        }

        public int Elevation
        {
            get => elevation;
            set => SetProperty(ref elevation, value);
        }

        public string Type
        {
            get => type;
            set => SetProperty(ref type, value);
        }

        public string Status
        {
            get => status;
            set => SetProperty(ref status, value);
        }

        public DateTime LastKnownErruption
        {
            get => lastKnownErruption;
            set => SetProperty(ref lastKnownErruption, value);
        }

        public float Lat
        {
            get => lat;
            set => SetProperty(ref lat, value);
        }

        public float Lon
        {
            get => lon;
            set => SetProperty(ref lon, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Volcano newVolcano = new Volcano()
            {
                Id = Guid.NewGuid().ToString(),
                VolcanoName = VolcanonName,
                Country = Country,
                Region = Region,
                Elevation = Elevation,
                Type = Type,
                Status = Status,
                LastKnownEruption = LastKnownErruption.ToString(),
                Location = new Location { type = "Point", coordinates = new float[] { Lon, Lat } }
            };

            await DataStore.AddItemAsync(newVolcano);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
