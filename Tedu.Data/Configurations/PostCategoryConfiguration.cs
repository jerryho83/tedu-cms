using Tedu.Entities;

namespace Tedu.Data.Configurations
{
    public class PostCategoryConfiguration : EntityBaseConfiguration<PostCategory>
    {
        public PostCategoryConfiguration()
        {
            Property(e => e.Alias)
              .IsUnicode(false);

            HasMany(e => e.Posts)
                .WithRequired(e => e.PostCategory)
                .HasForeignKey(e => e.CategoryID)
                .WillCascadeOnDelete(false);
        }
    }
}