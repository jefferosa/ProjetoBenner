using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoBenner.Migrations
{
    public partial class _9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Agenda_AgendaId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_AgendaId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "AgendaId",
                table: "Clientes");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Agenda",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_ClienteId",
                table: "Agenda",
                column: "ClienteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_Clientes_ClienteId",
                table: "Agenda",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_Clientes_ClienteId",
                table: "Agenda");

            migrationBuilder.DropIndex(
                name: "IX_Agenda_ClienteId",
                table: "Agenda");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Agenda");

            migrationBuilder.AddColumn<int>(
                name: "AgendaId",
                table: "Clientes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_AgendaId",
                table: "Clientes",
                column: "AgendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Agenda_AgendaId",
                table: "Clientes",
                column: "AgendaId",
                principalTable: "Agenda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
