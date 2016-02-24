using System.Data.Entity.ModelConfiguration;
using TEDU.Model;

namespace TEDU.Data.Configuration
{
    public class ErrorConfiguration : EntityTypeConfiguration<Error>
    {
        public ErrorConfiguration()
        {
            ToTable("Errors");
        }
    }
}