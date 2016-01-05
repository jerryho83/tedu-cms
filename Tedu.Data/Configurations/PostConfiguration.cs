using Tedu.Entities;

namespace Tedu.Data.Configurations
{
    public class PostConfiguration : EntityBaseConfiguration<Post>
    {
        public PostConfiguration()
        {
            Property(e => e.Alias)
                .IsUnicode(false);

            HasMany(e => e.Tags)
                .WithMany(e => e.Posts)
                .Map(m => m.ToTable("PostTags").MapLeftKey("PostID").MapRightKey("TagID"));
        }
    }
}