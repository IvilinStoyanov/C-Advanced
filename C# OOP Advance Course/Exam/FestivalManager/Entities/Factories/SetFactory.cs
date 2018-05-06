using System;

using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using Sets;

    public class SetFactory : ISetFactory
    {
        public ISet CreateSet(string name, string type)
        {
            var assembly = Assembly.GetCallingAssembly();
            var setFactory = assembly.GetTypes().FirstOrDefault(t => t.Name == type);

            return (ISet)Activator.CreateInstance(setFactory, name);
        }
    }
}
