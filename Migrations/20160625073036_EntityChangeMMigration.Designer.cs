using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AspnetCoreRC2Poc;

namespace AspnetCoreRC2Poc.Migrations
{
    [DbContext(typeof(BloggingContext))]
    [Migration("20160625073036_EntityChangeMMigration")]
    partial class EntityChangeMMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20896")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AspnetCoreRC2Poc.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AllowComments");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("ModifiedOn")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Title");

                    b.Property<string>("Url");

                    b.Property<int>("UserId");

                    b.HasKey("BlogId");

                    b.HasIndex("UserId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("AspnetCoreRC2Poc.BlogImage", b =>
                {
                    b.Property<int>("BlogImageId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BlogId");

                    b.Property<string>("Caption");

                    b.Property<byte[]>("Image");

                    b.HasKey("BlogImageId");

                    b.HasIndex("BlogId");

                    b.ToTable("BlogImage");
                });

            modelBuilder.Entity("AspnetCoreRC2Poc.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("ModifiedOn")
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("AspnetCoreRC2Poc.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("HomePage");

                    b.Property<string>("Ip");

                    b.Property<string>("Name");

                    b.Property<int?>("PostId");

                    b.Property<string>("Text");

                    b.HasKey("CommentId");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("AspnetCoreRC2Poc.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BlogId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("ModifiedOn")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Title");

                    b.HasKey("PostId");

                    b.HasIndex("BlogId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("AspnetCoreRC2Poc.PostCategory", b =>
                {
                    b.Property<int>("PostId");

                    b.Property<int>("CategoryId");

                    b.HasKey("PostId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PostId");

                    b.ToTable("PostCategory");
                });

            modelBuilder.Entity("AspnetCoreRC2Poc.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ItemId");

                    b.Property<int>("ItemType");

                    b.Property<string>("Name");

                    b.HasKey("TagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("AspnetCoreRC2Poc.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bio");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AspnetCoreRC2Poc.Blog", b =>
                {
                    b.HasOne("AspnetCoreRC2Poc.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AspnetCoreRC2Poc.BlogImage", b =>
                {
                    b.HasOne("AspnetCoreRC2Poc.Blog")
                        .WithOne()
                        .HasForeignKey("AspnetCoreRC2Poc.BlogImage", "BlogId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AspnetCoreRC2Poc.Comment", b =>
                {
                    b.HasOne("AspnetCoreRC2Poc.Post")
                        .WithMany()
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("AspnetCoreRC2Poc.Post", b =>
                {
                    b.HasOne("AspnetCoreRC2Poc.Blog")
                        .WithMany()
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AspnetCoreRC2Poc.PostCategory", b =>
                {
                    b.HasOne("AspnetCoreRC2Poc.Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AspnetCoreRC2Poc.Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
