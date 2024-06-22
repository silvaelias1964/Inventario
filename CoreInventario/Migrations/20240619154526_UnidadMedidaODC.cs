using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreInventario.Migrations
{
    /// <inheritdoc />
    public partial class UnidadMedidaODC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OrdenCompraDetalle_UnidadMedidaId",
                table: "OrdenCompraDetalle",
                column: "UnidadMedidaId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenCompraDetalle_UnidadMedida_UnidadMedidaId",
                table: "OrdenCompraDetalle",
                column: "UnidadMedidaId",
                principalTable: "UnidadMedida",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdenCompraDetalle_UnidadMedida_UnidadMedidaId",
                table: "OrdenCompraDetalle");

            migrationBuilder.DropIndex(
                name: "IX_OrdenCompraDetalle_UnidadMedidaId",
                table: "OrdenCompraDetalle");
        }
    }
}
