using System.Data.Entity.ModelConfiguration;
using TEDU.Model;

namespace TEDU.Data.Configuration
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            HasKey(x => x.ID);
            ToTable("Categories");
        }
    }
}