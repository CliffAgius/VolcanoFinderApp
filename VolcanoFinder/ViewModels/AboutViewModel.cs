using System;
using System.Threading.Tasks;
using System.Windows.Input;
using VolcanoFinder.Services;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace VolcanoFinder.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {

        public IAsyncCommand LogOutCommand { get; set; }

        public AboutViewModel()
        {
            LogOutCommand = new AsyncCommand(ActionLogOut);
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        private async Task ActionLogOut()
        {
            await AuthService.SignOut();
            await Shell.Current.GoToAsync($"//login");
        }

        public ICommand OpenWebCommand { get; }
    }
}