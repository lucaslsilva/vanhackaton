using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Abp.EntityFramework;
using TaskManager.Issue;

namespace TaskManager.EntityFramework.Repositories
{
    public class IssueRepository : TaskManagerRepositoryBase<Issue.Issue, long>, IIssueRepository
    {
        public IssueRepository(IDbContextProvider<TaskManagerDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public List<Issue.Issue> GetAllUserIssues(long? assigneeId)
        {
            var query = GetAll();

            if(assigneeId != null)
                query = query.Where(i => i.Assignee.Id == assigneeId);

            return query
                .OrderByDescending(i => i.CreationTime)
                .Include(i => i.Assignee)
                .Include(i => i.CreatedBy)
                .ToList();
        }
    }
}
