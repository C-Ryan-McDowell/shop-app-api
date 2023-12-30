﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ShopApp.Models
{
    public partial class ShopAppContext : DbContext
    {
        public ShopAppContext()
        {
        }

        public ShopAppContext(DbContextOptions<ShopAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MovieProduct> MovieProducts { get; set; }
        public virtual DbSet<MusicProduct> MusicProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieProduct>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ImageUrl).IsUnicode(false);

                entity.Property(e => e.MediaType)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MovieId).ValueGeneratedOnAdd();

                entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ReleaseDate).HasColumnType("date");

                entity.Property(e => e.Title)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<MusicProduct>(entity =>
            {
                entity.HasKey(e => e.AlbumId);

                entity.Property(e => e.Album)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Artist)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ImageUrl).IsUnicode(false);

                entity.Property(e => e.MediaType)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ReleaseDate).HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}