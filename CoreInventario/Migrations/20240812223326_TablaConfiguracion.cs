using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreInventario.Migrations
{
    /// <inheritdoc />
    public partial class TablaConfiguracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Configuracion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empresa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Contacto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Iva = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PorIva = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MonedaDefecto = table.Column<int>(type: "int", nullable: false),
                    SmtpContrasena = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SmtpPuerto = table.Column<int>(type: "int", nullable: false),
                    SmtpSender = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SmtpSenvidor = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SmtpSSL = table.Column<bool>(type: "bit", nullable: false),
                    SmtpNombreUsuario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SmtpContrasenaUsuario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualizadoPor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuracion", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Configuracion_Id",
                table: "Configuracion",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configuracion");
        }
    }
}
