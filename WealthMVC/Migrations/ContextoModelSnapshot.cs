﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wealth.Tools.database;

#nullable disable

namespace WealthMVC.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WealthMVC.Models.Ativos", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Id");

                    b.Property<int>("Classe")
                        .HasColumnType("int")
                        .HasColumnName("Classe");

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Codigo");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Descricao");

                    b.HasKey("Id");

                    b.ToTable("ATIVOS");
                });

            modelBuilder.Entity("WealthMVC.Models.Operacoes", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Id");

                    b.Property<string>("AtivosId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("AtivosId");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2")
                        .HasColumnName("Data");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Preco");

                    b.Property<decimal>("Quantidade")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Quantidade");

                    b.Property<int>("Tipo")
                        .HasColumnType("int")
                        .HasColumnName("Tipo");

                    b.HasKey("Id");

                    b.HasIndex("AtivosId");

                    b.ToTable("OPERACOES");
                });

            modelBuilder.Entity("WealthMVC.Models.Portifolio", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Id");

                    b.Property<string>("AtivosId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("AtivosId");

                    b.HasKey("Id");

                    b.HasIndex("AtivosId");

                    b.ToTable("PORTIFOLIO");
                });

            modelBuilder.Entity("WealthMVC.Models.Operacoes", b =>
                {
                    b.HasOne("WealthMVC.Models.Ativos", "Ativos")
                        .WithMany()
                        .HasForeignKey("AtivosId");

                    b.Navigation("Ativos");
                });

            modelBuilder.Entity("WealthMVC.Models.Portifolio", b =>
                {
                    b.HasOne("WealthMVC.Models.Ativos", "Ativos")
                        .WithMany()
                        .HasForeignKey("AtivosId");

                    b.Navigation("Ativos");
                });
#pragma warning restore 612, 618
        }
    }
}
