﻿// <auto-generated />
using System;
using MediaContentSystem.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MediaContentSystem.Persistence.Migrations.Migrations
{
    [DbContext(typeof(MediaContentSystemContext))]
    [Migration("20240107081637_AddContentTableAndLikeTableButRemoveThemeTable")]
    partial class AddContentTableAndLikeTableButRemoveThemeTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MediaContentSystem.Domain.Aggregates.CommentAggregates.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AnsweredCommentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnsweredCommentId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments", (string)null);
                });

            modelBuilder.Entity("MediaContentSystem.Domain.Aggregates.ContentAggregates.Content", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("LinkReference")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Contents", (string)null);
                });

            modelBuilder.Entity("MediaContentSystem.Domain.Aggregates.LikeAggregates.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CommentId")
                        .HasColumnType("int");

                    b.Property<int?>("ContentId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("ContentId");

                    b.HasIndex("UserId");

                    b.ToTable("Likes", (string)null);
                });

            modelBuilder.Entity("MediaContentSystem.Domain.Aggregates.UserAggregate.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ContentType")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("UserContents", b =>
                {
                    b.Property<int>("ContentsId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("ContentsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("UserContents");
                });

            modelBuilder.Entity("MediaContentSystem.Domain.Aggregates.CommentAggregates.Comment", b =>
                {
                    b.HasOne("MediaContentSystem.Domain.Aggregates.CommentAggregates.Comment", "AnsweredComment")
                        .WithMany()
                        .HasForeignKey("AnsweredCommentId");

                    b.HasOne("MediaContentSystem.Domain.Aggregates.UserAggregate.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnsweredComment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MediaContentSystem.Domain.Aggregates.LikeAggregates.Like", b =>
                {
                    b.HasOne("MediaContentSystem.Domain.Aggregates.CommentAggregates.Comment", "Comment")
                        .WithMany("Likes")
                        .HasForeignKey("CommentId");

                    b.HasOne("MediaContentSystem.Domain.Aggregates.ContentAggregates.Content", "Content")
                        .WithMany("Likes")
                        .HasForeignKey("ContentId");

                    b.HasOne("MediaContentSystem.Domain.Aggregates.UserAggregate.User", "User")
                        .WithMany("Likes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comment");

                    b.Navigation("Content");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UserContents", b =>
                {
                    b.HasOne("MediaContentSystem.Domain.Aggregates.ContentAggregates.Content", null)
                        .WithMany()
                        .HasForeignKey("ContentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MediaContentSystem.Domain.Aggregates.UserAggregate.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MediaContentSystem.Domain.Aggregates.CommentAggregates.Comment", b =>
                {
                    b.Navigation("Likes");
                });

            modelBuilder.Entity("MediaContentSystem.Domain.Aggregates.ContentAggregates.Content", b =>
                {
                    b.Navigation("Likes");
                });

            modelBuilder.Entity("MediaContentSystem.Domain.Aggregates.UserAggregate.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Likes");
                });
#pragma warning restore 612, 618
        }
    }
}
