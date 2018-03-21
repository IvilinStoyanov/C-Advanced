using Logger.Models.Contracts;
using Logger.Models.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class Engine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        public Engine(ILogger logger, ErrorFactory errorFactory)
        {
            this.logger = logger;
            this.errorFactory = errorFactory;
        }

        public void Start()
        {
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] errorArguments = input.Split("|");

                //variables from input 
                string level = errorArguments[0];
                string dateTime = errorArguments[1];
                string message = errorArguments[2];

                IError error = errorFactory.CreateError(dateTime, level, message);
                this.logger.Log(error);
            }

            Console.WriteLine("Logger Info");
            foreach (IAppender appender in this.logger.Appenders)
            {
                Console.WriteLine(appender);
            }
            
        }
    }
}
