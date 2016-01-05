using Tedu.Entities;

namespace Tedu.Data.Configurations
{
    public class CourseConfiguration : EntityBaseConfiguration<Course>
    {
        public CourseConfiguration()
        {
            Property(e => e.Alias)
                .IsUnicode(false);

            Property(e => e.Price)
                .HasPrecision(18, 0);

            Property(e => e.PromotionPrice)
                .HasPrecision(18, 0);

            HasMany(e => e.CourseConsumeds)
                .WithRequired(e => e.Cours)
                .HasForeignKey(e => e.CourseID)
                .WillCascadeOnDelete(false);

            HasMany(e => e.Videos)
                .WithRequired(e => e.Cours)
                .HasForeignKey(e => e.CourseID)
                .WillCascadeOnDelete(false);
        }
    }
}