using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using TaskManager.Configuration.Dto;

namespace TaskManager.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : TaskManagerAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
