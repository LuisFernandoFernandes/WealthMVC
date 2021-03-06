// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wealth.Tools.database;

#nullable disable

namespace WealthMVC.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20220529135923_Ativos")]
    partial class Ativos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WealthMVC.Models.Ativos", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Id");

                    b.Property<int>("Classe")
                        .HasColumnType("int")
                        .HasColumnName("Classe");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Codigo");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Descricao");

                    b.HasKey("Id");

                    b.ToTable("ATIVOS");
                });

            modelBuilder.Entity("WealthMVC.Models.Operacoes", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Id");

                    b.Property<string>("AtivosId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

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

            modelBuilder.Entity("WealthMVC.Models.Operacoes", b =>
                {
                    b.HasOne("WealthMVC.Models.Ativos", "Ativos")
                        .WithMany()
                        .HasForeignKey("AtivosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ativos");
                });
#pragma warning restore 612, 618
        }
    }
}
