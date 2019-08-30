using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjetoBenner.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bairro = table.Column<string>(nullable: true),
                    CEP = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    Rua = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(maxLength: 12, nullable: true),
                    UF = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entradas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    ValorEntrada = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entradas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Galeria",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Imagem = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galeria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HorarioAbertura = table.Column<DateTime>(nullable: false),
                    HorarioFechamento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(maxLength: 20, nullable: true),
                    Preco = table.Column<double>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Saidas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    ValorSaida = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saidas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tempo = table.Column<int>(nullable: false),
                    Tipo = table.Column<string>(nullable: true),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agenda",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClienteId = table.Column<int>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    Horario = table.Column<DateTime>(nullable: false),
                    ServicoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agenda_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agenda_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AgendaId = table.Column<int>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    CEP = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    Rua = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(maxLength: 12, nullable: true),
                    UF = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Agenda_AgendaId",
                        column: x => x.AgendaId,
                        principalTable: "Agenda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_ClienteId",
                table: "Agenda",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_ServicoId",
                table: "Agenda",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_AgendaId",
                table: "Funcionarios",
                column: "AgendaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entradas");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Galeria");

            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Saidas");

            migrationBuilder.DropTable(
                name: "Agenda");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Servicos");
        }
    }
}
