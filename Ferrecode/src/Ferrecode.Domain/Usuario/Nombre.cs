namespace Ferrecode.Domain.Usuario
{
    public record Nombre(string Nombres, string Apellidos)
    {
        public string GetFullName() => $"{Nombres} {Apellidos}";
    }

}
