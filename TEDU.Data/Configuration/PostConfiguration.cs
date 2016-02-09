using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
