namespace FestivalManager.Entities.Instruments
{
    public class Microphone : Instrument
    {
        private const int repairValue = 80;

        protected override int RepairAmount => repairValue;
    }
}
