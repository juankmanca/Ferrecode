namespace Ferrecode.Domain.Usuarios
{
    public record Nombre(string Nombres, string Apellidos)
    {
        public string GetFullName() => $"{Nombres} {Apellidos}";
    }

}
