using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEDU.Model.Models;

namespace TEDU.Data.Configuration
{
    public class PostTagConfiguration : EntityTypeConfiguration<PostTag>
    {
        public PostTagConfiguration()
        {
            ToTable("PostTags");
        }
    }
}
