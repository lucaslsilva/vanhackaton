using System.Threading.Tasks;
using Abp.Application.Services;
using TaskManager.Configuration.Dto;

namespace TaskManager.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}