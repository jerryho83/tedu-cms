using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Tedu.Data.Configurations;
using Tedu.Entities;

namespace Tedu.Data
{
    public class TeduContext : DbContext
    {
        public TeduContext()
            : base("TeduConnnectionString")
        {
            Database.SetInitializer<TeduContext>(null);
        }
        public virtual void Commit()
        {
            base.SaveChanges();
        }
        #region Entity Sets
        public virtual DbSet<Configuration> Configurations { get; set; }
        public virtual DbSet<CourseConsumed> CourseConsumeds { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Error> Errors { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<PostCategory> PostCategories { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<UserActivity> UserActivities { get; set; }
        public virtual DbSet<UserPractice> UserPractices { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Video> Videos { get; set; }
        public virtual DbSet<Visitor> Visitors { get; set; }
        #endregion
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new CourseConfiguration());
            modelBuilder.Configurations.Add(new CourseConsumedConfiguration());
            modelBuilder.Configurations.Add(new GenreConfiguration());
            modelBuilder.Configurations.Add(new PostCategoryConfiguration());
            modelBuilder.Configurations.Add(new TagConfiguration());
            modelBuilder.Configurations.Add(new PostConfiguration());
            modelBuilder.Configurations.Add(new UserActivityConfiguration());
            modelBuilder.Configurations.Add(new VideoConfiguration());
            modelBuilder.Configurations.Add(new VisitorConfiguration());
        }
    }
}