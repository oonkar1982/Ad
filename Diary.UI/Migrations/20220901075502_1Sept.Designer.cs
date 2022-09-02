﻿// <auto-generated />
using System;
using Diary.UI.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Diary.UI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220901075502_1Sept")]
    partial class _1Sept
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Diary.UI.Models.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUsers");
                });

            modelBuilder.Entity("Diary.UI.Models.CaseCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Category_Code")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CaseCategories");
                });

            modelBuilder.Entity("Diary.UI.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("StateId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Diary.UI.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country_code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Diary.UI.Models.Court", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("CourtName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Courttypeid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("StateId");

                    b.ToTable("Court");
                });

            modelBuilder.Entity("Diary.UI.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClientType")
                        .HasColumnType("int");

                    b.Property<int?>("LawsuitId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SendSMS")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("LawsuitId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Diary.UI.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Data")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Lawsuit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("Diary.UI.Models.Hearing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LawsuitsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LawsuitsId");

                    b.ToTable("Hearings");
                });

            modelBuilder.Entity("Diary.UI.Models.Lawsuit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ApplicationUserId")
                        .HasColumnType("int");

                    b.Property<int?>("CaseCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("Casetype")
                        .HasColumnType("int");

                    b.Property<int?>("CourtsId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CaseCategoryId");

                    b.HasIndex("CourtsId");

                    b.ToTable("Lawsuits");
                });

            modelBuilder.Entity("Diary.UI.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Createdby")
                        .HasColumnType("int");

                    b.Property<string>("MessageBody")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Diary.UI.Models.Messagerecipient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSend")
                        .HasColumnType("bit");

                    b.Property<int?>("LawsuitId")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LawsuitId");

                    b.ToTable("Recipient");
                });

            modelBuilder.Entity("Diary.UI.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("StateName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State_code")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("States");
                });

            modelBuilder.Entity("Diary.UI.Models.StringMap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DisplayCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dorder")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EntityCode")
                        .HasColumnType("int");

                    b.Property<string>("FiledName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StringMap");
                });

            modelBuilder.Entity("Diary.UI.Models.City", b =>
                {
                    b.HasOne("Diary.UI.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("Diary.UI.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId");

                    b.Navigation("Country");

                    b.Navigation("State");
                });

            modelBuilder.Entity("Diary.UI.Models.Court", b =>
                {
                    b.HasOne("Diary.UI.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("Diary.UI.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId");

                    b.Navigation("City");

                    b.Navigation("State");
                });

            modelBuilder.Entity("Diary.UI.Models.Customer", b =>
                {
                    b.HasOne("Diary.UI.Models.Lawsuit", "Lawsuit")
                        .WithMany("Customers")
                        .HasForeignKey("LawsuitId");

                    b.Navigation("Lawsuit");
                });

            modelBuilder.Entity("Diary.UI.Models.Hearing", b =>
                {
                    b.HasOne("Diary.UI.Models.Lawsuit", "Lawsuits")
                        .WithMany("Hearings")
                        .HasForeignKey("LawsuitsId");

                    b.Navigation("Lawsuits");
                });

            modelBuilder.Entity("Diary.UI.Models.Lawsuit", b =>
                {
                    b.HasOne("Diary.UI.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Diary.UI.Models.CaseCategory", "CaseCategory")
                        .WithMany()
                        .HasForeignKey("CaseCategoryId");

                    b.HasOne("Diary.UI.Models.Court", "Courts")
                        .WithMany()
                        .HasForeignKey("CourtsId");

                    b.Navigation("ApplicationUser");

                    b.Navigation("CaseCategory");

                    b.Navigation("Courts");
                });

            modelBuilder.Entity("Diary.UI.Models.Messagerecipient", b =>
                {
                    b.HasOne("Diary.UI.Models.Lawsuit", "Lawsuit")
                        .WithMany()
                        .HasForeignKey("LawsuitId");

                    b.Navigation("Lawsuit");
                });

            modelBuilder.Entity("Diary.UI.Models.State", b =>
                {
                    b.HasOne("Diary.UI.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Diary.UI.Models.Lawsuit", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("Hearings");
                });
#pragma warning restore 612, 618
        }
    }
}
