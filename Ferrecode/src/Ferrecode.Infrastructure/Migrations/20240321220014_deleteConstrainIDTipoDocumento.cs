using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ferrecode.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class deleteConstrainIDTipoDocumento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "IDTipoDocumento",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_Documento_IDTipoDocumento",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Documento_IDTipoDocumento",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "Documento_TipoDocumento",
                table: "Clientes",
                newName: "IDTipoDocumento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IDTipoDocumento",
                table: "Clientes",
                newName: "Documento_TipoDocumento");

            migrationBuilder.AddColumn<int>(
                name: "Documento_IDTipoDocumento",
                table: "Clientes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Documento_IDTipoDocumento",
                table: "Clientes",
                column: "Documento_IDTipoDocumento");

            migrationBuilder.AddForeignKey(
                name: "IDTipoDocumento",
                table: "Clientes",
                column: "Documento_IDTipoDocumento",
                principalTable: "TiposDeDocumento",
                principalColumn: "ID");
        }
    }
}
