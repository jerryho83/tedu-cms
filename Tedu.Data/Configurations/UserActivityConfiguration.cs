using Tedu.Entities;

namespace Tedu.Data.Configurations
{
    public class UserActivityConfiguration : EntityBaseConfiguration<UserActivity>
    {
        public UserActivityConfiguration()
        {
            Property(e => e.ActionName)
               .IsUnicode(false);

            Property(e => e.IPAddress)
                .IsUnicode(false);
        }
    }
}