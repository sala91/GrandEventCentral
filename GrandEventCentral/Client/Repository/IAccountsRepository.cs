using System.Threading.Tasks;
using GrandEventCentral.Shared.DTOs;

namespace GrandEventCentral.Client.Repository
{
    public interface IAccountsRepository
    {
        Task<UserToken> Login(UserInfo userInfo);
        Task<UserToken> Register(UserInfo userInfo);
    }
}
