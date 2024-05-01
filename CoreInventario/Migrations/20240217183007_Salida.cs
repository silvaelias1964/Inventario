using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreInventario.Migrations
{
    /// <inheritdoc />
    public partial class Salida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrvId",
                table: "Entrada",
                newName: "PrdId");

            migrationBuilder.CreateTable(
                name: "Salida",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrdId = table.Column<int>(type: "int", nullable: false),
                    SalPrecioUnidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalStock = table.Column<int>(type: "int", nullable: false),
                    SalDetalles = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SalFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalEstatus = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualizadoPor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salida", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Salida_Id",
                table: "Salida",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Salida");

            migrationBuilder.RenameColumn(
                name: "PrdId",
                table: "Entrada",
                newName: "PrvId");
        }
    }
}
