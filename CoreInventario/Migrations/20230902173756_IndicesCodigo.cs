using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreInventario.Migrations
{
    /// <inheritdoc />
    public partial class IndicesCodigo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_PrvCodigo",
                table: "Proveedor",
                column: "PrvCodigo",
                unique: true,
                filter: "[PrvCodigo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_PrdCodigo",
                table: "Producto",
                column: "PrdCodigo",
                unique: true,
                filter: "[PrdCodigo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_CliCodigo",
                table: "Cliente",
                column: "CliCodigo",
                unique: true,
                filter: "[CliCodigo] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Proveedor_PrvCodigo",
                table: "Proveedor");

            migrationBuilder.DropIndex(
                name: "IX_Producto_PrdCodigo",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_CliCodigo",
                table: "Cliente");
        }
    }
}
