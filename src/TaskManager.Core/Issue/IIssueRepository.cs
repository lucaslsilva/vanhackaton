using System.Collections.Generic;
using Abp.Domain.Repositories;

namespace TaskManager.Issue
{
    public interface IIssueRepository : IRepository<Issue, long>
    {
        List<Issue> GetAllUserIssues(long? assigneeId);
    }
}
