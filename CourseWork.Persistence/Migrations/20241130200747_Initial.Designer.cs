﻿// <auto-generated />
using System;
using CourseWork.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CourseWork.Persistence.Migrations
{
    [DbContext(typeof(CharityDBContext))]
    [Migration("20241130200747_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CourseWork.Domain.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idCategory");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nameCategory");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.ChatRoom", b =>
                {
                    b.Property<int>("ChatRoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChatRoomId"), 1L, 1);

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ChatRoomId");

                    b.ToTable("ChatRooms");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.ChatRoomUser", b =>
                {
                    b.Property<int>("ChatRoomId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ChatRoomId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("ChatRoomUsers");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"), 1L, 1);

                    b.Property<string>("CommentDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCommented")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("CourseId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.CommentFile", b =>
                {
                    b.Property<int>("CommentId")
                        .HasColumnType("int");

                    b.Property<int>("FileId")
                        .HasColumnType("int");

                    b.HasKey("CommentId", "FileId");

                    b.HasIndex("FileId");

                    b.ToTable("CommentMedia");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.CourseFile", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("FileId")
                        .HasColumnType("int");

                    b.HasKey("CourseId", "FileId");

                    b.HasIndex("FileId");

                    b.ToTable("CoursesFiles");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.DailyUpdate", b =>
                {
                    b.Property<int>("DailyUpdateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DailyUpdateId"), 1L, 1);

                    b.Property<DateTime>("DateOfPosted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("DailyUpdateId");

                    b.HasIndex("UserId");

                    b.ToTable("DailyUpdates");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.File", b =>
                {
                    b.Property<int>("FileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FileId"), 1L, 1);

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("FileId");

                    b.HasIndex("UserId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.FileAccess", b =>
                {
                    b.Property<int>("AccessId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccessId"), 1L, 1);

                    b.Property<string>("AccessType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("IdFile")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.HasKey("AccessId");

                    b.HasIndex("IdFile");

                    b.HasIndex("IdUser");

                    b.ToTable("FileAccesses");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.LikeOnCourse", b =>
                {
                    b.Property<int>("LikeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LikeId"), 1L, 1);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LikeId");

                    b.HasIndex("CourseId");

                    b.HasIndex("UserId");

                    b.ToTable("LikesToCourses");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.LikeOnPost", b =>
                {
                    b.Property<int>("LikeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LikeId"), 1L, 1);

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LikeId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("LikesToPosts");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageId"), 1L, 1);

                    b.Property<string>("MessageText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RecipientId")
                        .HasColumnType("int");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SendingDatetime")
                        .HasColumnType("datetime2");

                    b.HasKey("MessageId");

                    b.HasIndex("RecipientId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostId"), 1L, 1);

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("datetime2");

                    b.Property<string>("PostContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostTitle")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.PostFile", b =>
                {
                    b.Property<int>("FileId")
                        .HasColumnType("int");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.HasKey("FileId", "PostId");

                    b.HasIndex("PostId");

                    b.ToTable("PostsFiles");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 1L, 1);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Biography")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.UserLanguage", b =>
                {
                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<string>("Language")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("IdUser", "Language");

                    b.ToTable("UserLanguages");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.UsersCourse", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("UsersCourses", (string)null);
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.ChatRoomUser", b =>
                {
                    b.HasOne("CourseWork.Domain.Entities.ChatRoom", "ChatRoom")
                        .WithMany("ChatRoomUsers")
                        .HasForeignKey("ChatRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseWork.Domain.Entities.User", "User")
                        .WithMany("ChatRoomUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChatRoom");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.Comment", b =>
                {
                    b.HasOne("CourseWork.Domain.Entities.Course", "Course")
                        .WithMany("Comments")
                        .HasForeignKey("CourseId");

                    b.HasOne("CourseWork.Domain.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId");

                    b.HasOne("CourseWork.Domain.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.CommentFile", b =>
                {
                    b.HasOne("CourseWork.Domain.Entities.Comment", "Comment")
                        .WithMany("CommentFiles")
                        .HasForeignKey("CommentId")
                        .IsRequired();

                    b.HasOne("CourseWork.Domain.Entities.File", "File")
                        .WithMany()
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comment");

                    b.Navigation("File");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.Course", b =>
                {
                    b.HasOne("CourseWork.Domain.Entities.Category", "Category")
                        .WithMany("Courses")
                        .HasForeignKey("CategoryId")
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.CourseFile", b =>
                {
                    b.HasOne("CourseWork.Domain.Entities.Course", "Course")
                        .WithMany("CourseFiles")
                        .HasForeignKey("CourseId")
                        .IsRequired();

                    b.HasOne("CourseWork.Domain.Entities.File", "File")
                        .WithMany("CourseFiles")
                        .HasForeignKey("FileId")
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("File");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.DailyUpdate", b =>
                {
                    b.HasOne("CourseWork.Domain.Entities.User", "User")
                        .WithMany("DailyUpdates")
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.File", b =>
                {
                    b.HasOne("CourseWork.Domain.Entities.User", "User")
                        .WithMany("Files")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.FileAccess", b =>
                {
                    b.HasOne("CourseWork.Domain.Entities.File", "File")
                        .WithMany("FileAccesses")
                        .HasForeignKey("IdFile")
                        .IsRequired();

                    b.HasOne("CourseWork.Domain.Entities.User", "User")
                        .WithMany("FileAccesses")
                        .HasForeignKey("IdUser")
                        .IsRequired();

                    b.Navigation("File");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.LikeOnCourse", b =>
                {
                    b.HasOne("CourseWork.Domain.Entities.Course", "Course")
                        .WithMany("LikesToCourses")
                        .HasForeignKey("CourseId")
                        .IsRequired();

                    b.HasOne("CourseWork.Domain.Entities.User", "User")
                        .WithMany("LikesOnCourses")
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.LikeOnPost", b =>
                {
                    b.HasOne("CourseWork.Domain.Entities.Post", "Post")
                        .WithMany("LikesToPosts")
                        .HasForeignKey("PostId")
                        .IsRequired();

                    b.HasOne("CourseWork.Domain.Entities.User", "User")
                        .WithMany("LikesOnPosts")
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.Message", b =>
                {
                    b.HasOne("CourseWork.Domain.Entities.User", "Recipient")
                        .WithMany("MessagesAsRecipient")
                        .HasForeignKey("RecipientId")
                        .IsRequired();

                    b.HasOne("CourseWork.Domain.Entities.User", "Sender")
                        .WithMany("MessageAsSender")
                        .HasForeignKey("SenderId")
                        .IsRequired();

                    b.Navigation("Recipient");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.Post", b =>
                {
                    b.HasOne("CourseWork.Domain.Entities.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.PostFile", b =>
                {
                    b.HasOne("CourseWork.Domain.Entities.File", "File")
                        .WithMany("PostMedia")
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseWork.Domain.Entities.Post", "Post")
                        .WithMany("PostFile")
                        .HasForeignKey("PostId")
                        .IsRequired();

                    b.Navigation("File");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.User", b =>
                {
                    b.HasOne("CourseWork.Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.UserLanguage", b =>
                {
                    b.HasOne("CourseWork.Domain.Entities.User", "User")
                        .WithMany("UserLanguages")
                        .HasForeignKey("IdUser")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.UsersCourse", b =>
                {
                    b.HasOne("CourseWork.Domain.Entities.Course", "Course")
                        .WithMany("UsersCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseWork.Domain.Entities.User", "User")
                        .WithMany("UsersCourses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.Category", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.ChatRoom", b =>
                {
                    b.Navigation("ChatRoomUsers");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.Comment", b =>
                {
                    b.Navigation("CommentFiles");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.Course", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("CourseFiles");

                    b.Navigation("LikesToCourses");

                    b.Navigation("UsersCourses");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.File", b =>
                {
                    b.Navigation("CourseFiles");

                    b.Navigation("FileAccesses");

                    b.Navigation("PostMedia");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("LikesToPosts");

                    b.Navigation("PostFile");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.User", b =>
                {
                    b.Navigation("ChatRoomUsers");

                    b.Navigation("Comments");

                    b.Navigation("DailyUpdates");

                    b.Navigation("FileAccesses");

                    b.Navigation("Files");

                    b.Navigation("LikesOnCourses");

                    b.Navigation("LikesOnPosts");

                    b.Navigation("MessageAsSender");

                    b.Navigation("MessagesAsRecipient");

                    b.Navigation("Posts");

                    b.Navigation("UserLanguages");

                    b.Navigation("UsersCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
