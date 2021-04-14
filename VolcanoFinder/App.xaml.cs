using Microsoft.Identity.Client;
using VolcanoFinder.Services;
using Xamarin.Forms;

namespace VolcanoFinder
{
    public partial class App : Application
    {

        public static object AuthUIParent = null;

        public static IPublicClientApplication ClientApplication;
        public static AuthenticationResult AuthResult;
        public static IAccount CurrentAccount;

        public App()
        {
            InitializeComponent();

            ClientApplication = PublicClientApplicationBuilder.Create(Constants.ClientId)
                              .WithRedirectUri(Constants.RedirectUri)
                              .WithAuthority($"https://login.microsoftonline.com/{Constants.TenantId}")
                              .WithIosKeychainSecurityGroup(Constants.iOSKeyChainSecurityGroup)
                              .Build();

            //Using Mock services...
            DependencyService.Register<MockDataStore>();
            DependencyService.Register<MockAuthService>();
            
            //Using Azure Cloud Services...
            //DependencyService.Register<CloudDataStore>();
            //DependencyService.Register<CloudAuthService>();
            
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
