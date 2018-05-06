
using System;
using System.Linq;
namespace FestivalManager.Core
{
	using System.Reflection;
	using Contracts;
	using Controllers;
	using Controllers.Contracts;
    using FestivalManager.Core.IO;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Entities.Sets;
    using IO.Contracts;

	 public class Engine : IEngine
	{
	    private IReader reader;
        private IWriter writer;

        private IStage stage;
        private IFestivalController festivalController;
        private ISetController setController;

        public Engine(IWriter writer , IReader reader, FestivalController festivalController)
        {
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
            this.stage = new Stage();
            this.setController = new SetController(stage);
            festivalController = new FestivalController(stage);
        }

        public Engine(IWriter writer, IReader reader, IFestivalController festivalController)
        {
            this.writer = writer;
            this.reader = reader;
            this.festivalController = festivalController;
        }

        public void Run()
		{
            bool isRunning = true;
			while (isRunning)
			{
				var input = reader.ReadLine();

				if (input == "END")
					break;

				try
				{
					string.Intern(input);

					var result = this.ProcessCommand(input);
					this.writer.WriteLine(result);
				}
				catch (Exception ex) // in case we run out of memory
				{
					this.writer.WriteLine("ERROR: " + ex.Message);
				}
			}

			var end = this.festivalController.ProduceReport();

			this.writer.WriteLine("Results:");
			this.writer.WriteLine(end);
		}

		public string ProcessCommand(string input)
		{
			var tokens = input.Split(" ".ToCharArray().First());

			var first = tokens.First();
			var second = tokens.Skip(1).ToArray();

			if (first == "LetsRock")
			{
				var sets = this.setController.PerformSets();
				return sets;
			}

			var festivalcontrolfunction = this.festivalController.GetType()
				.GetMethods()
				.FirstOrDefault(x => x.Name == first);

			string a;

			try
			{
				a = (string)festivalcontrolfunction.Invoke(this.festivalController, new object[] { second });
			}
			catch (TargetInvocationException up)
			{
				throw up; 
			}

			return a;
		}
    }
}