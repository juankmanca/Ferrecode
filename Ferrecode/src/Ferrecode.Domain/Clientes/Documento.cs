using System.Text.RegularExpressions;

namespace Ferrecode.Domain.Clientes
{
    public record Documento(string NumeroDocumento, TiposDeDocumento TipoDocumento)
    {
        // Realizar aqui las respectivas validaciones segun el tipo de docuento

        public bool EsValido()
        {
            return TipoDocumento switch
            {
                TiposDeDocumento.CedulaDeCiudadanía => ValidarCedulaCiudadania(),
                TiposDeDocumento.CedulaDeExtranjeria => ValidarCedulaExtranjeria(),
                TiposDeDocumento.Pasaporte => ValidarPasaporte(),
                TiposDeDocumento.NIT => ValidarNIT(),
                _ => false,
            };
        }

        private bool ValidarCedulaCiudadania()
        {
            if (NumeroDocumento.Length != 10)
                return false;

            // Implementación de la validación de cédula de ciudadanía
            return Regex.IsMatch(NumeroDocumento, @"^\d{10}$");
        }

        private bool ValidarCedulaExtranjeria()
        {
            if (NumeroDocumento.Length != 11)
                return false;

            // Implementación de la validación de cédula de extranjería
            return Regex.IsMatch(NumeroDocumento, @"^\d{11}$");
        }

        private bool ValidarPasaporte()
        {
            // Implementación de la validación de pasaporte
            return !string.IsNullOrEmpty(NumeroDocumento);
        }

        private bool ValidarNIT()
        {
            if (NumeroDocumento.Length != 9 && NumeroDocumento.Length != 10)
                return false;

            // Implementación de la validación de NIT
            return Regex.IsMatch(NumeroDocumento, @"^\d{9}(\d{1})?$");
        }
    }
}
