﻿namespace FestivalManager.Entities.Instruments
{
    public class Drums : Instrument
    {
        private const int repairValue = 20;

        protected override int RepairAmount => repairValue;
    }
}