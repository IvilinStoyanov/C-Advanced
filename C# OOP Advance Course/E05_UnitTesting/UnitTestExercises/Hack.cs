using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestExercises
{
    public class Hack
    {
        public virtual int MathAbsExample(int number)
        {
            var negativeNumber = -5;
            return Math.Abs(negativeNumber);
        }

        public virtual int MathFloorExample(double number)
        {
            return (int)Math.Floor(number);
        }
    }
}
