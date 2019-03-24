using Abp.Authorization;
using TaskManager.Authorization.Roles;
using TaskManager.Authorization.Users;

namespace TaskManager.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
