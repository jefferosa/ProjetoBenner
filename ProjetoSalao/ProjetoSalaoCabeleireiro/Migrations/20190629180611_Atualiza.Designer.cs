﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ProjetoBenner.DAO;

namespace ProjetoBenner.Migrations
{
    [DbContext(typeof(SalaoContext))]
    [Migration("20190629180611_Atualiza")]
    partial class Atualiza
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjetoBenner.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro");

                    b.Property<string>("Cidade");

                    b.Property<int>("Numero");

                    b.Property<string>("Rua");

                    b.HasKey("Id");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("ProjetoBenner.Models.Agenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data");

                    b.Property<DateTime>("Horario");

                    b.Property<int?>("ServicosId");

                    b.HasKey("Id");

                    b.HasIndex("ServicosId");

                    b.ToTable("Agenda");
                });

            modelBuilder.Entity("ProjetoBenner.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<string>("Nome")
                        .HasMaxLength(20);

                    b.Property<float>("Preco");

                    b.Property<int>("Quantidade");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("ProjetoBenner.Models.Servico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Tempo");

                    b.Property<string>("Tipo");

                    b.Property<double>("Valor");

                    b.HasKey("Id");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("ProjetoBenner.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CPF");

                    b.Property<string>("Email");

                    b.Property<int?>("EnderecosId");

                    b.Property<string>("Login");

                    b.Property<string>("Nome");

                    b.Property<string>("Senha");

                    b.Property<int>("Telefone");

                    b.HasKey("Id");

                    b.HasIndex("EnderecosId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ProjetoBenner.Models.Agenda", b =>
                {
                    b.HasOne("ProjetoBenner.Models.Servico", "Servicos")
                        .WithMany()
                        .HasForeignKey("ServicosId");
                });

            modelBuilder.Entity("ProjetoBenner.Usuario", b =>
                {
                    b.HasOne("ProjetoBenner.Endereco", "Enderecos")
                        .WithMany()
                        .HasForeignKey("EnderecosId");
                });
        }
    }
}