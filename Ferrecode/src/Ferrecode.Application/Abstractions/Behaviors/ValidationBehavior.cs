using Ferrecode.Application.Abstractions.Messaging;
using FluentValidation;
using MediatR;
using Ferrecode.Application.Exceptions;

namespace Ferrecode.Application.Abstractions.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IBaseCommand
    {

        // Nos permite ejecutar multiples instancias de IValidator (multiples validaciones) para mi objeto request
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            // Creamos un contexto para poder ejecutar las validaciones
            var context = new ValidationContext<TRequest>(request);

            // Obtengo todas las validaciones de error
            var validationErrors = _validators
                .Select(validators => validators.Validate(context))
                .Where(validationResult => validationResult.Errors.Any())
                .SelectMany(validationResult => validationResult.Errors)
                .Select(validationFailure => new ValidationError(
                        validationFailure.PropertyName,
                        validationFailure.ErrorMessage
                    )).ToList();

            // Si hay algun error mando una excepcion
            if(validationErrors.Any())
            {
                throw new Exceptions.ValidationException(validationErrors);
            }

            return await next();
        }
    }
}
