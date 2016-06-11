using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using TEDU.Model;
using TEDU.Model.Models;

namespace TEDU.Data
{
    public class TeduDbContext : IdentityDbContext<AppUser>
    {
#if DEBUG
        private static string ConnectString = "TEDUConnectionDbDev";
#else
              private static string ConnectString = "TEDUConnectionDbPro";
#endif
        public TeduDbContext() : base(ConnectString)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Category> Categories { set; get; }
        public DbSet<Post> Posts { set; get; }
        public DbSet<Error> Errors { set; get; }

        public DbSet<Tag> Tags { set; get; }
        public DbSet<PostTag> PostTags { set; get; }
        public DbSet<SystemParam> SystemParams { set; get; }
        public DbSet<Page> Pages { set; get; }
        public DbSet<Ebook> Ebooks { set; get; }

        public DbSet<Course> Courses { set; get; }

        public DbSet<CourseCategory> CourseCategories { set; get; }
        public DbSet<CourseReview> CourseReviews { set; get; }
        public DbSet<CourseTechLine> CourseTechLines { set; get; }
        public DbSet<CourseUser> CourseUsers { set; get; }
        public DbSet<CourseVideo> CourseVideos { set; get; }
        public DbSet<TechLine> TechLines { set; get; }
        public DbSet<PaymentMethod> PaymentMethods { set; get; }
        public DbSet<Trainer> Trainer { set; get; }
        public DbSet<VideoComment> VideoComments { set; get; }

        // ADD THIS:
        public IDbSet<AppGroup> AppGroups { get; set; }
        public IDbSet<AppRoleGroup> AppRoleGroups { get; set; }
        public IDbSet<AppUserGroup> AppUserGroups { get; set; }
        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId).ToTable("AppUserLogins");
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id).ToTable("AppRoles");
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId }).ToTable("AppUserRoles");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("AppUserClaims");


        }

        public static TeduDbContext Create()
        {
            return new TeduDbContext();
        }
    }
}