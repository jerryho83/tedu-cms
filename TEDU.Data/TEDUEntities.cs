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

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }

        public static TeduDbContext Create()
        {
            return new TeduDbContext();
        }
    }
}