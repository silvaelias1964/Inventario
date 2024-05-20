using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreInventario.Migrations
{
    /// <inheritdoc />
    public partial class UsuarioIndiceClave : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Clave",
                table: "Usuario",
                column: "Clave",
                unique: true,
                filter: "[Clave] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Id",
                table: "Usuario",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuario_Clave",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_Id",
                table: "Usuario");
        }
    }
}
