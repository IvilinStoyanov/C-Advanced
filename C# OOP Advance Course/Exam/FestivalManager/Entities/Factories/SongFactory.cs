namespace FestivalManager.Entities.Factories
{
	using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
	using Entities.Contracts;

	public class SongFactory : ISongFactory
	{
		public ISong CreateSong(string name, TimeSpan duration)
		{
            var assembly = Assembly.GetCallingAssembly();
            var setFactory = assembly.GetTypes().FirstOrDefault(t => t.Name == name);

            return (ISong)Activator.CreateInstance(setFactory, duration);
        }
	}
}