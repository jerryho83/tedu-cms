using Tedu.Entities;

namespace Tedu.Data.Configurations
{
    public class GenreConfiguration : EntityBaseConfiguration<Genre>
    {
        public GenreConfiguration()
        {
            HasMany(e => e.Videos)
                .WithRequired(e => e.Genre)
                .WillCascadeOnDelete(false);
        }
    }
}