using Ferrecode.Application.Abstractions.Clock;

namespace Ferrecode.Infrastructure.Clock
{
    internal sealed class DateTimeProvider : IDateTimeProvider
    {
        public DateTime currentTime => DateTime.UtcNow;
    }
}
