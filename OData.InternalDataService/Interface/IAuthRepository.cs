using OData.Business.DomainClasses;
using System.Threading.Tasks;

namespace OData.InternalDataService.Interface
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string password);
        Task<bool> IsUserExist(string username);
    }
}
