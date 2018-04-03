using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkeletonTest
{
    public class DummyTest
    {
        Dummy dummy;

        [SetUp]
        public void InitializedBank()
        {
             dummy = new Dummy(10, 20);
        }

        [Test]
        public void DummyLosesHealthAfterAttack()
        {
            dummy.TakeAttack(5);

            Assert.That(dummy.Health, Is.EqualTo(5));
        }
    }
}
