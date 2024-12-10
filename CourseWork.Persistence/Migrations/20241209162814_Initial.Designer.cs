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
    [Migration("20241209162814_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ChatRoomUser", b =>
                {
                    b.Property<int>("ChatRoomsChatRoomId")
                        .HasColumnType("int");

                    b.Property<int>("UsersUserId")
                        .HasColumnType("int");

                    b.HasKey("ChatRoomsChatRoomId", "UsersUserId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("ChatRoomUser");
                });

            modelBuilder.Entity("CourseUser", b =>
                {
                    b.Property<int>("EnrolledCoursesCourseId")
                        .HasColumnType("int");

                    b.Property<int>("EnrolledUsersUserId")
                        .HasColumnType("int");

                    b.HasKey("EnrolledCoursesCourseId", "EnrolledUsersUserId");

                    b.HasIndex("EnrolledUsersUserId");

                    b.ToTable("CourseUser");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Развивающие"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Познавательные"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "Обучающие"
                        });
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.ChatRoom", b =>
                {
                    b.Property<int>("ChatRoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChatRoomId"), 1L, 1);

                    b.Property<int>("ChatRoomType")
                        .HasColumnType("int");

                    b.HasKey("ChatRoomId");

                    b.ToTable("ChatRooms");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.CommentMedia", b =>
                {
                    b.Property<int>("MediaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MediaId"), 1L, 1);

                    b.Property<int>("CommentId")
                        .HasColumnType("int");

                    b.Property<string>("MediaPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MediaType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MediaId");

                    b.HasIndex("CommentId");

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

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            CategoryId = 2,
                            DateCreated = new DateTime(2024, 12, 9, 16, 28, 14, 32, DateTimeKind.Utc).AddTicks(9250),
                            Description = "string",
                            Name = "Тест"
                        },
                        new
                        {
                            CourseId = 2,
                            CategoryId = 2,
                            DateCreated = new DateTime(2024, 12, 9, 16, 28, 14, 32, DateTimeKind.Utc).AddTicks(9255),
                            Description = "string",
                            Name = "Тест"
                        },
                        new
                        {
                            CourseId = 3,
                            CategoryId = 1,
                            DateCreated = new DateTime(2024, 12, 9, 16, 28, 14, 32, DateTimeKind.Utc).AddTicks(9256),
                            Description = "string",
                            Name = "Тест"
                        });
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.CourseMedia", b =>
                {
                    b.Property<int>("MediaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MediaId"), 1L, 1);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("FileId")
                        .HasColumnType("int");

                    b.HasKey("MediaId");

                    b.HasIndex("CourseId");

                    b.HasIndex("FileId");

                    b.ToTable("CourseMedia");
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdUser")
                        .HasColumnType("int");

                    b.Property<int?>("IdUserNavigationUserId")
                        .HasColumnType("int");

                    b.HasKey("FileId");

                    b.HasIndex("IdUserNavigationUserId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.FileAccess", b =>
                {
                    b.Property<int>("FileId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("AccessType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FileId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("FileAccesses");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.LikesToCourse", b =>
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

            modelBuilder.Entity("CourseWork.Domain.Entities.LikesToPost", b =>
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

                    b.Property<int?>("ChatRoomId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("MessageId");

                    b.HasIndex("ChatRoomId");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostId"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.PostMedia", b =>
                {
                    b.Property<int>("MediaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MediaId"), 1L, 1);

                    b.Property<int>("FileId")
                        .HasColumnType("int");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.HasKey("MediaId");

                    b.HasIndex("FileId");

                    b.HasIndex("PostId");

                    b.ToTable("PostMedia");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.Profile", b =>
                {
                    b.Property<int>("ProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProfileId"), 1L, 1);

                    b.Property<string>("Biography")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ProfileId");

                    b.HasIndex("UserId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.UserLanguage", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "Language");

                    b.ToTable("UserLanguages");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.UsersCourse", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CourseId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersCourses");
                });

            modelBuilder.Entity("Domain.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"), 1L, 1);

                    b.Property<string>("CommentDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCommented")
                        .HasColumnType("datetime2");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("CourseId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("ChatRoomUser", b =>
                {
                    b.HasOne("CourseWork.Domain.Entities.ChatRoom", null)
                        .WithMany()
                        .HasForeignKey("ChatRoomsChatRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseWork.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CourseUser", b =>
                {
                    b.HasOne("CourseWork.Domain.Entities.Course", null)
                        .WithMany()
                        .HasForeignKey("EnrolledCoursesCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseWork.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("EnrolledUsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.CommentMedia", b =>
                {
                    b.HasOne("Domain.Models.Comment", "IdCommentNavigation")
                        .WithMany("CommentMedia")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdCommentNavigation");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.Course", b =>
                {
                    b.HasOne("CourseWork.Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.CourseMedia", b =>
                {
                    b.HasOne("CourseWork.Domain.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseWork.Domain.Entities.File", "File")
                        .WithMany("CourseMedia")
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("File");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.DailyUpdate", b =>
                {
                    b.HasOne("CourseWork.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.File", b =>
                {
                    b.HasOne("CourseWork.Domain.Entities.User", "IdUserNavigation")
                        .WithMany()
                        .HasForeignKey("IdUserNavigationUserId");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.FileAccess", b =>
                {
                    b.HasOne("CourseWork.Domain.Entities.File", "IdFileNavigation")
                        .WithMany("FileAccesses")
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseWork.Domain.Entities.User", "IdUserNavigation")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdFileNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.LikesToCourse", b =>
                {
                    b.HasOne("CourseWork.Domain.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseWork.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.LikesToPost", b =>
                {
                    b.HasOne("CourseWork.Domain.Entities.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseWork.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.Message", b =>
                {
                    b.HasOne("CourseWork.Domain.Entities.ChatRoom", null)
                        .WithMany("Messages")
                        .HasForeignKey("ChatRoomId");

                    b.HasOne("CourseWork.Domain.Entities.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.Post", b =>
                {
                    b.HasOne("CourseWork.Domain.Entities.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.PostMedia", b =>
                {
                    b.HasOne("CourseWork.Domain.Entities.File", "File")
                        .WithMany("PostMedia")
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseWork.Domain.Entities.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("File");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.Profile", b =>
                {
                    b.HasOne("CourseWork.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.User", b =>
                {
                    b.HasOne("CourseWork.Domain.Entities.Role", null)
                        .WithMany("Users")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.UserLanguage", b =>
                {
                    b.HasOne("CourseWork.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.UsersCourse", b =>
                {
                    b.HasOne("CourseWork.Domain.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseWork.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Models.Comment", b =>
                {
                    b.HasOne("CourseWork.Domain.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseWork.Domain.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseWork.Domain.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.ChatRoom", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.File", b =>
                {
                    b.Navigation("CourseMedia");

                    b.Navigation("FileAccesses");

                    b.Navigation("PostMedia");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.Post", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Messages");

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("Domain.Models.Comment", b =>
                {
                    b.Navigation("CommentMedia");
                });
#pragma warning restore 612, 618
        }
    }
}