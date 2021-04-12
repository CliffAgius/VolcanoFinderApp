using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Text;
using VolcanoFinder.Services;
using VolcanoFinder.Views;
using Xamarin.Forms;

namespace VolcanoFinder.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);

            if (App.AuthResult != null)
            {
                OnLoginClicked();
            }
        }

        private async void OnLoginClicked()
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
