using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreInventario.Migrations
{
    /// <inheritdoc />
    public partial class Entrada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entrada",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrvId = table.Column<int>(type: "int", nullable: false),
                    EntPrecioUnidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EntStock = table.Column<int>(type: "int", nullable: false),
                    EntDetalles = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EntFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntEstatus = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualizadoPor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrada", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_Id",
                table: "Entrada",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entrada");
        }
    }
}
