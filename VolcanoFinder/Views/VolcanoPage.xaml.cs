using VolcanoFinder.ViewModels;
using Xamarin.Forms;

namespace VolcanoFinder.Views
{
    public partial class VolcanoPage : ContentPage
    {
        VolcanoViewModel _viewModel;

        public VolcanoPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new VolcanoViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}