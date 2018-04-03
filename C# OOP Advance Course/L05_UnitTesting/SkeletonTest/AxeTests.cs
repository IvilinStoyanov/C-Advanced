using NUnit.Framework;
using System;

namespace SkeletonTest
{
    public class AxeTests
    {
        Axe axe;
        private const int initialAxeDamage = 5;
        private const int initalAxeDurability = 10;

        [SetUp]
        public void InitializedAxe()
        {
            axe = new Axe(initialAxeDamage, initalAxeDurability);
        }

        [Test]
        public void AxeLosesDurabillityAfterAttack()
        {
            var dummy = new Dummy(20, 20);
            axe.Attack(dummy);
            Assert.That(axe.DurabilityPoints, Is.EqualTo(9));
        }

        [Test]
        public void BrokenAxeCannotAttack()
        {
             const int axeDurability = 0;

            var axe = new Axe(initialAxeDamage, axeDurability);
            var dummy = new Dummy(20, 20);
            Assert.That(() => axe.Attack(dummy),
            Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
        }
    }
}
