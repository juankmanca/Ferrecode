using Ferrecode.Application.Abstractions.Messaging;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ferrecode.Application.Abstractions.Behaviors
{
    /// <summary>
    /// El loggin suele no ponerse en el request para evitar lentitud en en las consultas
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IBaseCommand
    {
        private readonly ILogger<TRequest> _logger;

        public LoggingBehavior(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Se encarga de capturar todos los request de tipo command que me envie el cliente,
        /// cuando el cliente quiera insertar un nuevo record, ese insert va a llegar aca
        /// </summary>
        /// <param name="request"></param>
        /// <param name="next"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var name = request.GetType().Name;

            try
            {
                _logger.LogInformation($"Ejecutando el command request: {name}");
                var result = await next();
                _logger.LogInformation($"El comando {name} se ejecuto existosamente");
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"El comando {name} tuvo errores");
                throw;
            }
        }
    }
}
