namespace FestivalManager.Entities.Sets
{
    using System;

    public class Medium : Set
    {
        private const int TimeLimit = 40;

        public Medium(string name)
                : base(name, new TimeSpan(0, TimeLimit, 0))
        {
        }
    }
}
