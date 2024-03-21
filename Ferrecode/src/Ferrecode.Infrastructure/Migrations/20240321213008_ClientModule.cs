using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ferrecode.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ClientModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Cantidad",
                table: "Inventarios",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDTipoDocumento = table.Column<int>(type: "int", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDCiudad = table.Column<int>(type: "int", nullable: true),
                    IDDepartamento = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDPuntoDeVenta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Clientes_PuntosDeVenta_IDPuntoDeVenta",
                        column: x => x.IDPuntoDeVenta,
                        principalTable: "PuntosDeVenta",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaCierre = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFacturacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_IDCliente",
                        column: x => x.IDCliente,
                        principalTable: "Clientes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallePedidos",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDPedido = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDProducto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallePedidos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DetallePedidos_Pedidos_IDPedido",
                        column: x => x.IDPedido,
                        principalTable: "Pedidos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallePedidos_Productos_IDProducto",
                        column: x => x.IDProducto,
                        principalTable: "Productos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IDPuntoDeVenta",
                table: "Clientes",
                column: "IDPuntoDeVenta");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedidos_IDPedido",
                table: "DetallePedidos",
                column: "IDPedido");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedidos_IDProducto",
                table: "DetallePedidos",
                column: "IDProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IDCliente",
                table: "Pedidos",
                column: "IDCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallePedidos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.AlterColumn<int>(
                name: "Cantidad",
                table: "Inventarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValue: 0);
        }
    }
}
