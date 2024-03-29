﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using blazor_test.Data;

#nullable disable

namespace blazortest.Migrations
{
    [DbContext(typeof(ConnectionDbContext))]
    partial class ConnectionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("blazor_test.Models.AccessKey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("HashString")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Revoked")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AccessKeys");
                });

            modelBuilder.Entity("blazor_test.Models.Labeling", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Label")
                        .HasColumnType("int");

                    b.Property<int>("PhraseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PhraseId");

                    b.ToTable("Labelings");
                });

            modelBuilder.Entity("blazor_test.Models.Phrase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Phrases");
                });

            modelBuilder.Entity("blazor_test.Models.Labeling", b =>
                {
                    b.HasOne("blazor_test.Models.Phrase", "Phrase")
                        .WithMany("Labelings")
                        .HasForeignKey("PhraseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Phrase");
                });

            modelBuilder.Entity("blazor_test.Models.Phrase", b =>
                {
                    b.Navigation("Labelings");
                });
#pragma warning restore 612, 618
        }
    }
}
