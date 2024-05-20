using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreInventario.Migrations
{
    /// <inheritdoc />
    public partial class TablaUsuarioMasRol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_CategoriaProducto_CatId",
                table: "Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Proveedor_PrvId",
                table: "Producto");

            migrationBuilder.RenameColumn(
                name: "PrvId",
                table: "Producto",
                newName: "ProveedorId");

            migrationBuilder.RenameColumn(
                name: "CatId",
                table: "Producto",
                newName: "CategoriaProductoId");

            migrationBuilder.RenameIndex(
                name: "IX_Producto_PrvId",
                table: "Producto",
                newName: "IX_Producto_ProveedorId");

            migrationBuilder.RenameIndex(
                name: "IX_Producto_CatId",
                table: "Producto",
                newName: "IX_Producto_CategoriaProductoId");

            migrationBuilder.AlterColumn<string>(
                name: "Correo",
                table: "Usuario",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RolId",
                table: "Usuario",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoRol = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NombreRol = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualizadoPor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RolId",
                table: "Usuario",
                column: "RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_CategoriaProducto_CategoriaProductoId",
                table: "Producto",
                column: "CategoriaProductoId",
                principalTable: "CategoriaProducto",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Proveedor_ProveedorId",
                table: "Producto",
                column: "ProveedorId",
                principalTable: "Proveedor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Rol_RolId",
                table: "Usuario",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_CategoriaProducto_CategoriaProductoId",
                table: "Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Proveedor_ProveedorId",
                table: "Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Rol_RolId",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_RolId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "ProveedorId",
                table: "Producto",
                newName: "PrvId");

            migrationBuilder.RenameColumn(
                name: "CategoriaProductoId",
                table: "Producto",
                newName: "CatId");

            migrationBuilder.RenameIndex(
                name: "IX_Producto_ProveedorId",
                table: "Producto",
                newName: "IX_Producto_PrvId");

            migrationBuilder.RenameIndex(
                name: "IX_Producto_CategoriaProductoId",
                table: "Producto",
                newName: "IX_Producto_CatId");

            migrationBuilder.AlterColumn<string>(
                name: "Correo",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_CategoriaProducto_CatId",
                table: "Producto",
                column: "CatId",
                principalTable: "CategoriaProducto",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Proveedor_PrvId",
                table: "Producto",
                column: "PrvId",
                principalTable: "Proveedor",
                principalColumn: "Id");
        }
    }
}
