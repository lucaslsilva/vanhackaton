using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using TaskManager.Authorization.Users;

namespace TaskManager.Issue
{
    public class Issue : Entity<long>
    {
        public virtual string Description { get; set; }

        public virtual DateTime Deadline { get; set; }

        public virtual string Status { get; set; }

        public virtual DateTime CreationTime { get; set; }

        [ForeignKey("AssigneeId")]
        public virtual User Assignee { get; set; }

        public virtual long AssigneeId { get; set; }

        [ForeignKey("CreatedById")]
        public virtual User CreatedBy { get; set; }

        public virtual long CreatedById { get; set; }

        public Issue()
        {
            CreationTime = DateTime.Now;
            Status = StatusEnum.Open;
        }
    }
}