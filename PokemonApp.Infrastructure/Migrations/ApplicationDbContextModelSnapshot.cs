﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PokemonApp.Infrastructure.Data;

#nullable disable

namespace PokemonApp.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("PokemonApp.Domain.Entities.CapturedPokemon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CaptureDt")
                        .HasColumnType("TEXT");

                    b.Property<int>("PokemonId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PokemonName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TreinadorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TreinadorId");

                    b.ToTable("CapturedPokemons");
                });

            modelBuilder.Entity("PokemonApp.Domain.Entities.Pokemon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("PokemonId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SpriteBase64")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("TreinadorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PokemonId");

                    b.HasIndex("TreinadorId");

                    b.ToTable("Pokemons");
                });

            modelBuilder.Entity("PokemonApp.Domain.Entities.PokemonEvolucao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int>("PokemonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PokemonId");

                    b.ToTable("PokemonEvolucoes");
                });

            modelBuilder.Entity("PokemonApp.Domain.Entities.Treinador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cpf")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Idade")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Treinadors");
                });

            modelBuilder.Entity("PokemonApp.Domain.Entities.CapturedPokemon", b =>
                {
                    b.HasOne("PokemonApp.Domain.Entities.Treinador", "Treinador")
                        .WithMany()
                        .HasForeignKey("TreinadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Treinador");
                });

            modelBuilder.Entity("PokemonApp.Domain.Entities.Pokemon", b =>
                {
                    b.HasOne("PokemonApp.Domain.Entities.Pokemon", null)
                        .WithMany("Evolucoes")
                        .HasForeignKey("PokemonId");

                    b.HasOne("PokemonApp.Domain.Entities.Treinador", null)
                        .WithMany("CapturedPokemons")
                        .HasForeignKey("TreinadorId");
                });

            modelBuilder.Entity("PokemonApp.Domain.Entities.PokemonEvolucao", b =>
                {
                    b.HasOne("PokemonApp.Domain.Entities.Pokemon", "Pokemon")
                        .WithMany()
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("PokemonApp.Domain.Entities.Pokemon", b =>
                {
                    b.Navigation("Evolucoes");
                });

            modelBuilder.Entity("PokemonApp.Domain.Entities.Treinador", b =>
                {
                    b.Navigation("CapturedPokemons");
                });
#pragma warning restore 612, 618
        }
    }
}
