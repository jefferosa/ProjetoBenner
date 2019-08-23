using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ProjetoBenner.DAO;

namespace ProjetoBenner.Migrations
{
    [DbContext(typeof(SalaoContext))]
    [Migration("20190816185900_5")]
    partial class _5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjetoBenner.Models.Agenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data");

                    b.Property<DateTime>("Horario");

                    b.Property<int?>("ServicoId");

                    b.HasKey("Id");

                    b.HasIndex("ServicoId");

                    b.ToTable("Agenda");
                });

            modelBuilder.Entity("ProjetoBenner.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AgendaId");

                    b.Property<string>("Bairro");

                    b.Property<int>("CEP");

                    b.Property<string>("CPF")
                        .HasMaxLength(11);

                    b.Property<string>("Cidade");

                    b.Property<string>("Email");

                    b.Property<string>("Login");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int>("Numero");

                    b.Property<string>("Rua");

                    b.Property<string>("Senha");

                    b.Property<string>("Telefone")
                        .HasMaxLength(12);

                    b.Property<string>("UF");

                    b.HasKey("Id");

                    b.HasIndex("AgendaId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ProjetoBenner.Models.Entrada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data");

                    b.Property<string>("Descricao");

                    b.Property<double>("ValorEntrada");

                    b.HasKey("Id");

                    b.ToTable("Entradas");
                });

            modelBuilder.Entity("ProjetoBenner.Models.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AgendaId");

                    b.Property<string>("Bairro");

                    b.Property<int>("CEP");

                    b.Property<string>("CPF")
                        .HasMaxLength(11);

                    b.Property<string>("Cidade");

                    b.Property<string>("Email");

                    b.Property<string>("Login");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int>("Numero");

                    b.Property<string>("Rua");

                    b.Property<string>("Senha");

                    b.Property<string>("Telefone")
                        .HasMaxLength(12);

                    b.Property<string>("UF");

                    b.HasKey("Id");

                    b.HasIndex("AgendaId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("ProjetoBenner.Models.Galeria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Imagem");

                    b.HasKey("Id");

                    b.ToTable("Galeria");
                });

            modelBuilder.Entity("ProjetoBenner.Models.HorarioAtendimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("HorarioAbertura");

                    b.Property<string>("HorarioFechamento");

                    b.HasKey("Id");

                    b.ToTable("Horarios");
                });

            modelBuilder.Entity("ProjetoBenner.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<string>("Nome")
                        .HasMaxLength(20);

                    b.Property<double>("Preco");

                    b.Property<int>("Quantidade");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("ProjetoBenner.Models.Saida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data");

                    b.Property<string>("Descricao");

                    b.Property<double>("ValorSaida");

                    b.HasKey("Id");

                    b.ToTable("Saidas");
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

            modelBuilder.Entity("ProjetoBenner.Models.Agenda", b =>
                {
                    b.HasOne("ProjetoBenner.Models.Servico", "Servico")
                        .WithMany()
                        .HasForeignKey("ServicoId");
                });

            modelBuilder.Entity("ProjetoBenner.Models.Cliente", b =>
                {
                    b.HasOne("ProjetoBenner.Models.Agenda", "Agenda")
                        .WithMany()
                        .HasForeignKey("AgendaId");
                });

            modelBuilder.Entity("ProjetoBenner.Models.Funcionario", b =>
                {
                    b.HasOne("ProjetoBenner.Models.Agenda", "Agenda")
                        .WithMany()
                        .HasForeignKey("AgendaId");
                });
        }
    }
}
