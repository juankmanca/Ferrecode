using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ferrecode.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyNameIDTipoDeDocumento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_TiposDeDocumento_Documento_IDTipoDocumento",
                table: "Clientes");

            migrationBuilder.AddForeignKey(
                name: "IDTipoDocumento",
                table: "Clientes",
                column: "Documento_IDTipoDocumento",
                principalTable: "TiposDeDocumento",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "IDTipoDocumento",
                table: "Clientes");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_TiposDeDocumento_Documento_IDTipoDocumento",
                table: "Clientes",
                column: "Documento_IDTipoDocumento",
                principalTable: "TiposDeDocumento",
                principalColumn: "ID");
        }
    }
}
