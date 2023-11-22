﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoneyManager.Infra.Data.Context;

#nullable disable

namespace MoneyManager.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231122125356_AddCapitalMapping")]
    partial class AddCapitalMapping
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MoneyManager.Domain.Entities.Capital", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal?>("DespesaExtra")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DespesaFixa")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DespesaTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Investimento")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ReceitaTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("RendaExtra")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("RendaFixa")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SaldoDisponivel")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Capitais");
                });

            modelBuilder.Entity("MoneyManager.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("AtualizadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("MoneyManager.Domain.Entities.Capital", b =>
                {
                    b.HasOne("MoneyManager.Domain.Entities.Usuario", "Usuario")
                        .WithOne("Capital")
                        .HasForeignKey("MoneyManager.Domain.Entities.Capital", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("MoneyManager.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Capital")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
