namespace Forum.App.Factories
{
    using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandFactory : ICommandFactory
    {
        private IServiceProvider serviceProvider;

        public CommandFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public ICommand CreateCommand(string commandName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type commandType = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name == commandName + "Command");

            if (commandType == null)
            {
                throw new ArgumentException($"{commandName}Command not found!");
            }
            if (!typeof(ICommand).IsAssignableFrom(commandType))
            {
                throw new InvalidOperationException($"{commandName}Command is not an ICommand!");
            }

            ConstructorInfo constructor = commandType
                .GetConstructors()
                .First();

            ParameterInfo[] ctroParams = constructor
                .GetParameters();

            object[] arguments = new object[ctroParams.Length];

            for (int i = 0; i < arguments.Length; i++)
            {
                arguments[i] = this.serviceProvider.GetService(ctroParams[i].ParameterType);
            }

            ICommand command = (ICommand)Activator.CreateInstance(commandType, arguments);
            return command;
           // ICommand command1 = (ICommand)constructor.Invoke(arguments);
        }
    }
}
