using Ferrecode.Domain.Abstractions;

namespace Ferrecode.Domain.Clientes
{
    public static class ClienteErrors
    {
        public static Error NotFound = new("Cliente.ErrorNotFound", "Cliente no encontrado");
        public static Error ErrorSaving = new("Cliente.ErrorInesperado", "Error inesperado guardando un nuevo cliente");
        public static Error ErrorDelete = new("Cliente.ErrorInesperado", "Error inesperado borrando un cliente");
        public static Error Duplicated = new("Cliente.Duplicated", "Este cliente ya existe");
        public static Error Block = new("Cliente.Block", "Este cliente ya esta eliminado");
        public static Error InvalidDocuemnt = new("Cliente.InvalidDocument", "El documento no es valido para el tipo seleccionado");
    }
}
