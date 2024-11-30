using System;
using System.Collections.Generic;
using CourseWork.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using File = CourseWork.Domain.Entities.File;
using FileAccess = CourseWork.Domain.Entities.FileAccess;

namespace CourseWork.Persistence
{
    public sealed class CharityDBContext : DbContext
    {
        public CharityDBContext()
        {
        }

        public CharityDBContext(DbContextOptions<CharityDBContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<ChatRoom> ChatRooms { get; set; }
        public DbSet<ChatRoomUser> ChatRoomUsers { get; set; }
        
        public DbSet<Comment> Comments { get; set; }
        
        public DbSet<CommentFile> CommentMedia { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseFile> CoursesFiles { get; set; }
        
        public DbSet<DailyUpdate> DailyUpdates { get; set; }
        
        public DbSet<File> Files { get; set; }
        
        public DbSet<FileAccess> FileAccesses { get; set; }
        
        public DbSet<LikeOnCourse> LikesToCourses { get; set; }
        
        public DbSet<LikeOnPost> LikesToPosts { get; set; }
        
        public DbSet<Message> Messages { get; set; }
        
        public DbSet<Post> Posts { get; set; }
        
        public DbSet<PostFile> PostsFiles { get; set; }
        
        public DbSet<Role> Roles { get; set; }
        
        public DbSet<User> Users { get; set; }
        
        public DbSet<UsersCourse> UsersCourses { get; set; }
        
        public DbSet<UserLanguage> UserLanguages { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryId).HasColumnName("idCategory");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(100)
                    .HasColumnName("nameCategory");
            });

            modelBuilder.Entity<ChatRoom>(entity =>
            {
                entity.Property(e => e.RoomName)
                    .HasMaxLength(100);
                
                entity.HasMany(e => e.ChatRoomUsers)
                    .WithOne(cru => cru.ChatRoom)
                    .HasForeignKey(cru => cru.ChatRoomId);
            });

            modelBuilder.Entity<ChatRoomUser>()
            .HasKey(cru => new { cru.ChatRoomId, cru.UserId }); 

            modelBuilder.Entity<ChatRoomUser>()
                .HasOne(cru => cru.ChatRoom)
                .WithMany(cr => cr.ChatRoomUsers)
                .HasForeignKey(cru => cru.ChatRoomId);

            modelBuilder.Entity<ChatRoomUser>()
                .HasOne(cru => cru.User)
                .WithMany(u => u.ChatRoomUsers)
                .HasForeignKey(cru => cru.UserId);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.CourseId);

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PostId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<CommentFile>(entity =>
            {
                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.CommentFiles)
                    .HasForeignKey(d => d.CommentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
            
            modelBuilder.Entity<CommentFile>()
                .HasKey(cru => new { cru.CommentId, cru.FileId }); 

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<CourseFile>(entity =>
            {
                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseFiles)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.File)
                    .WithMany(p => p.CourseFiles)
                    .HasForeignKey(d => d.FileId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                
                entity.HasKey(cru => new { cru.CourseId, cru.FileId }); 
            });

            modelBuilder.Entity<DailyUpdate>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.DailyUpdates)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.Property(e => e.FilePath)
                    .HasMaxLength(255);

                entity.Property(e => e.FileType)
                    .HasMaxLength(50);

                entity.Property(e => e.FileName)
                    .HasMaxLength(255);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<FileAccess>(entity =>
            {
                entity.Property(e => e.AccessType)
                    .HasMaxLength(50);

                entity.HasKey(e => e.AccessId);
                
                entity.HasOne(d => d.File)
                    .WithMany(p => p.FileAccesses)
                    .HasForeignKey(d => d.IdFile)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FileAccesses)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<LikeOnCourse>(entity =>
            {
                entity.HasOne(d => d.Course)
                    .WithMany(p => p.LikesToCourses)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LikesOnCourses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<LikeOnPost>(entity =>
            {
                entity.HasOne(d => d.Post)
                    .WithMany(p => p.LikesToPosts)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LikesOnPosts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasOne(d => d.Recipient)
                    .WithMany(p => p.MessagesAsRecipient)
                    .HasForeignKey(d => d.RecipientId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.MessageAsSender)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<LikeOnCourse>(entity =>
            {
                entity.HasKey(e => e.LikeId);
            });
            
            modelBuilder.Entity<LikeOnPost>(entity =>
            {
                entity.HasKey(e => e.LikeId);
            });
            
            
            modelBuilder.Entity<PostFile>(entity =>
            {
                entity.HasKey(e => new {e.FileId, e.PostId});
            });
            
            
            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.PostTitle)
                    .HasMaxLength(255);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<PostFile>(entity =>
            {
                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostFile)
                    .HasForeignKey(d => d.FileId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostFile)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
            

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasMaxLength(255);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                
                entity.HasMany(e => e.ChatRoomUsers)
                .WithOne(cru => cru.User)
                .HasForeignKey(cru => cru.UserId);

                entity.HasMany(e => e.UsersCourses)
                    .WithOne(uc => uc.User)
                    .HasForeignKey(uc => uc.UserId);
            });
            modelBuilder.Entity<UsersCourse>(entity =>
            {
                entity.HasKey(uc => new { uc.UserId, uc.CourseId });

                entity.HasOne(uc => uc.User)
                    .WithMany(u => u.UsersCourses)
                    .HasForeignKey(uc => uc.UserId);

                entity.HasOne(uc => uc.Course)
                    .WithMany(c => c.UsersCourses)
                    .HasForeignKey(uc => uc.CourseId);

                entity.ToTable("UsersCourses");
            });

            
            

            modelBuilder.Entity<UserLanguage>(entity =>
            {
                entity.HasKey(e => new { e.IdUser, e.Language });


                entity.Property(e => e.Language)
                    .HasMaxLength(10);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLanguages)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            base.OnModelCreating(modelBuilder);
        }

    }
    
    
}
