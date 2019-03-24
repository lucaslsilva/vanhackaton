using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Authorization.Users;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using TaskManager.Migrations.SeedData;
using EntityFramework.DynamicFilters;
using TaskManager.Authorization.Roles;
using TaskManager.Authorization.Users;

namespace TaskManager.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<EntityFramework.TaskManagerDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "TaskManager";
        }

        protected override void Seed(EntityFramework.TaskManagerDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();
        }
    }
}
