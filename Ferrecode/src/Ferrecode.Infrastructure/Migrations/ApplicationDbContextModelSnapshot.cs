﻿// <auto-generated />
using System;
using Ferrecode.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ferrecode.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ferrecode.Domain.Clientes.Cliente", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IDPuntoDeVenta")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("IDPuntoDeVenta");

                    b.ToTable("Clientes", (string)null);
                });

            modelBuilder.Entity("Ferrecode.Domain.Clientes.TipoDeDocumento", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Acronimo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TiposDeDocumento", (string)null);
                });

            modelBuilder.Entity("Ferrecode.Domain.DetallePedidos.DetallePedido", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Cantidad")
                        .HasColumnType("int");

                    b.Property<Guid>("IDPedido")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDProducto")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("IDPedido");

                    b.HasIndex("IDProducto");

                    b.ToTable("DetallePedidos", (string)null);
                });

            modelBuilder.Entity("Ferrecode.Domain.Inventarios.Inventario", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IDProducto")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDPuntoDeVenta")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("IDProducto");

                    b.HasIndex("IDPuntoDeVenta");

                    b.ToTable("Inventarios", (string)null);
                });

            modelBuilder.Entity("Ferrecode.Domain.Pedidos.Pedido", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCierre")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaFacturacion")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IDCliente")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("IDCliente");

                    b.ToTable("Pedidos", (string)null);
                });

            modelBuilder.Entity("Ferrecode.Domain.Productos.Producto", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Peso")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<decimal?>("VolumenEmpaque")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("Productos", (string)null);
                });

            modelBuilder.Entity("Ferrecode.Domain.PuntosDeVenta.PuntoDeVenta", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("PuntosDeVenta", (string)null);
                });

            modelBuilder.Entity("Ferrecode.Domain.Clientes.Cliente", b =>
                {
                    b.HasOne("Ferrecode.Domain.PuntosDeVenta.PuntoDeVenta", null)
                        .WithMany()
                        .HasForeignKey("IDPuntoDeVenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Ferrecode.Domain.Clientes.Direccion", "Direccion", b1 =>
                        {
                            b1.Property<Guid>("ClienteID")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("IDCiudad")
                                .HasColumnType("int")
                                .HasColumnName("IDCiudad");

                            b1.Property<int>("IDDepartamento")
                                .HasColumnType("int")
                                .HasColumnName("IDDepartamento");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Direccion");

                            b1.HasKey("ClienteID");

                            b1.ToTable("Clientes");

                            b1.WithOwner()
                                .HasForeignKey("ClienteID");
                        });

                    b.OwnsOne("Ferrecode.Domain.Clientes.Documento", "Documento", b1 =>
                        {
                            b1.Property<Guid>("ClienteID")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("NumeroDocumento")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("NumeroDocumento");

                            b1.Property<int>("TipoDocumento")
                                .HasColumnType("int")
                                .HasColumnName("IDTipoDocumento");

                            b1.HasKey("ClienteID");

                            b1.ToTable("Clientes");

                            b1.WithOwner()
                                .HasForeignKey("ClienteID");
                        });

                    b.Navigation("Direccion");

                    b.Navigation("Documento");
                });

            modelBuilder.Entity("Ferrecode.Domain.DetallePedidos.DetallePedido", b =>
                {
                    b.HasOne("Ferrecode.Domain.Pedidos.Pedido", null)
                        .WithMany()
                        .HasForeignKey("IDPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ferrecode.Domain.Productos.Producto", null)
                        .WithMany()
                        .HasForeignKey("IDProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ferrecode.Domain.Inventarios.Inventario", b =>
                {
                    b.HasOne("Ferrecode.Domain.Productos.Producto", null)
                        .WithMany()
                        .HasForeignKey("IDProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ferrecode.Domain.PuntosDeVenta.PuntoDeVenta", null)
                        .WithMany()
                        .HasForeignKey("IDPuntoDeVenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ferrecode.Domain.Pedidos.Pedido", b =>
                {
                    b.HasOne("Ferrecode.Domain.Clientes.Cliente", null)
                        .WithMany()
                        .HasForeignKey("IDCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ferrecode.Domain.Productos.Producto", b =>
                {
                    b.OwnsOne("Ferrecode.Domain.Productos.Medida", "Medida", b1 =>
                        {
                            b1.Property<Guid>("ProductoID")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("UnidadDeMedida")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("UnidadDeMedida");

                            b1.Property<decimal>("Value")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("ValorMedida");

                            b1.HasKey("ProductoID");

                            b1.ToTable("Productos");

                            b1.WithOwner()
                                .HasForeignKey("ProductoID");
                        });

                    b.Navigation("Medida");
                });
#pragma warning restore 612, 618
        }
    }
}
