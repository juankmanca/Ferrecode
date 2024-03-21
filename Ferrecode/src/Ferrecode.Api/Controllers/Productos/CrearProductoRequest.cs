using System.ComponentModel.DataAnnotations;

namespace Ferrecode.Api.Controllers.Productos
{
    public sealed record CrearProductoRequest
    {
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        public string Nombre { get; set; } = string.Empty;
        
        [Required]
        public decimal Precio { get; set; }
        
        [Required]
        public decimal Medida { get; set; }
        
        [Required]
        public string UnidadDeMedida { get; set; } = string.Empty;
        
        [Required]
        public decimal Peso { get; set; }
        
        [Required]
        public decimal VolumenEmpaque { get; set; }
        
        [Required]
        public Guid IDPuntoDeVenta { get; set; }
    }

}
