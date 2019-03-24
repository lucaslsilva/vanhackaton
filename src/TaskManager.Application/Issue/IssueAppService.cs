using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Runtime.Session;
using Abp.UI;
using AutoMapper;
using Microsoft.AspNet.Identity;
using TaskManager.Authorization.Roles;
using TaskManager.Authorization.Users;
using TaskManager.Issue.Dto;
using TaskManager.Users.Dto;

namespace TaskManager.Issue
{
    public class IssueAppService : AsyncCrudAppService<Issue, IssueDto, long, PagedResultRequestDto, CreateIssueInput, UpdateIssueInput>, IIssueAppService
    {
        private readonly IIssueRepository _issueRepository;
        private readonly IRepository<User, long> _userRepository;
        private readonly IAbpSession _session;
        private readonly UserManager _userManager;

        public IssueAppService(IIssueRepository issueRepository, IRepository<User, long> userRepository, IAbpSession session, UserManager userManager)
            : base(issueRepository)
        {
            _issueRepository = issueRepository;
            _userRepository = userRepository;
            _session = session;
            _userManager = userManager;
        }

        public List<IssueDto> GetIssues()
        {
            long? userId = null;

            if (_session.UserId.HasValue)
            {
                var roles = _userManager.GetRoles(_session.UserId.Value);
                if(roles.All(role => role != "Admin"))
                    userId = _session.UserId.Value;
            }

            var issues = _issueRepository.GetAllUserIssues(userId);
            return Mapper.Map<List<IssueDto>>(issues);
        }

        public void UpdateIssue(UpdateIssueInput input)
        {
            Logger.Info("Updating a issue for input: " + input);
            
            var issue = _issueRepository.Get(input.Id);

            if (!string.IsNullOrEmpty(input.Status))
            {
                issue.Status = input.Status;
            }

            if (!string.IsNullOrEmpty(input.Description))
            {
                issue.Description = input.Description;
            }

            if (input.Deadline.HasValue)
            {
                issue.Deadline = input.Deadline.Value;
            }

            if (input.AssigneeId.HasValue)
            {
                issue.Assignee = _userRepository.Load(input.AssigneeId.Value);
            }
        }

        public void CreateIssue(CreateIssueInput input)
        {
            Logger.Info("Creating a issue for input: " + input);

            if (!_session.UserId.HasValue)
            {
                throw new UserFriendlyException(L("IssueCreationUserNotFound"));
            }
            
            var issue = new Issue
            {
                Description = input.Description,
                Deadline = input.Deadline,
                AssigneeId = input.AssigneeId,
                CreatedById = _session.UserId.Value
            };
            
            _issueRepository.Insert(issue);
        }

        public async Task<ListResultDto<UserDto>> GetUsers()
        {
            var users = await _userRepository.GetAllListAsync();
            return new ListResultDto<UserDto>(ObjectMapper.Map<List<UserDto>>(users));
        }
    }
}
