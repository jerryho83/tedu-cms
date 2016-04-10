﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEDU.Data.Configuration;
using TEDU.Model;
using TEDU.Model.Models;

namespace TEDU.Data
{
    public class TEDUEntities : DbContext
    {
        public TEDUEntities() : base("TEDUConnectionDb") {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Category> Categories { set; get; }
        public DbSet<Post> Posts { set; get; }
        public DbSet<Error> Errors { set; get; }

        public DbSet<Tag> Tags { set; get; }
        public DbSet<PostTag> PostTags { set; get; }

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
        }
    }
}
