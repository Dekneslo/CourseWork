﻿// <auto-generated />
using System;
using CourseWork.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CourseWork.Persistence.Migrations
{
    [DbContext(typeof(CharityDBContext))]
    [Migration("20241207144955_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ChatRoomUser", b =>
                {
                    b.Property<int>("ChatRoomsChatRoomId")
                        .HasColumnType("integer");

                    b.Property<int>("UsersUserId")
                        .HasColumnType("integer");

                    b.HasKey("ChatRoomsChatRoomId", "UsersUserId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("ChatRoomUser");
                });

            modelBuilder.Entity("CourseUser", b =>
                {
                    b.Property<int>("EnrolledCoursesCourseId")
                        .HasColumnType("integer");

                    b.Property<int>("EnrolledUsersUserId")
                        .HasColumnType("integer");

                    b.HasKey("EnrolledCoursesCourseId", "EnrolledUsersUserId");

                    b.HasIndex("EnrolledUsersUserId");

                    b.ToTable("CourseUser");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

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
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ChatRoomId"));

                    b.Property<int>("ChatRoomType")
                        .HasColumnType("integer");

                    b.HasKey("ChatRoomId");

                    b.ToTable("ChatRooms");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CourseId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CourseId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            CategoryId = 2,
                            DateCreated = new DateTime(2024, 12, 7, 14, 49, 54, 973, DateTimeKind.Utc).AddTicks(8474),
                            Description = "string",
                            Name = "Тест"
                        },
                        new
                        {
                            CourseId = 2,
                            CategoryId = 2,
                            DateCreated = new DateTime(2024, 12, 7, 14, 49, 54, 973, DateTimeKind.Utc).AddTicks(8481),
                            Description = "string",
                            Name = "Тест"
                        },
                        new
                        {
                            CourseId = 3,
                            CategoryId = 1,
                            DateCreated = new DateTime(2024, 12, 7, 14, 49, 54, 973, DateTimeKind.Utc).AddTicks(8483),
                            Description = "string",
                            Name = "Тест"
                        });
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MessageId"));

                    b.Property<int?>("ChatRoomId")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("SentDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("MessageId");

                    b.HasIndex("ChatRoomId");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PostId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("Biography")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");
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

            modelBuilder.Entity("CourseWork.Domain.Entities.Course", b =>
                {
                    b.HasOne("CourseWork.Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
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
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.ChatRoom", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("CourseWork.Domain.Entities.User", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}