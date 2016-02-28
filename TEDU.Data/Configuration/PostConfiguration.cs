using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TEDU.Model;

namespace TEDU.Data.Configuration
{
    public class PostConfiguration : EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
            Property(x => x.ID).IsRequired()
              .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).IsRequired().HasMaxLength(250);
            Property(x => x.Alias).IsRequired().HasMaxLength(250);
            Property(x => x.CategoryID).IsRequired();
            Property(x => x.Status).IsRequired();
            Property(x => x.PostType).IsRequired().HasMaxLength(10);
            ToTable("Posts");
        }
    }
}