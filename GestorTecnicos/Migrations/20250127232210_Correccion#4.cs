using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorTecnicos.Migrations
{
    /// <inheritdoc />
    public partial class Correccion4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CiudadId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CiudadId",
                table: "Clientes");
        }
    }
}
