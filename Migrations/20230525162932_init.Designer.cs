﻿// <auto-generated />
using System;
using MailServiceAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MailServiceAPI.Migrations
{
    [DbContext(typeof(MailDBContext))]
    [Migration("20230525162932_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MailServiceAPI.Data.Message", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("RecieverId")
                        .HasColumnType("bigint");

                    b.Property<long>("SenderId")
                        .HasColumnType("bigint");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("RecieverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("MailServiceAPI.Data.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MailServiceAPI.Data.Message", b =>
                {
                    b.HasOne("MailServiceAPI.Data.User", "Reciever")
                        .WithMany("RecievedMessages")
                        .HasForeignKey("RecieverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MailServiceAPI.Data.User", "Sender")
                        .WithMany("SentMessages")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reciever");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("MailServiceAPI.Data.User", b =>
                {
                    b.Navigation("RecievedMessages");

                    b.Navigation("SentMessages");
                });
#pragma warning restore 612, 618
        }
    }
}
