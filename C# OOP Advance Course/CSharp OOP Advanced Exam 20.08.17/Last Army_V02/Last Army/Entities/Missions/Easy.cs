using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Easy : Mission
{
    private const string MissionName = "Suppression of civil rebellion";
    private const double EnduranceDecrease = 20;
    private const double WearLevelDecrease = 30;

    public Easy(double scoreToComplete)
        :base(scoreToComplete)
    {

    }

    public override string Name => MissionName;

    public override double EnduranceRequired => EnduranceDecrease;

    public override double WearLevelDecrement => WearLevelDecrease;
}

