namespace FestivalManager.Entities.Factories
{
	using System;
	using System.Linq;
	using System.Reflection;
	using System.Runtime.InteropServices.WindowsRuntime;
	using Contracts;
	using Entities.Contracts;
	using Instruments;

	public class InstrumentFactory : IInstrumentFactory
	{
		public IInstrument CreateInstrument(string type)
		{
            var assembly = Assembly.GetCallingAssembly();
            var instrument = assembly.GetTypes().FirstOrDefault(t => t.Name == type);

            return (IInstrument)Activator.CreateInstance(instrument);
		}
	}
}