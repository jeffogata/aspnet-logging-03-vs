namespace aspnet_logging_03_vs
{
    using Microsoft.Extensions.Logging;

    public class MyClass
    {
        private readonly ILogger<MyClass> _logger;

        public MyClass(ILogger<MyClass> logger)
        {
            _logger = logger;
        }

        public void DoSomething(int input)
        {
            _logger.LogDebug(MyEventIds.Debug, "Starting to do something with input: {0}", input);

            if (input >= -1 && input <= 1)
            {
                _logger.LogInformation(MyEventIds.Information, "Input of {0} is within the optimal range.", input);
            }
            else if (input > 10)
            {
                _logger.LogWarning(MyEventIds.Warning, "Input of {0} is greater than the typical range.", input);
            }
            else if (input < -10)
            {
                _logger.LogError(MyEventIds.Error, "Input of {0} is less than the typical range.", input);
            }

            _logger.LogDebug(MyEventIds.Debug, "Finished doing something with input: {0}", input);
        }
    }
}