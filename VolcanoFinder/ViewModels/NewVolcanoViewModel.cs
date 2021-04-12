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

        public string Text
        {
            get => volcanoName;
            set => SetProperty(ref volcanoName, value);
        }

        public string Description
        {
            get => country;
            set => SetProperty(ref country, value);
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
            Volcano newItem = new Volcano()
            {
                Id = Guid.NewGuid().ToString(),
                VolcanoName = Text,
                Country = Description
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
