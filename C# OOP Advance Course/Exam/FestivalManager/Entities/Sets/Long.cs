using System;
using System.Collections.Generic;
using System.Text;

namespace FestivalManager.Entities.Sets
{
    class Long : Set
    {
        private const int TimeLimit = 60;

        public Long(string name)
            : base(name, new TimeSpan(0, TimeLimit, 0))
        {
        }
    }
}
