namespace TEDU.Data.Migrations
{
    using Common;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<TEDU.Data.TEDUEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TEDU.Data.TEDUEntities context)
        {
            //GetCategories().ForEach(c => context.Categories.AddOrUpdate(c));

            //GetPosts().ForEach(g => context.Posts.AddOrUpdate(g));

            //context.SaveChanges();


        }

        private static List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category {
                    Name = ".NET",
                    Alias = "dotnet",
                    Status = true,
                    CreatedDate=DateTime.Now
                },
                new Category {
                    Name = "Database",
                    Alias = "database",
                    Status = true,
                     CreatedDate=DateTime.Now
                },
               new Category {
                    Name = "Front End",
                    Alias = "front-end",
                    Status =true,
                     CreatedDate=DateTime.Now
                },
            };
        }

        private static List<Post> GetPosts()
        {
            return new List<Post>
            {
                new Post {
                    Name = "ProntoTec 7",
                    Description = "Android 4.4 KitKat Tablet PC, Cortex A8 1.2 GHz Dual Core Processor,512MB / 4GB,Dual Camera,G-Sensor (Black)",
                    CategoryID = 1,
                    Image = "prontotec.jpg",
                    Alias = "ulefont-n9000",
                    PostType = "news",
                    Status = StatusEnum.Publish.ToString(),
                     CreatedDate=DateTime.Now
                },
                new Post {
                    Name = "Samsung Galaxy",
                    Description = "Android 4.4 Kit Kat OS, 1.2 GHz quad-core processor",
                    CategoryID = 1,
                    Image= "samsung-galaxy.jpg",
                    Alias = "ulefont-n9000",
                    PostType = "news",
                    Status = StatusEnum.Publish.ToString(),
                     CreatedDate=DateTime.Now
                },
                new Post {
                    Name = "NeuTab® N7 Pro 7",
                    Description = "NeuTab N7 Pro tablet features the amazing powerful, Quad Core processor performs approximately Double multitasking running speed, and is more reliable than ever",
                    CategoryID = 1,
                    Image= "neutab.jpg",
                    Alias = "ulefont-n9000",
                    PostType = "news",
                    Status = StatusEnum.Publish.ToString(),
                     CreatedDate=DateTime.Now
                },
                new Post {
                    Name = "Dragon Touch® Y88X 7",
                    Description = "Dragon Touch Y88X tablet featuring the incredible powerful Allwinner Quad Core A33, up to four times faster CPU, ensures faster multitasking speed than ever. With the super-portable size, you get a robust power in a device that can be taken everywhere",
                    CategoryID = 1,
                    Image= "dragon-touch.jpg",
                    Alias = "ulefont-n9000",
                    PostType = "news",
                    Status = StatusEnum.Publish.ToString(),
                },
                new Post {
                    Name = "Alldaymall A88X 7",
                    Description = "This Alldaymall tablet featuring the incredible powerful Allwinner Quad Core A33, up to four times faster CPU, ensures faster multitasking speed than ever. With the super-portable size, you get a robust power in a device that can be taken everywhere",
                    CategoryID = 1,
                    Image= "Alldaymall.jpg",
                    Alias = "ulefont-n9000",
                    PostType = "news",
                    Status = StatusEnum.Publish.ToString(),
                     CreatedDate=DateTime.Now
                },
                new Post {
                    Name = "ASUS MeMO",
                    Description = "Pad 7 ME170CX-A1-BK 7-Inch 16GB Tablet. Dual-Core Intel Atom Z2520 1.2GHz CPU",
                    CategoryID = 1,
                    Image= "asus-memo.jpg",
                    Alias = "ulefont-n9000",
                    PostType = "news",
                    Status = StatusEnum.Publish.ToString(),
                     CreatedDate=DateTime.Now
                },
                new Post {
                    Name = "ASUS 15.6-Inch",
                    Description = "Latest Generation Intel Dual Core Celeron 2.16 GHz Processor (turbo to 2.41 GHz)",
                    CategoryID = 2,
                    Image = "asus-latest.jpg",
                    Alias = "ulefont-n9000",
                    PostType = "news",
                    Status = StatusEnum.Publish.ToString(),
                     CreatedDate=DateTime.Now
                },
                new Post {
                    Name = "HP Pavilion 15-r030wm",
                    Description = "This Certified Refurbished product is manufacturer refurbished, shows limited or no wear, and includes all original accessories plus a 90-day warranty",
                    CategoryID = 2,
                    Image = "hp-pavilion.jpg",
                    Alias = "ulefont-n9000",
                    PostType = "news",
                    Status = StatusEnum.Publish.ToString(),
                     CreatedDate=DateTime.Now
                },
                new Post {
                    Name = "Dell Inspiron 15.6-Inch",
                    Description = "Intel Celeron N2830 Processor, 15.6-Inch Screen, Intel HD Graphics",
                    CategoryID = 2,
                    Image = "dell-inspiron.jpg",
                    Alias = "ulefont-n9000",
                    PostType = "news",
                    Status = StatusEnum.Publish.ToString(),
                     CreatedDate=DateTime.Now
                },
                new Post {
                    Name = "Acer Aspire E Notebook",
                    Description = "15.6 HD Active Matrix TFT Color LED (1366 x 768) 16:9 CineCrystal Display",
                    CategoryID = 2,
                    Image = "acer-aspire.jpg",
                    Alias = "ulefont-n9000",
                    PostType = "news",
                    Status = StatusEnum.Publish.ToString(),
                     CreatedDate=DateTime.Now
                },
                new Post {
                    Name = "HP Stream 13",
                    Description = "Intel Celeron N2840 Processor. 2 GB DDR3L SDRAM, 32 GB Solid-State Drive and 1TB OneDrive Cloud Storage for one year",
                    CategoryID = 2,
                    Image = "hp-stream.jpg",
                    Alias = "ulefont-n9000",
                    PostType = "news",
                    Status = StatusEnum.Publish.ToString(),
                     CreatedDate=DateTime.Now
                },
                new Post {
                    Name = "Nokia Lumia 521",
                    Description = "T-Mobile Cell Phone 4G - White. 5MP Camera - Snap creative photos with built-in digital lenses",
                    CategoryID = 3,
                    Image = "nokia-lumia.jpg",
                    Alias = "ulefont-n9000",
                    PostType = "news",
                    Status = StatusEnum.Publish.ToString(),
                     CreatedDate=DateTime.Now
                },
                new Post {
                    Name = "HTC Desire 816",
                    Description = "13 MP Rear Facing BSI Camera / 5 MP Front Facing",
                    CategoryID = 3,
                    Image = "htc-desire.jpg",
                    Alias = "ulefont-n9000",
                    PostType = "news",
                    Status = StatusEnum.Publish.ToString(),
                     CreatedDate=DateTime.Now
                },
                new Post {
                    Name = "Sanyo Innuendo",
                    Description = "Uniquely designed 3G-enabled messaging phone with side-flipping QWERTY keyboard and external glow-thru OLED dial pad that 'disappears' when not in use",
                    CategoryID = 3,
                    Image = "sanyo-innuendo.jpg",
                    Alias = "ulefont-n9000",
                    PostType = "news",
                    Status = StatusEnum.Publish.ToString(),
                     CreatedDate=DateTime.Now
                },
                new Post {
                    Name = "Ulefone N9000",
                    Alias = "ulefont-n9000",
                    PostType = "news",
                    Status = StatusEnum.Publish.ToString(),
                    Description = "Unlocked world GSM phone. 3G-850/2100, 2G -850/900/1800/1900",
                    CategoryID = 3,
                    Image = "ulefone.jpg",
                     CreatedDate=DateTime.Now
                }
            };
        }
    }
}