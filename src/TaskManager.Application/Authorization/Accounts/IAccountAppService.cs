using System.Threading.Tasks;
using Abp.Application.Services;
using TaskManager.Authorization.Accounts.Dto;

namespace TaskManager.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
