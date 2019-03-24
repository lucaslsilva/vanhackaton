using System.Reflection;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.AutoMapper;
using Abp.Modules;
using TaskManager.Authorization.Roles;
using TaskManager.Authorization.Users;
using TaskManager.Issue.Dto;
using TaskManager.Roles.Dto;
using TaskManager.Users.Dto;

namespace TaskManager
{
    [DependsOn(typeof(TaskManagerCoreModule), typeof(AbpAutoMapperModule))]
    public class TaskManagerApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
        }

        public override void Initialize()
        {
            //This code is used to register classes to dependency injection system for this assembly using conventions.
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            //We must declare mappings to be able to use AutoMapper
            //Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            //{
            //    DtoMappings.Map(mapper);
            //});

            // TODO: Is there somewhere else to store these, with the dto classes
            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg =>
            {
                // Role and permission
                cfg.CreateMap<Permission, string>().ConvertUsing(r => r.Name);
                cfg.CreateMap<RolePermissionSetting, string>().ConvertUsing(r => r.Name);

                cfg.CreateMap<CreateRoleDto, Role>().ForMember(x => x.Permissions, opt => opt.Ignore());
                cfg.CreateMap<RoleDto, Role>().ForMember(x => x.Permissions, opt => opt.Ignore());

                cfg.CreateMap<UserDto, User>();
                cfg.CreateMap<UserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());

                cfg.CreateMap<CreateUserDto, User>();
                cfg.CreateMap<CreateUserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());

                cfg.CreateMap<Issue.Issue, IssueDto>()
                    .ForMember(x => x.Assignee, x => x.MapFrom(u => u.Assignee.Name + " " + u.Assignee.Surname))
                    .ForMember(x => x.CreatedBy, x => x.MapFrom(u => u.CreatedBy.Name + " " + u.CreatedBy.Surname));
            });
        }
    }
}
