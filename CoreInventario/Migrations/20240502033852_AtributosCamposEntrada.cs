using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreInventario.Migrations
{
    /// <inheritdoc />
    public partial class AtributosCamposEntrada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrada_Producto_ProductoId",
                table: "Entrada");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                table: "Entrada",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EntDetalles",
                table: "Entrada",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddForeignKey(
                name: "FK_Entrada_Producto_ProductoId",
                table: "Entrada",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrada_Producto_ProductoId",
                table: "Entrada");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                table: "Entrada",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "EntDetalles",
                table: "Entrada",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Entrada_Producto_ProductoId",
                table: "Entrada",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "Id");
        }
    }
}
