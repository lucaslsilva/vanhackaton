using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using TaskManager.Issue.Dto;
using TaskManager.Users.Dto;

namespace TaskManager.Issue
{
    public interface IIssueAppService : IAsyncCrudAppService<IssueDto, long, PagedResultRequestDto, CreateIssueInput, UpdateIssueInput>
    {
        List<IssueDto> GetIssues();
        void UpdateIssue(UpdateIssueInput input);
        void CreateIssue(CreateIssueInput input);
        Task<ListResultDto<UserDto>> GetUsers();
    }
}
