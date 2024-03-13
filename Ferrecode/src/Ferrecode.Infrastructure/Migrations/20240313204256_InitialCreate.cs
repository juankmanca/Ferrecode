using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ferrecode.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValorMedida = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UnidadDeMedida = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Peso = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VolumenEmpaque = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PuntosDeVenta",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuntosDeVenta", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Inventarios",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDPuntoDeVenta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDProductos = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventarios", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Inventarios_Productos_IDProductos",
                        column: x => x.IDProductos,
                        principalTable: "Productos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventarios_PuntosDeVenta_IDPuntoDeVenta",
                        column: x => x.IDPuntoDeVenta,
                        principalTable: "PuntosDeVenta",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventarios_IDProductos",
                table: "Inventarios",
                column: "IDProductos");

            migrationBuilder.CreateIndex(
                name: "IX_Inventarios_IDPuntoDeVenta",
                table: "Inventarios",
                column: "IDPuntoDeVenta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventarios");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "PuntosDeVenta");
        }
    }
}
