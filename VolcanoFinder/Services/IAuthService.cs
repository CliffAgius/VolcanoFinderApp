using System.Threading.Tasks;

namespace VolcanoFinder.Services
{
    public interface IAuthService
    {
        Task SignInAsync();
        Task SignOut();
    }
}
