﻿// <auto-generated />
using System;
using Backend.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(MatchPadelContext))]
    partial class MatchPadelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("DTO.GameType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("GameTypes");
                });

            modelBuilder.Entity("DTO.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("DateTimeOffset")
                        .HasColumnType("INTEGER")
                        .HasAnnotation("Relational:JsonPropertyName", "DateTimeOffSet");

                    b.Property<int?>("GameTypeRefId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Winner")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GameTypeRefId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("DTO.Result", b =>
                {
                    b.Property<int>("MatchRefId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserRefId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Score")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Team")
                        .HasColumnType("INTEGER");

                    b.HasKey("MatchRefId", "UserRefId");

                    b.HasIndex("UserRefId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("DTO.Set", b =>
                {
                    b.Property<int>("MatchRefId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeamOneScore")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeamTwoScore")
                        .HasColumnType("INTEGER");

                    b.HasKey("MatchRefId", "Number");

                    b.ToTable("Sets");
                });

            modelBuilder.Entity("DTO.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DTO.Match", b =>
                {
                    b.HasOne("DTO.GameType", "GameType")
                        .WithMany("Matches")
                        .HasForeignKey("GameTypeRefId");

                    b.Navigation("GameType");
                });

            modelBuilder.Entity("DTO.Result", b =>
                {
                    b.HasOne("DTO.Match", "Match")
                        .WithMany("Results")
                        .HasForeignKey("MatchRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DTO.User", "User")
                        .WithMany("Results")
                        .HasForeignKey("UserRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DTO.Set", b =>
                {
                    b.HasOne("DTO.Match", "MatchNavigation")
                        .WithMany("Sets")
                        .HasForeignKey("MatchRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MatchNavigation");
                });

            modelBuilder.Entity("DTO.GameType", b =>
                {
                    b.Navigation("Matches");
                });

            modelBuilder.Entity("DTO.Match", b =>
                {
                    b.Navigation("Results");

                    b.Navigation("Sets");
                });

            modelBuilder.Entity("DTO.User", b =>
                {
                    b.Navigation("Results");
                });
#pragma warning restore 612, 618
        }
    }
}
