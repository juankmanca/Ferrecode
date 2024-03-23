namespace Ferrecode.Domain.Clientes
{
    public enum TiposDeDocumento
    {
        CedulaDeCiudadanía = 0, //CC
        CedulaDeExtranjeria = 1, //CE
        Pasaporte = 2, //PP
        NIT = 3 // (Número de Identificación Tributaria): NIT
    }

    public sealed class TipoDeDocumento
    {
        public TipoDeDocumento()
        {

        }

        public int ID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Acronimo { get; set; } = string.Empty;
    }
}
