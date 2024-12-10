using System;
using System.Collections.Generic;
using System.Net;
using CourseWork.Domain.Entities;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using File = CourseWork.Domain.Entities.File;
using FileAccess = CourseWork.Domain.Entities.FileAccess;

namespace CourseWork.Persistence
{
    public sealed class CharityDBContext : DbContext
    {
        public CharityDBContext(DbContextOptions<CharityDBContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ChatRoom> ChatRooms { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<CommentMedia> CommentMedia { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseMedia> CourseMedia { get; set; }

        public DbSet<DailyUpdate> DailyUpdates { get; set; }

        public DbSet<File> Files { get; set; }

        public DbSet<FileAccess> FileAccesses { get; set; }

        public DbSet<LikesToCourse> LikesToCourses { get; set; }

        public DbSet<LikesToPost> LikesToPosts { get; set; }

        public DbSet<Message> Messages { get; set; }


        public DbSet<PostMedia> PostMedia { get; set; }

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UsersCourse> UsersCourses { get; set; }

        public DbSet<UserLanguage> UserLanguages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new List<Category>
            {
                new()
                {
                    CategoryId = 1,
                    Name = "Развивающие"
                },
                new()
                {
                    CategoryId = 2,
                    Name = "Познавательные"
                },
                new()
                {
                    CategoryId = 3,
                    Name = "Обучающие"
                }
            });

            modelBuilder.Entity<Course>().HasData(new List<Course>
            {
                new()
                {
                    CourseId = 1,
                    Name = "Тест",
                    Description = "string",
                    CategoryId = 2
                },
                new()
                {
                    CourseId = 2,
                    CategoryId = 2,
                    Name = "Тест",
                    Description = "string"
                },
                new()
                {
                    CourseId = 3,
                    CategoryId = 1,
                    Name = "Тест",
                    Description = "string"
                }
            });

            modelBuilder.Entity<FileAccess>().HasKey(e => new { e.FileId, e.UserId });

            modelBuilder.Entity<UsersCourse>().HasKey(uc => new { uc.CourseId, uc.UserId });

            modelBuilder.Entity<UserLanguage>().HasKey(e => new { e.UserId, e.Language });

            modelBuilder.Entity<UserLanguage>().HasKey(e => new { e.UserId, e.Language });
         
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict); 
        
        }
    }
}
