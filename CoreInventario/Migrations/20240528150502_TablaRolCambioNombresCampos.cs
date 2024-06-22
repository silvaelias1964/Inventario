using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreInventario.Migrations
{
    /// <inheritdoc />
    public partial class TablaRolCambioNombresCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreRol",
                table: "Rol",
                newName: "RolNombre");

            migrationBuilder.RenameColumn(
                name: "CodigoRol",
                table: "Rol",
                newName: "RolCodigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RolNombre",
                table: "Rol",
                newName: "NombreRol");

            migrationBuilder.RenameColumn(
                name: "RolCodigo",
                table: "Rol",
                newName: "CodigoRol");
        }
    }
}
