﻿//using System;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Infrastructure;
//using Microsoft.EntityFrameworkCore.Metadata;
//using Microsoft.EntityFrameworkCore.Migrations;
//using ProjetoBenner.DAL;

//namespace ProjetoBenner.Migrations
//{
//    [DbContext(typeof(SalaoContext))]
//    [Migration("20190618185746_Inicial")]
//    partial class Inicial
//    {
//        protected override void BuildTargetModel(ModelBuilder modelBuilder)
//        {
//            modelBuilder
//                .HasAnnotation("ProductVersion", "1.1.2")
//                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//            modelBuilder.Entity("ProjetoBenner.Cadastro", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd();

//                    b.Property<int>("CPF");

//                    b.Property<int?>("EnderecosId");

//                    b.Property<string>("Nome");

//                    b.Property<int>("Telefone");

//                    b.HasKey("Id");

//                    b.HasIndex("EnderecosId");

//                    b.ToTable("Cadastros");
//                });

//            modelBuilder.Entity("ProjetoBenner.Endereco", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd();

//                    b.Property<string>("Bairro");

//                    b.Property<string>("Cidade");

//                    b.Property<int>("Numero");

//                    b.Property<string>("Rua");

//                    b.HasKey("Id");

//                    b.ToTable("Endereco");
//                });

//            modelBuilder.Entity("ProjetoBenner.Models.Agenda", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd();

//                    b.Property<DateTime>("Data");

//                    b.Property<DateTime>("Horario");

//                    b.HasKey("Id");

//                    b.ToTable("Agenda");
//                });

//            modelBuilder.Entity("ProjetoBenner.Models.Servico", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd();

//                    b.Property<DateTime>("Data");

//                    b.Property<string>("Descricao");

//                    b.Property<DateTime>("HoraInicio");

//                    b.Property<DateTime>("HoraTermino");

//                    b.HasKey("Id");

//                    b.ToTable("Servicos");
//                });

//            modelBuilder.Entity("ProjetoBenner.Cadastro", b =>
//                {
//                    b.HasOne("ProjetoBenner.Endereco", "Enderecos")
//                        .WithMany()
//                        .HasForeignKey("EnderecosId");
//                });
//        }
//    }
//}
