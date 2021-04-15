using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using VolcanoFinder.Models;
using VolcanoFinder.Views;
using Xamarin.Forms;

namespace VolcanoFinder.ViewModels
{
    public class VolcanoViewModel : BaseViewModel
    {
        private Volcano _selectedItem;

        public ObservableCollection<Volcano> Volcanoes { get; }
        public Command LoadVolcanoCommand { get; }
        public Command AddVolcanoCommand { get; }
        public Command<Volcano> ItemTapped { get; }

        public VolcanoViewModel()
        {
            Title = "Volcanoes";
            Volcanoes = new ObservableCollection<Volcano>();
            LoadVolcanoCommand = new Command(async () => await ExecuteLoadVolcanoesCommand());

            ItemTapped = new Command<Volcano>(OnItemSelected);

            AddVolcanoCommand = new Command(OnAddVolcano);
        }

        async Task ExecuteLoadVolcanoesCommand()
        {
            IsBusy = true;

            var countryCode = new CountryFlagLookup();
            try
            {
                Volcanoes.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    countryCode.Countries.TryGetValue(item.Country, out string code);
                    item.CountryFlagURL = "https://hatscripts.github.io/circle-flags/flags/" + code + ".svg";
                    Volcanoes.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Volcano SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddVolcano(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewVolcanoPage));
        }

        async void OnItemSelected(Volcano volcano)
        {
            if (volcano == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(VolcanoDetailPage)}?{nameof(VolcanoDetailViewModel.VolcanoId)}={volcano.Id}");
        }
    }
}