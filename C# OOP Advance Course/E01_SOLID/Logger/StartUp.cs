using Logger.Models.Contracts;
using System;

namespace Logger
{
    using Logger.Models;
    using Logger.Models.Factories;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            ILogger logger = InitializeLogger();
            ErrorFactory errorFactory = new ErrorFactory();
            Engine engine = new Engine(logger, errorFactory);
            engine.Start();
        }

        static ILogger InitializeLogger()
        {
            ICollection<IAppender> appenders = new List<IAppender>();

            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory(layoutFactory);

            int appenderCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < appenderCount; i++)
            {
                string[] inputArguments = Console.ReadLine().Split();

                // input variables
                var appenderType = inputArguments[0];
                var errorLevel = "INFO";
                var layoutType = inputArguments[1];

                if (inputArguments.Length == 3)
                {
                    errorLevel = inputArguments[2];
                }

                IAppender appender
                    = appenderFactory.CreateAppender(appenderType, errorLevel, layoutType);

                // add appender from factory
                appenders.Add(appender);
            }

            ILogger logger = new Logger(appenders);
            return logger;
        }
    }
}
