using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreInventario.Migrations
{
    /// <inheritdoc />
    public partial class TablaUsuarioCamposNuevos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Clave",
                table: "Usuario",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<int>(
                name: "EstatusUsuario",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsNotificacion",
                table: "Usuario",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstatusUsuario",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "IsNotificacion",
                table: "Usuario");

            migrationBuilder.AlterColumn<string>(
                name: "Clave",
                table: "Usuario",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);
        }
    }
}
