using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TEDU.Model;

namespace TEDU.Data.Configuration
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            Property(x => x.ID).IsRequired()
                 .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).IsRequired().HasMaxLength(250);
            Property(x => x.Alias).IsRequired().HasMaxLength(250);
            ToTable("Categories");
        }
    }
}