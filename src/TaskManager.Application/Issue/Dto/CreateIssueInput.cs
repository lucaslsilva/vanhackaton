using System;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;

namespace TaskManager.Issue.Dto
{
    [AutoMap(typeof(IssueDto))]
    public class CreateIssueInput
    {
        [Required]
        public virtual string Description { get; set; }
        
        public virtual DateTime Deadline { get; set; }

        public virtual long AssigneeId { get; set; }

        public override string ToString()
        {
            return $"Description: {Description}, Deadline: {Deadline}";
        }
    }
}
