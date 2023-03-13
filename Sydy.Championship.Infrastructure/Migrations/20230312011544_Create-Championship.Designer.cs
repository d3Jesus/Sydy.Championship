﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sydy.Championship.Infrastructure.Data;

#nullable disable

namespace Sydy.Championship.Infrastructure.Migrations
{
    [DbContext(typeof(ChampionshipDbContext))]
    [Migration("20230312011544_Create-Championship")]
    partial class CreateChampionship
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Sydy.Championship.CoreBusiness.Entities.ChampionshipModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Champion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ThirdPlace")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Vice")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Championship", (string)null);
                });

            modelBuilder.Entity("Sydy.Championship.CoreBusiness.Entities.MatchModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ChampionshipId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("FirstTeamGoals")
                        .HasColumnType("int");

                    b.Property<int>("FirstTeamId")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<int>("SecondTeamGoals")
                        .HasColumnType("int");

                    b.Property<int>("SecondTeamId")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChampionshipId");

                    b.HasIndex("FirstTeamId");

                    b.HasIndex("SecondTeamId");

                    b.ToTable("Match", (string)null);
                });

            modelBuilder.Entity("Sydy.Championship.CoreBusiness.Entities.TeamModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Team", (string)null);
                });

            modelBuilder.Entity("Sydy.Championship.CoreBusiness.Entities.MatchModel", b =>
                {
                    b.HasOne("Sydy.Championship.CoreBusiness.Entities.ChampionshipModel", "Championship")
                        .WithMany("Matches")
                        .HasForeignKey("ChampionshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sydy.Championship.CoreBusiness.Entities.TeamModel", "FirstTeam")
                        .WithMany()
                        .HasForeignKey("FirstTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sydy.Championship.CoreBusiness.Entities.TeamModel", "SecondTeam")
                        .WithMany()
                        .HasForeignKey("SecondTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Championship");

                    b.Navigation("FirstTeam");

                    b.Navigation("SecondTeam");
                });

            modelBuilder.Entity("Sydy.Championship.CoreBusiness.Entities.ChampionshipModel", b =>
                {
                    b.Navigation("Matches");
                });
#pragma warning restore 612, 618
        }
    }
}