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

                    b.Property<double>("Preco")
                        .HasColumnType("float")
                        .HasColumnName("Preco");

                    b.Property<double>("Quantidade")
                        .HasColumnType("float")
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

                    b.Property<double?>("Preco")
                        .HasColumnType("float")
                        .HasColumnName("Preco");

                    b.Property<double?>("PrecoAtual")
                        .HasColumnType("float")
                        .HasColumnName("PrecoAtual");

                    b.Property<double?>("Quantidade")
                        .HasColumnType("float")
                        .HasColumnName("Quantidade");

                    b.HasKey("Id");

                    b.HasIndex("AtivosId");

                    b.ToTable("Portifolio");
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
