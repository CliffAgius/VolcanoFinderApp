using System;
using System.Diagnostics;
using VolcanoFinder.Services;
using Xamarin.Forms;

namespace VolcanoFinder.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);

            //Try to Auto Login...
            //OnLoginClicked();
        }

        private async void OnLoginClicked()
        {
            try
            {
                await AuthService.SignInAsync();

                if (App.AuthResult != null)
                {
                    // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
                    await Shell.Current.GoToAsync($"//main");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Login failed!", "OK");
                Debug.WriteLine($"Login Error - {ex.Message}");
            }
        }
    }
}
