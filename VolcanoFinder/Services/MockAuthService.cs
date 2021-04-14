using System;
using System.Threading.Tasks;

namespace VolcanoFinder.Services
{
    public class MockAuthService : IAuthService
    {
        public MockAuthService()
        {
        }

        public async Task SignInAsync()
        {
            App.AuthResult = new Microsoft.Identity.Client.AuthenticationResult("MockAccessToken", false, Guid.NewGuid().ToString(),
                DateTime.UtcNow.AddDays(7), DateTime.UtcNow.AddDays(10), Constants.TenantId, App.CurrentAccount, Constants.ClientId,
                Constants.Scopes, Guid.NewGuid());
        }

        public async Task SignOut()
        {
            App.AuthResult = null;
            App.CurrentAccount = null;
        }
    }
}
