using System;
using System.Collections.Generic;
using CourseWork.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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
        
        public DbSet<Course> Courses { get; set; }
        
        public DbSet<Message> Messages { get; set; }
        
        public DbSet<Post> Posts { get; set; }
        
        public DbSet<User> Users { get; set; }


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

            base.OnModelCreating(modelBuilder);
        }
    }
    
    
    
}
