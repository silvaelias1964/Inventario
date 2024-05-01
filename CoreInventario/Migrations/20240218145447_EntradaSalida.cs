using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreInventario.Migrations
{
    /// <inheritdoc />
    public partial class EntradaSalida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PrdId",
                table: "Salida",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "Salida",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PrdId",
                table: "Entrada",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "Entrada",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Salida_ProductoId",
                table: "Salida",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_ProductoId",
                table: "Entrada",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrada_Producto_ProductoId",
                table: "Entrada",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Salida_Producto_ProductoId",
                table: "Salida",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrada_Producto_ProductoId",
                table: "Entrada");

            migrationBuilder.DropForeignKey(
                name: "FK_Salida_Producto_ProductoId",
                table: "Salida");

            migrationBuilder.DropIndex(
                name: "IX_Salida_ProductoId",
                table: "Salida");

            migrationBuilder.DropIndex(
                name: "IX_Entrada_ProductoId",
                table: "Entrada");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "Salida");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "Entrada");

            migrationBuilder.AlterColumn<int>(
                name: "PrdId",
                table: "Salida",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PrdId",
                table: "Entrada",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
