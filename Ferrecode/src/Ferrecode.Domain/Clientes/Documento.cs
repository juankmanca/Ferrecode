using System.Text.RegularExpressions;

namespace Ferrecode.Domain.Clientes
{
    public record Documento(string NumeroDocumento, TiposDeDocumento TipoDocumento)
    {

        // Realizar aqui las respectivas validaciones segun el tipo de docuento

        public bool IsValid()
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
            // Implementación de la validación de cédula de ciudadanía
            return Regex.IsMatch(NumeroDocumento, @"^\d{0,10}$");
        }

        private bool ValidarCedulaExtranjeria()
        {
            // Implementación de la validación de cédula de extranjería
            return Regex.IsMatch(NumeroDocumento, @"^\d{0,12}$");
        }

        private bool ValidarPasaporte()
        {
            // Implementación de la validación de pasaporte
            return Regex.IsMatch(NumeroDocumento, @"^\d{6,20}$");
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
