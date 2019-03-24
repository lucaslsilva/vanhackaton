using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace TaskManager.Issue.Dto
{
    [AutoMap(typeof(IssueDto))]
    public class UpdateIssueInput : EntityDto<long>
    {
        public virtual string Description { get; set; }

        public virtual DateTime? Deadline { get; set; }

        public virtual string Status { get; set; }

        public virtual long? AssigneeId { get; set; }

        public override string ToString()
        {
            return $"Description: {Description}, Dealine: {Deadline:MM/dd/yyyy}, Status: {Status}";
        }
    }
}
