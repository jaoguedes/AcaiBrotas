﻿// <auto-generated />
using System;
using AcaiBrotas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AcaiBrotas.Migrations
{
    [DbContext(typeof(AcaiContext))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AcaiBrotas.Models.Produto", b =>
                {
                    b.Property<Guid>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Preco")
                        .HasColumnType("int");

                    b.Property<Guid>("TipoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProdutoId");

                    b.HasIndex("TipoId");

                    b.ToTable("Produtos", (string)null);
                });

            modelBuilder.Entity("AcaiBrotas.Models.Tipo", b =>
                {
                    b.Property<Guid>("TipoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipoId");

                    b.ToTable("Tipos", (string)null);
                });

            modelBuilder.Entity("AcaiBrotas.Models.Produto", b =>
                {
                    b.HasOne("AcaiBrotas.Models.Tipo", "Tipo")
                        .WithMany("Produtos")
                        .HasForeignKey("TipoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tipo");
                });

            modelBuilder.Entity("AcaiBrotas.Models.Tipo", b =>
                {
                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
