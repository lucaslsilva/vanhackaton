using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace TaskManager.Issue.Dto
{
	[AutoMap(typeof(Issue))]
    public class IssueDto : EntityDto<long>
    {
        public virtual string Description { get; set; }

        public virtual DateTime Deadline { get; set; }

        public virtual string Status { get; set; }

        public virtual DateTime CreationTime { get; set; }

        public virtual string Assignee { get; set; }

        public virtual long AssigneeId { get; set; }

        public virtual string CreatedBy { get; set; }
    }
}
