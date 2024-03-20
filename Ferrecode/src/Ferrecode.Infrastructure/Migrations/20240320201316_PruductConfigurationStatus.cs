using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ferrecode.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PruductConfigurationStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventarios_Productos_IDProductos",
                table: "Inventarios");

            migrationBuilder.RenameColumn(
                name: "IDProductos",
                table: "Inventarios",
                newName: "IDProducto");

            migrationBuilder.RenameIndex(
                name: "IX_Inventarios_IDProductos",
                table: "Inventarios",
                newName: "IX_Inventarios_IDProducto");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "PuntosDeVenta",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Productos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventarios_Productos_IDProducto",
                table: "Inventarios",
                column: "IDProducto",
                principalTable: "Productos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventarios_Productos_IDProducto",
                table: "Inventarios");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "PuntosDeVenta");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Productos");

            migrationBuilder.RenameColumn(
                name: "IDProducto",
                table: "Inventarios",
                newName: "IDProductos");

            migrationBuilder.RenameIndex(
                name: "IX_Inventarios_IDProducto",
                table: "Inventarios",
                newName: "IX_Inventarios_IDProductos");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventarios_Productos_IDProductos",
                table: "Inventarios",
                column: "IDProductos",
                principalTable: "Productos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
