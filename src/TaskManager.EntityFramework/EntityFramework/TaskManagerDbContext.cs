using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using TaskManager.Authorization.Roles;
using TaskManager.Authorization.Users;
using TaskManager.MultiTenancy;

namespace TaskManager.EntityFramework
{
    public class TaskManagerDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        public virtual IDbSet<Issue.Issue> Issues { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public TaskManagerDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in TaskManagerDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of TaskManagerDbContext since ABP automatically handles it.
         */
        public TaskManagerDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public TaskManagerDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public TaskManagerDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
