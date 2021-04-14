using VolcanoFinder.Models;
using VolcanoFinder.ViewModels;
using Xamarin.Forms;

namespace VolcanoFinder.Views
{
    public partial class NewVolcanoPage : ContentPage
    {
        public NewVolcanoPage()
        {
            InitializeComponent();
            BindingContext = new NewVolcanoViewModel();
        }
    }
}