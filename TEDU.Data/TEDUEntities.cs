using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using TEDU.Data.Configuration;
using TEDU.Model;
using TEDU.Model.Models;

namespace TEDU.Data
{
    public class TEDUEntities : IdentityDbContext<AppUser>
    {
        public TEDUEntities() : base("TEDUConnectionDb")
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
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new PostConfiguration());
            modelBuilder.Configurations.Add(new ErrorConfiguration());

            modelBuilder.Configurations.Add(new TagConfiguration());
            modelBuilder.Configurations.Add(new PostTagConfiguration());
            modelBuilder.Configurations.Add(new SystemParamConfiguraion());
            modelBuilder.Configurations.Add(new PageConfiguration());
            modelBuilder.Configurations.Add(new EbookConfiguration());


            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }

        public static TEDUEntities Create()
        {
            return new TEDUEntities();
        }
    }
}