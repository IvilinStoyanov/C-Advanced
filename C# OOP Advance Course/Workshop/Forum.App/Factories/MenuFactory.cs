using Forum.App.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace Forum.App.Factories
{
    public class MenuFactory : IMenuFactory
    {
        private IServiceProvider serviceProvider;

        public MenuFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IMenu CreateMenu(string menuName)
        {
            Type menuType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == menuName);

            if(menuType == null)
            {
                throw new ArgumentException($"{menuName}Command is not found!");
            }

            if(!typeof(IMenu).IsAssignableFrom(menuType))
            {
                throw new InvalidOperationException($"{menuName}Menu is not an IMenu!");
            }

            ParameterInfo[] ctroParams = menuType
                .GetConstructors()
                .First()
                .GetParameters();

            object[] arguments = new object[ctroParams.Length];

            for (int i = 0; i < arguments.Length; i++)
            {
                arguments[i] = this.serviceProvider.GetService(ctroParams[i].ParameterType);
            }

            IMenu menu = (IMenu)Activator.CreateInstance(menuType, arguments);
            return menu;
        }
    }
}
