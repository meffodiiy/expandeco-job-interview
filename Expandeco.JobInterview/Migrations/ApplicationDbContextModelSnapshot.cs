﻿// <auto-generated />
using System;
using Expandeco.JobInterview.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Expandeco.JobInterview.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("Expandeco.JobInterview.Data.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Angličtina"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Slovenčina"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Čeština"
                        },
                        new
                        {
                            Id = 4,
                            Title = "Nemčina"
                        });
                });

            modelBuilder.Entity("Expandeco.JobInterview.Data.Translation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AssignedToId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CreatedById")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Deadline")
                        .HasColumnType("TEXT");

                    b.Property<int>("SourceLanguageId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TargetLanguageId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TranslatedText")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AssignedToId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("SourceLanguageId");

                    b.HasIndex("TargetLanguageId");

                    b.ToTable("Translations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedById = 10,
                            SourceLanguageId = 2,
                            TargetLanguageId = 4,
                            Text = "Nobis ducimus eos sed deserunt officia sed soluta.",
                            Title = "provident aperiam fugiat"
                        },
                        new
                        {
                            Id = 2,
                            AssignedToId = 7,
                            CreatedById = 8,
                            SourceLanguageId = 2,
                            TargetLanguageId = 4,
                            Text = "Voluptatem mollitia corporis adipisci.\nTempore aut quo consectetur.",
                            Title = "cupiditate repellat eligendi"
                        },
                        new
                        {
                            Id = 3,
                            AssignedToId = 7,
                            CreatedById = 10,
                            SourceLanguageId = 2,
                            TargetLanguageId = 3,
                            Text = "Libero et neque quam perferendis.",
                            Title = "autem voluptatem hic"
                        },
                        new
                        {
                            Id = 4,
                            CreatedById = 9,
                            SourceLanguageId = 2,
                            TargetLanguageId = 3,
                            Text = "consequatur",
                            Title = "ea vel facere"
                        },
                        new
                        {
                            Id = 5,
                            AssignedToId = 4,
                            CreatedById = 10,
                            SourceLanguageId = 2,
                            TargetLanguageId = 3,
                            Text = "Est suscipit quo sint dolorem earum commodi esse.",
                            Title = "dolore quia ipsum"
                        },
                        new
                        {
                            Id = 6,
                            CreatedById = 10,
                            SourceLanguageId = 1,
                            TargetLanguageId = 4,
                            Text = "Est voluptas id.\nVoluptatem qui et rerum corporis est dolorum illum libero.\nEt et exercitationem et ad ducimus.\nQuod eum et rerum aliquid nesciunt reprehenderit dolor commodi quibusdam.",
                            Title = "autem consectetur voluptatem"
                        },
                        new
                        {
                            Id = 7,
                            CreatedById = 9,
                            SourceLanguageId = 2,
                            TargetLanguageId = 3,
                            Text = "totam",
                            Title = "corrupti voluptates aut"
                        },
                        new
                        {
                            Id = 8,
                            CreatedById = 8,
                            SourceLanguageId = 2,
                            TargetLanguageId = 3,
                            Text = "Aut nobis deleniti.",
                            Title = "quidem sapiente nihil"
                        },
                        new
                        {
                            Id = 9,
                            CreatedById = 10,
                            SourceLanguageId = 2,
                            TargetLanguageId = 4,
                            Text = "Qui blanditiis amet nemo velit.\nNon ullam repellendus ut vitae cumque consequatur corrupti vel ut.\nSimilique provident dolor impedit velit vero harum illum ut quos.\nIllum et voluptatibus et accusantium incidunt.\nMinima dolore consequatur.",
                            Title = "ea nesciunt eligendi"
                        },
                        new
                        {
                            Id = 10,
                            AssignedToId = 6,
                            CreatedById = 10,
                            SourceLanguageId = 2,
                            TargetLanguageId = 4,
                            Text = "Eos consectetur delectus unde incidunt.\nQui voluptatem a quia est amet.\nQuia voluptatibus quo error.\nIure quis laboriosam quidem minima.\nDicta tempore ut cum molestiae voluptate et.",
                            Title = "aliquam debitis culpa"
                        });
                });

            modelBuilder.Entity("Expandeco.JobInterview.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Natália Raková",
                            TypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Jana Slotová",
                            TypeId = 2
                        },
                        new
                        {
                            Id = 3,
                            Name = "Arnold Tatar",
                            TypeId = 2
                        },
                        new
                        {
                            Id = 4,
                            Name = "Zdenka Pašková",
                            TypeId = 2
                        },
                        new
                        {
                            Id = 5,
                            Name = "Karol Madej",
                            TypeId = 2
                        },
                        new
                        {
                            Id = 6,
                            Name = "Silvia Dvončová",
                            TypeId = 2
                        },
                        new
                        {
                            Id = 7,
                            Name = "Valéria Maslová",
                            TypeId = 2
                        },
                        new
                        {
                            Id = 8,
                            Name = "Žigmund Kostrec",
                            TypeId = 3
                        },
                        new
                        {
                            Id = 9,
                            Name = "Ela Krajčová",
                            TypeId = 3
                        },
                        new
                        {
                            Id = 10,
                            Name = "Teodor Mináč",
                            TypeId = 3
                        });
                });

            modelBuilder.Entity("Expandeco.JobInterview.Data.UserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("UserTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Manažér"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Prekladateľ"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Klient"
                        });
                });

            modelBuilder.Entity("Expandeco.JobInterview.Data.Translation", b =>
                {
                    b.HasOne("Expandeco.JobInterview.Data.User", "AssignedTo")
                        .WithMany()
                        .HasForeignKey("AssignedToId");

                    b.HasOne("Expandeco.JobInterview.Data.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Expandeco.JobInterview.Data.Language", "SourceLanguage")
                        .WithMany()
                        .HasForeignKey("SourceLanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Expandeco.JobInterview.Data.Language", "TargetLanguage")
                        .WithMany()
                        .HasForeignKey("TargetLanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssignedTo");

                    b.Navigation("CreatedBy");

                    b.Navigation("SourceLanguage");

                    b.Navigation("TargetLanguage");
                });

            modelBuilder.Entity("Expandeco.JobInterview.Data.User", b =>
                {
                    b.HasOne("Expandeco.JobInterview.Data.UserType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });
#pragma warning restore 612, 618
        }
    }
}
