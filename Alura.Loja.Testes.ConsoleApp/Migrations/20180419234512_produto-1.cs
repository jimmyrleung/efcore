using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alura.Loja.Testes.ConsoleApp.Migrations
{
    public partial class produto1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Preco",
                table: "Produtos",
                newName: "PrecoUnitario");

            migrationBuilder.AddColumn<string>(
                name: "UnidadeMedida",
                table: "Produtos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnidadeMedida",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "PrecoUnitario",
                table: "Produtos",
                newName: "Preco");
        }
    }
}
