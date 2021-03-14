using Microsoft.Extensions.Logging;

namespace LoggingTestingDelegates
{
    public class MathClass
    {
        private readonly ILogger _logger;

        public MathClass(ILogger<MathClass> logger)
        {
            _logger = logger;
        }

        public void LoggingMethod()
        {
            _logger.LogInformation("________This is logging information__________");
            _logger.LogWarning("______logWarning_________");
            _logger.LogTrace("_________LogTrace_________");
            _logger.LogError("_________logerror_________");
        }
    }
}