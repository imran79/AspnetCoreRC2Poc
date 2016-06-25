using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;
using System;



namespace AspnetCoreRC2Poc
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<BlogImage> BlogImage { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Cascading  and Foriegn key constraint
            modelBuilder.Entity<Post>()
                        .HasOne(p => p.Blog)
                        .WithMany(b => b.Posts)
                        .HasForeignKey(c => c.BlogId)
                        .OnDelete(DeleteBehavior.Cascade);
            //many to many relationship implementation with meditator table

             modelBuilder.Entity<PostCategory>()
                .HasKey(t => new { t.PostId, t.CategoryId });

            modelBuilder.Entity<PostCategory>()
                        .HasOne(pc => pc.Post)
                        .WithMany(p => p.PostCategories)
                        .HasForeignKey(pc => pc.PostId);

            modelBuilder.Entity<PostCategory>()
                        .HasOne(pc => pc.Category)
                        .WithMany(c => c.PostCategories)
                        .HasForeignKey(pc => pc.CategoryId);
            // One Navigation
            modelBuilder.Entity<Blog>()
                        .HasMany(b => b.Posts)
                        .WithOne();

            modelBuilder.Entity<Blog>()
                        .HasOne(b => b.BlogImage)
                        .WithOne(bi => bi.Blog)
            .HasForeignKey<BlogImage>(bi => bi.BlogId);

            modelBuilder.Entity<User>()
                        .HasMany(b => b.Blogs)
                        .WithOne(bi => bi.CreatedBy);
            
            // Eager loading
            modelBuilder.Entity<Post>()
                        .HasOne(p => p.Blog)
                        .WithMany(b => b.Posts)
                        .IsRequired();
           // Auto Generation- will tke DB Server time-- need to convert base on the culture of user
            modelBuilder.Entity<Blog>()
                        .Property(b => b.CreatedOn)
                        .ValueGeneratedOnAdd();

            modelBuilder.Entity<Blog>()
                        .Property(b => b.ModifiedOn)
                        .ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<Post>()
                        .Property(b => b.CreatedOn)
                        .ValueGeneratedOnAdd();
            modelBuilder.Entity<Post>()
                        .Property(b => b.ModifiedOn)
                        .ValueGeneratedOnAddOrUpdate();

             modelBuilder.Entity<Category>()
                         .Property(b => b.CreatedOn)
                         .ValueGeneratedOnAdd();
            modelBuilder.Entity<Category>()
                        .Property(b => b.ModifiedOn)
                        .ValueGeneratedOnAddOrUpdate();



        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=C:\CODE SAMPLES\ASPNETCORERC2POC\DB\MYBLOG.MDF;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }

    public class Blog
    {
        public int BlogId { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public bool AllowComments { get; set; }

        public IEnumerable<Post> Posts { get; set; }

        public int UserId{get;set;}

        public User CreatedBy { get; set; }

        public BlogImage BlogImage { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }

    public class Post
    {

        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime ModifiedOn { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public IEnumerable<PostCategory> PostCategories { get; set; }
    }

    public class Comment
    {

        public int CommentId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string HomePage { get; set; }

        public string Ip { get; set; }

        public string Text { get; set; }

    }

    public class Category
    {

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public List<PostCategory> PostCategories { get; set; }
    }

    public class Tag
    {
        public int TagId { get; set; }

        public string Name { get; set; }

        public int ItemId { get; set; }

        public ItemType ItemType { get; set; }

    }

    public enum ItemType
    {

        Blog = 0,
        Post = 1
    }

    public class User
    {
        public int UserId { get; set; }
        public string Password { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Bio { get; set; }

        public IEnumerable<Blog> Blogs { get; set; }
    }

    public class PostCategory
    {
        
        public int PostId { get; set; }
        public Post Post { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

    public class BlogImage
    {
        public int BlogImageId { get; set; }
        public byte[] Image { get; set; }
        public string Caption { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}

