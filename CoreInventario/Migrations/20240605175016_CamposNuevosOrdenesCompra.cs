using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreInventario.Migrations
{
    /// <inheritdoc />
    public partial class CamposNuevosOrdenesCompra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OccDireccion",
                table: "OrdenCompra",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OccMismaDireccion",
                table: "OrdenCompra",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OccNombre",
                table: "OrdenCompra",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OccDireccion",
                table: "OrdenCompra");

            migrationBuilder.DropColumn(
                name: "OccMismaDireccion",
                table: "OrdenCompra");

            migrationBuilder.DropColumn(
                name: "OccNombre",
                table: "OrdenCompra");

            migrationBuilder.DropColumn(
                name: "OccTelefono1",
                table: "OrdenCompra");

            migrationBuilder.DropColumn(
                name: "OccTelefono2",
                table: "OrdenCompra");

            migrationBuilder.DropColumn(
                name: "OccTelefono3",
                table: "OrdenCompra");
        }
    }
}
