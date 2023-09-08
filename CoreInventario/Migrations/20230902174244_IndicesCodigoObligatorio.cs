using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreInventario.Migrations
{
    /// <inheritdoc />
    public partial class IndicesCodigoObligatorio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "PrvCodigo",
                table: "Proveedor",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PrdCodigo",
                table: "Producto",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CliCodigo",
                table: "Cliente",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_PrvCodigo",
                table: "Proveedor",
                column: "PrvCodigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Producto_PrdCodigo",
                table: "Producto",
                column: "PrdCodigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_CliCodigo",
                table: "Cliente",
                column: "CliCodigo",
                unique: true);
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

            migrationBuilder.AlterColumn<string>(
                name: "PrvCodigo",
                table: "Proveedor",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "PrdCodigo",
                table: "Producto",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "CliCodigo",
                table: "Cliente",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

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
    }
}
