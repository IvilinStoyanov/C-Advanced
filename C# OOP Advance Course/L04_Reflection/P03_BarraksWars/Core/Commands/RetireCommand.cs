using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core.Commands
{
    public class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory) : base(data, repository, unitFactory)
        {

        }

        public override string Execute()
        {
            string unityType = Data[1];
            try
            {
                this.Repository.RemoveUnit(unityType);
                return $"{unityType} retired!";
            }
            catch (Exception e)
            {

                throw new ArgumentException("No such units in repository", e);
            }

        }
    }
}
