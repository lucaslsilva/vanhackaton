using System.Threading.Tasks;
using Abp.Application.Services;
using TaskManager.Sessions.Dto;

namespace TaskManager.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
