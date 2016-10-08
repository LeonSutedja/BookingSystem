using Abp.Authorization;
using BookingSystem.Authorization.Roles;
using BookingSystem.MultiTenancy;
using BookingSystem.Users;

namespace BookingSystem.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
