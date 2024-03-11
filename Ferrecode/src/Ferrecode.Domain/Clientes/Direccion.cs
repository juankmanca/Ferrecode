namespace Ferrecode.Domain.Clientes
{
    public record Direccion(string Value, int IDCiudad, int IDDepartamento)
    {
        public bool IsValid()
        {
            if (IDCiudad == 0) return false;

            if (IDDepartamento == 0) return false;
            else return true;
        }
    }
}
