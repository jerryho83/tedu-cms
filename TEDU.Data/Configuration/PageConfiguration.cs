using System.Data.Entity.ModelConfiguration;
using TEDU.Model.Models;

namespace TEDU.Data.Configuration
{
    public class PageConfiguration : EntityTypeConfiguration<Page>
    {
        public PageConfiguration()
        {
            ToTable("Pages");
        }
    }
}