using System.Security.Claims;
using System.Threading.Tasks;
using PersAcc.Domain.Response;
using PersAcc.Domain.ViewModels.Account;

namespace PersAcc.Service.Interfaces
{
    public interface IAccountService
    {
        Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model);

        Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model);

    }
}