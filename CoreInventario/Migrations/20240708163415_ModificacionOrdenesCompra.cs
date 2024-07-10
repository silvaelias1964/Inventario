using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreInventario.Migrations
{
    /// <inheritdoc />
    public partial class ModificacionOrdenesCompra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OccTelefono1",
                table: "OrdenCompra");

            migrationBuilder.DropColumn(
                name: "OccTelefono2",
                table: "OrdenCompra");

            migrationBuilder.DropColumn(
                name: "OccTelefono3",
                table: "OrdenCompra");

            migrationBuilder.RenameColumn(
                name: "OccNombre",
                table: "OrdenCompra",
                newName: "OccTelefonos");

            migrationBuilder.AddColumn<string>(
                name: "OccCorreosElec",
                table: "OrdenCompra",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OccObservaciones",
                table: "OrdenCompra",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OccCorreosElec",
                table: "OrdenCompra");

            migrationBuilder.DropColumn(
                name: "OccObservaciones",
                table: "OrdenCompra");

            migrationBuilder.RenameColumn(
                name: "OccTelefonos",
                table: "OrdenCompra",
                newName: "OccNombre");

            migrationBuilder.AddColumn<string>(
                name: "OccTelefono1",
                table: "OrdenCompra",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OccTelefono2",
                table: "OrdenCompra",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OccTelefono3",
                table: "OrdenCompra",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true);
        }
    }
}
