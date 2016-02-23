using System.Data.Entity.ModelConfiguration;
using TEDU.Model;

namespace TEDU.Data.Configuration
{
    public class PostConfiguration : EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
            ToTable("Posts");
        }
    }
}