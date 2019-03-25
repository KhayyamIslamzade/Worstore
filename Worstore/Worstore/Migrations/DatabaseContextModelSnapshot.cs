﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using Worstore.AccessLayer.Entity;

namespace Worstore.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Worstore.Entities.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime?>("DateModified");

                    b.Property<int>("FkWord");

                    b.Property<bool>("IsTestTrue");

                    b.Property<string>("Reply")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("Status");

                    b.Property<int>("TestType");

                    b.HasKey("Id");

                    b.HasIndex("FkWord");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("Worstore.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Worstore.Entities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime?>("DateModified");

                    b.Property<int>("FkLanguage");

                    b.Property<string>("FkUser")
                        .IsRequired();

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("FkLanguage");

                    b.HasIndex("FkUser");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("Worstore.Entities.Meaning", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime?>("DateModified");

                    b.Property<int>("FkWord");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("FkWord");

                    b.ToTable("Meaning");
                });

            modelBuilder.Entity("Worstore.Entities.SpokenLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("FlagUrl");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("SpokenLanguage");
                });

            modelBuilder.Entity("Worstore.Entities.Word", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime?>("DateModified");

                    b.Property<int>("FkGroup");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Pronunciation")
                        .HasMaxLength(255);

                    b.Property<int>("Status");

                    b.Property<string>("Tag")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("FkGroup");

                    b.ToTable("Word");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Worstore.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Worstore.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Worstore.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Worstore.Entities.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Worstore.Entities.Answer", b =>
                {
                    b.HasOne("Worstore.Entities.Word", "Word")
                        .WithMany("Answers")
                        .HasForeignKey("FkWord")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Worstore.Entities.Group", b =>
                {
                    b.HasOne("Worstore.Entities.SpokenLanguage", "SpokenLanguage")
                        .WithMany("Groups")
                        .HasForeignKey("FkLanguage")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Worstore.Entities.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("FkUser")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Worstore.Entities.Meaning", b =>
                {
                    b.HasOne("Worstore.Entities.Word", "Word")
                        .WithMany("Meanings")
                        .HasForeignKey("FkWord")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Worstore.Entities.Word", b =>
                {
                    b.HasOne("Worstore.Entities.Group", "Group")
                        .WithMany("Word")
                        .HasForeignKey("FkGroup")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
