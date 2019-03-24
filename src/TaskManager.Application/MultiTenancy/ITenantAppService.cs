using Abp.Application.Services;
using Abp.Application.Services.Dto;
using TaskManager.MultiTenancy.Dto;

namespace TaskManager.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
