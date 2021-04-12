using VolcanoFinder.ViewModels;
using Xamarin.Forms;

namespace VolcanoFinder.Views
{
    public partial class VolcanoDetailPage : ContentPage
    {
        public VolcanoDetailPage()
        {
            InitializeComponent();
            BindingContext = new VolcanoDetailViewModel();
        }
    }
}