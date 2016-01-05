using Tedu.Entities;

namespace Tedu.Data.Configurations
{
    public class UserConfiguration : EntityBaseConfiguration<User>
    {
        public UserConfiguration()
        {
            Property(e => e.VideoBookmark)
               .IsUnicode(false);

            Property(e => e.VideoViewed)
                .IsUnicode(false);

            HasMany(e => e.CourseConsumeds)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            HasMany(e => e.UserPractices)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}