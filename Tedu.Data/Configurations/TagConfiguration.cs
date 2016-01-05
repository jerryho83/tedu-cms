using Tedu.Entities;

namespace Tedu.Data.Configurations
{
    public class TagConfiguration : EntityBaseConfiguration<Tag>
    {
        public TagConfiguration()
        {
            Property(e => e.ID);
        }
    }
}