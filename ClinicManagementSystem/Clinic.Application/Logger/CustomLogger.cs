using Serilog;

namespace ClinicManagement.Application
{
    public class CustomLogger
    {
        private readonly ILogger _logger;

        public CustomLogger(ILogger logger)
        {
            _logger = logger;
        }
        public void Information(string message)
        {
            _logger.Information(message);
        }

        public void Warning(string message)
        {
            _logger.Warning(message);
        }
        public void Error(string message)
        {
            _logger.Error(message);
        }
        public void Error(Exception? exception , string message)
        {
            _logger.Error(message);
        }
        public ILogger ForContext(string propertyName, string value)
        {
            return _logger.ForContext(propertyName, value);
        }
    }
}
