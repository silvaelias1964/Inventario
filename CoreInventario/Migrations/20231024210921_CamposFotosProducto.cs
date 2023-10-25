using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreInventario.Migrations
{
    /// <inheritdoc />
    public partial class CamposFotosProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrdFoto",
                table: "Producto");

            migrationBuilder.AddColumn<string>(
                name: "PrdFoto1",
                table: "Producto",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrdFoto2",
                table: "Producto",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrdFoto1",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "PrdFoto2",
                table: "Producto");

            migrationBuilder.AddColumn<string>(
                name: "PrdFoto",
                table: "Producto",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }
    }
}
