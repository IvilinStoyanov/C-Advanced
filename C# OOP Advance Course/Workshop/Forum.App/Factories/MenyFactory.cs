using Forum.App.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace Forum.App.Factories
{
    public class MenyFactory : IMenuFactory
    {
        private IServiceProvider serviceProvider;

        public MenyFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IMenu CreateMenu(string menuName)
        {
            Type menuType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == menuName + "Menu");

            if(menuType == null)
            {
                throw new ArgumentException($"{menuName}Menu is not found!");
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
