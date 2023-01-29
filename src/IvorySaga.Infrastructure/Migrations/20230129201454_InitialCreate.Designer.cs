﻿// <auto-generated />
using System;
using IvorySaga.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IvorySaga.Infrastructure.Migrations
{
    [DbContext(typeof(IvorySagaDbContext))]
    [Migration("20230129201454_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("IvorySaga.Domain.Saga.Saga", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("SagaId");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("saga", (string)null);
                });

            modelBuilder.Entity("IvorySaga.Domain.Saga.Saga", b =>
                {
                    b.OwnsMany("IvorySaga.Domain.Saga.Entities.Chapter", "Chapters", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid")
                                .HasColumnName("ChapterId");

                            b1.Property<Guid>("SagaId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Content")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<DateTime>("CreatedAt")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<DateTime>("UpdatedAt")
                                .HasColumnType("timestamp with time zone");

                            b1.HasKey("Id", "SagaId");

                            b1.HasIndex("SagaId");

                            b1.ToTable("chapter", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("SagaId");
                        });

                    b.OwnsOne("IvorySaga.Domain.Saga.ValueObjects.Author", "Author", b1 =>
                        {
                            b1.Property<Guid>("SagaId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("SagaId");

                            b1.ToTable("saga");

                            b1.WithOwner()
                                .HasForeignKey("SagaId");
                        });

                    b.Navigation("Author")
                        .IsRequired();

                    b.Navigation("Chapters");
                });
#pragma warning restore 612, 618
        }
    }
}