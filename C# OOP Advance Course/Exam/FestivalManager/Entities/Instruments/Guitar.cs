namespace FestivalManager.Entities.Instruments
{
    public class Guitar : Instrument
    {
        private const int repairValue = 60;

        protected override int RepairAmount => repairValue;
    }
}
