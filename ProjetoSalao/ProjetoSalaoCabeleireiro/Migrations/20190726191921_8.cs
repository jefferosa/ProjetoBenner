using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoBenner.Migrations
{
    public partial class _8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Enderecos_EnderecoIdId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Enderecos_EnderecoIdId",
                table: "Funcionarios");

            migrationBuilder.RenameColumn(
                name: "EnderecoIdId",
                table: "Funcionarios",
                newName: "EnderecoId");

            migrationBuilder.RenameIndex(
                name: "IX_Funcionarios_EnderecoIdId",
                table: "Funcionarios",
                newName: "IX_Funcionarios_EnderecoId");

            migrationBuilder.RenameColumn(
                name: "EnderecoIdId",
                table: "Clientes",
                newName: "EnderecoId");

            migrationBuilder.RenameIndex(
                name: "IX_Clientes_EnderecoIdId",
                table: "Clientes",
                newName: "IX_Clientes_EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Enderecos_EnderecoId",
                table: "Clientes",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Enderecos_EnderecoId",
                table: "Funcionarios",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Enderecos_EnderecoId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Enderecos_EnderecoId",
                table: "Funcionarios");

            migrationBuilder.RenameColumn(
                name: "EnderecoId",
                table: "Funcionarios",
                newName: "EnderecoIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Funcionarios_EnderecoId",
                table: "Funcionarios",
                newName: "IX_Funcionarios_EnderecoIdId");

            migrationBuilder.RenameColumn(
                name: "EnderecoId",
                table: "Clientes",
                newName: "EnderecoIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Clientes_EnderecoId",
                table: "Clientes",
                newName: "IX_Clientes_EnderecoIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Enderecos_EnderecoIdId",
                table: "Clientes",
                column: "EnderecoIdId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Enderecos_EnderecoIdId",
                table: "Funcionarios",
                column: "EnderecoIdId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
