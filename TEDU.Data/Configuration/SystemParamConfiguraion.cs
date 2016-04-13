using System.Data.Entity.ModelConfiguration;
using TEDU.Model.Models;

namespace TEDU.Data.Configuration
{
    public class SystemParamConfiguraion : EntityTypeConfiguration<SystemParam>
    {
        public SystemParamConfiguraion()
        {
            ToTable("SystemParams");
        }
    }
}