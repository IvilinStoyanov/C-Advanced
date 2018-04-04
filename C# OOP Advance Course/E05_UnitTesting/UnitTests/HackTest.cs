using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTestExercises;
using System.Linq;

namespace UnitTests
{
    public class HackTest
    {
        [Test]
        public void ValidMathAbs()
        {
            var hack = new Hack();
            Assert.That(() => hack.MathAbsExample(-5), Is.EqualTo(5));
        }

        [Test]
        public void ValidMathFloor()
        {
            Hack hack = new Hack();
            var mock = new Mock<Hack>();
            mock.Setup(m => m.MathFloorExample(2.7));

            Assert.That(() => hack.MathFloorExample(2.7), Is.EqualTo(2));
        }
    }

}

