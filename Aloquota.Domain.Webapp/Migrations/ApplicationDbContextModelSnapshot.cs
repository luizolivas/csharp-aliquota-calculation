﻿// <auto-generated />
using System;
using Aliquota.Domain.Webapp.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Aliquota.Domain.Webapp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Aliquota.Domain.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Aliquota.Domain.Models.HistoricoMovimentacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataOperacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProdutoFinanceiroId")
                        .HasColumnType("int");

                    b.Property<int>("TipoOperacao")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoFinanceiroId");

                    b.ToTable("HistoricoMovimentacao");
                });

            modelBuilder.Entity("Aliquota.Domain.Models.ProdutoFinanceiro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataAplicacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Valor")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("ProdutoFinanceiro");
                });

            modelBuilder.Entity("Aliquota.Domain.Models.HistoricoMovimentacao", b =>
                {
                    b.HasOne("Aliquota.Domain.Models.ProdutoFinanceiro", "ProdutoFinanceiro")
                        .WithMany("HistoricoMovimentacoes")
                        .HasForeignKey("ProdutoFinanceiroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProdutoFinanceiro");
                });

            modelBuilder.Entity("Aliquota.Domain.Models.ProdutoFinanceiro", b =>
                {
                    b.Navigation("HistoricoMovimentacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
