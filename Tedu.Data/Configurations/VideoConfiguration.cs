using Tedu.Entities;

namespace Tedu.Data.Configurations
{
    public class VideoConfiguration : EntityBaseConfiguration<Video>
    {
        public VideoConfiguration()
        {
            Property(e => e.Alias)
               .IsUnicode(false);

            Property(e => e.Duration)
                    .IsUnicode(false);

            Property(e => e.UserLiked)
                    .IsUnicode(false);

            HasMany(e => e.UserPractices)
                    .WithRequired(e => e.Video)
                    .WillCascadeOnDelete(false);
        }
    }
}