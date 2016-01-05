using Tedu.Entities;

namespace Tedu.Data.Configurations
{
    public class CourseConsumedConfiguration : EntityBaseConfiguration<CourseConsumed>
    {
        public CourseConsumedConfiguration()
        {
            Property(e => e.Value)
              .HasPrecision(18, 0);
        }
    }
}