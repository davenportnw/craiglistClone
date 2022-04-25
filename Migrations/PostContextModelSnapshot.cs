﻿// <auto-generated />
using System;
using Final.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Final.Migrations
{
    [DbContext(typeof(PostContext))]
    partial class PostContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.24");

            modelBuilder.Entity("Final.Models.Favorite", b =>
                {
                    b.Property<int>("FavoriteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PostID")
                        .HasColumnType("INTEGER");

                    b.HasKey("FavoriteID");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("Final.Models.Post", b =>
                {
                    b.Property<int>("PostID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("FavoriteID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(60);

                    b.HasKey("PostID");

                    b.HasIndex("FavoriteID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Final.Models.Post", b =>
                {
                    b.HasOne("Final.Models.Favorite", null)
                        .WithMany("FavoritePosts")
                        .HasForeignKey("FavoriteID");
                });
#pragma warning restore 612, 618
        }
    }
}
