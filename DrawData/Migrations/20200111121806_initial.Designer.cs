﻿// <auto-generated />
using DrawData.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DrawData.Migrations
{
    [DbContext(typeof(MasterContext))]
    [Migration("20200111121806_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("DrawData.Models.UserDepartmanModel", b =>
                {
                    b.Property<int>("UserDepartmanId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserDepartmanName");

                    b.HasKey("UserDepartmanId");

                    b.ToTable("UserDepartman");
                });

            modelBuilder.Entity("DrawData.Models.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<int>("UserDepartmanId");

                    b.Property<string>("UserName");

                    b.HasKey("UserId");

                    b.HasIndex("UserDepartmanId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("DrawData.Models.UserModel", b =>
                {
                    b.HasOne("DrawData.Models.UserDepartmanModel", "UserDepartman")
                        .WithMany("User")
                        .HasForeignKey("UserDepartmanId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
