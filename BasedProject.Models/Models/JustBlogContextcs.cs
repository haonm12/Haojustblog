using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasedProject.Models.Models
{
    public class JustBlogContext : DbContext
    {
        public JustBlogContext(DbContextOptions<JustBlogContext> options) 
            : base(options) { }

        public JustBlogContext() { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<PostTagMap> PostTagMaps { get; set; }       
        public DbSet<Comment> Comments { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //                optionsBuilder.UseSqlServer("server=DESKTOP-V5TVV31\\SQLEXPRESS;database=DoAn;uid=sa;pwd=12345;Integrated Security=True;TrustServerCertificate=True");
        //            }
        //        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-Q159DV2C\\SQLEXPRESS;Initial Catalog=JustBlog;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

          
            modelBuilder.Entity<PostTagMap>()
                .HasKey(pt => new { pt.PostId, pt.TagId });

            modelBuilder.Entity<PostTagMap>()
                .HasOne(pt => pt.Post) 
                .WithMany(p => p.PostTagMap) 
                .HasForeignKey(pt => pt.PostId) 
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<PostTagMap>()
                .HasOne(pt => pt.Tags) 
                .WithMany(t => t.PostTagsmaps) 
                .HasForeignKey(pt => pt.TagId) 
                .OnDelete(DeleteBehavior.Cascade); 

           
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Technology", UrlSlug = "technology", Description = "Posts related to technology and programming" },
                new Category { Id = 2, Name = "Health", UrlSlug = "health", Description = "Posts about health, wellness, and fitness" },
                new Category { Id = 3, Name = "Lifestyle", UrlSlug = "lifestyle", Description = "Lifestyle and personal development posts" }
            );

           
            modelBuilder.Entity<Tags>().HasData(
                new Tags { Id = 1, Name = "C#", UrlSlug = "csharp", Description = "Programming language", Count = 10 },
                new Tags { Id = 2, Name = "Health", UrlSlug = "health-tips", Description = "Health tips", Count = 8 },
                new Tags { Id = 3, Name = "Fitness", UrlSlug = "fitness", Description = "Fitness routines", Count = 12 }
            );

          
            modelBuilder.Entity<Post>().HasData(
                new Post { Id = 1, Title = "Introduction to C#", ShortDescription = "Basic guide to C#", PostContent = "Content of the C# post", UrlSlug = "introduction-to-csharp", Published = true, PostedOn = DateTime.UtcNow, Modified = DateTime.UtcNow, CategoryId = 1 },
                new Post { Id = 2, Title = "Health Benefits of Yoga", ShortDescription = "Yoga benefits", PostContent = "Content about yoga health benefits", UrlSlug = "health-benefits-of-yoga", Published = true, PostedOn = DateTime.UtcNow, Modified = DateTime.UtcNow, CategoryId = 2 },
                new Post { Id = 3, Title = "10 Tips for a Better Lifestyle", ShortDescription = "Lifestyle tips", PostContent = "Content on improving lifestyle", UrlSlug = "10-tips-better-lifestyle", Published = true, PostedOn = DateTime.UtcNow, Modified = DateTime.UtcNow, CategoryId = 3 }
            );
        }
    }
}
