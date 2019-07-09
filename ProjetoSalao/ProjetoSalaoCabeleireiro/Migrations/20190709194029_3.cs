using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoBenner.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_Servicos_ServicosId",
                table: "Agenda");

            migrationBuilder.RenameColumn(
                name: "ServicosId",
                table: "Agenda",
                newName: "ServicoId");

            migrationBuilder.RenameIndex(
                name: "IX_Agenda_ServicosId",
                table: "Agenda",
                newName: "IX_Agenda_ServicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_Servicos_ServicoId",
                table: "Agenda",
                column: "ServicoId",
                principalTable: "Servicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_Servicos_ServicoId",
                table: "Agenda");

            migrationBuilder.RenameColumn(
                name: "ServicoId",
                table: "Agenda",
                newName: "ServicosId");

            migrationBuilder.RenameIndex(
                name: "IX_Agenda_ServicoId",
                table: "Agenda",
                newName: "IX_Agenda_ServicosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_Servicos_ServicosId",
                table: "Agenda",
                column: "ServicosId",
                principalTable: "Servicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
