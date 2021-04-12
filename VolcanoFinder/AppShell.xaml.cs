using System;
using System.Collections.Generic;
using VolcanoFinder.ViewModels;
using VolcanoFinder.Views;
using Xamarin.Forms;

namespace VolcanoFinder
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(VolcanoDetailPage), typeof(VolcanoDetailPage));
            Routing.RegisterRoute(nameof(NewVolcanoPage), typeof(NewVolcanoPage));
        }

    }
}
