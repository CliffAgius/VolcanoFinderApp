using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace VolcanoFinder.ViewModels
{
    [QueryProperty(nameof(VolcanoId), nameof(VolcanoId))]
    public class VolcanoDetailViewModel : BaseViewModel
    {

        public float Lat { get; set; }
        public float Lon { get; set; }

        public IAsyncCommand OpenMapCommand { get; set; }

        public VolcanoDetailViewModel()
        {
            OpenMapCommand = new AsyncCommand(ActionOpenMap);
        }

        private async Task ActionOpenMap()
        {
            var location = new Location(Lat, Lon);
            var options = new MapLaunchOptions { Name = VolcanoName };

            try
            {
                await Map.OpenAsync(location, options);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"An error opening the map has occured - {ex.Message}", "OK");
            }
        }

        private string volcanoId;
        public string VolcanoId
        {
            get
            {
                return volcanoId;
            }
            set
            {
                volcanoId = value;
                LoadItemId(value);
            }
        }

        private string name;
        public string VolcanoName
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private string country;
        public string Country
        {
            get => country;
            set => SetProperty(ref country, value);
        }

        private string region;
        public string Region
        {
            get => region;
            set => SetProperty(ref region, value);
        }

        private string elevation;
        public string Elevation
        {
            get => elevation;
            set => SetProperty(ref elevation, value);
        }

        private string type;
        public string Type
        {
            get => type;
            set => SetProperty(ref type, value);
        }

        private string status;
        public string Status
        {
            get => status;
            set => SetProperty(ref status, value);
        }

        private string lastKnownErruption;
        public string LastKnownErruption
        {
            get => lastKnownErruption;
            set => SetProperty(ref lastKnownErruption, value);
        }

        private bool mapButtonEnabled;
        public bool MapButtonEnabled
        {
            get => mapButtonEnabled;
            set => SetProperty(ref mapButtonEnabled, value);
        }

        public async void LoadItemId(string volcanoId)
        {
            try
            {
                var volcano = await DataStore.GetItemAsync(volcanoId);
                VolcanoName = volcano.VolcanoName;
                Country = volcano.Country;
                Region = volcano.Region;
                Elevation = volcano.Elevation.ToString() + "m";
                Type = volcano.Type;
                Status = volcano.Status;
                LastKnownErruption = volcano.LastKnownEruption;
                if (volcano.Location.type.ToLower() == "point")
                {
                    Lon = volcano.Location.coordinates[0];
                    Lat = volcano.Location.coordinates[1];
                    MapButtonEnabled = true;
                }
                else
                {
                    MapButtonEnabled = false;
                }
                
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
