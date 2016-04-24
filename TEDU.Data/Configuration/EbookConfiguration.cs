using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEDU.Model.Models;

namespace TEDU.Data.Configuration
{
    public class EbookConfiguration : EntityTypeConfiguration<Ebook>
    {
        public EbookConfiguration()
        {
            Property(x => x.ID).IsRequired()
                 .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).IsRequired().HasMaxLength(250);
            Property(x => x.Alias).IsRequired().HasMaxLength(250);
            ToTable("Ebooks");
        }
    }
}
