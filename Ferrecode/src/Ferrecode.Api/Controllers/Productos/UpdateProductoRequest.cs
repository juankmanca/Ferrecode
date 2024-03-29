﻿namespace Ferrecode.Api.Controllers.Productos
{
    public class UpdateProductoRequest
    {
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public decimal Medida { get; set; }
        public string UnidadDeMedida { get; set; } = string.Empty;
        public decimal Peso { get; set; }
        public decimal VolumenEmpaque { get; set; }
        public Guid ID { get; set; }
    }
}
