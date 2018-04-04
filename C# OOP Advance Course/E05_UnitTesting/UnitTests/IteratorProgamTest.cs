using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnitTestExercises;

namespace UnitTests
{
    public class IteratorProgamTest
    {
        private IteratorProgam iterator;
        private string[] stringCollection;

        [SetUp]
        public void InitializeIterator()
        {
            this.stringCollection = new string[] { "asfdg", "blqblq", "1234" };
            this.iterator = new IteratorProgam(this.stringCollection);
        }

        [Test]
        public void InitializationConstructorCannotWorkWithNull()
        {
            Assert.Throws<ArgumentNullException>(() => new IteratorProgam(null));
        }

        [Test]
        public void MoveReturnsTrueWhenSuccessful()
        {
            Assert.AreEqual(true, this.iterator.Move());
            Assert.AreEqual(true, this.iterator.Move());
        }

        [Test]
        public void MoveReturnsFalseWhenThereIsNoMoreElements()
        {
            this.iterator.Move();
            this.iterator.Move();

            Assert.AreEqual(false, this.iterator.Move());
        }

        [Test]
        public void MoveMovesTheInternalIndexToTheNextElementInTheCollection()
        {
            this.iterator.Move();
            var internalIndexValue = typeof(IteratorProgam)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.Name == "currentIndex")
                .GetValue(this.iterator);

            Assert.AreEqual(1, internalIndexValue);
        }

        [Test]
        public void HasNextReturnsTrueIfThereIsNextElement()
        {
            this.iterator.Move();

            Assert.IsTrue(this.iterator.HasNext());
        }

        [Test]
        public void HasNextReturnsFalseIfThereIsNotNextElement()
        {
            this.iterator.Move();
            this.iterator.Move();

            Assert.IsFalse(this.iterator.HasNext());
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void PrintReturnsCurrentElement(int elementToreturn)
        {
            for (int i = 0; i < elementToreturn; i++)
            {
                this.iterator.Move();
            }

            Assert.AreEqual(this.stringCollection[elementToreturn],
                this.iterator.Print());
        }

        [Test]
        public void CannotPrintWithEmptyIterator()
        {
            this.iterator = new IteratorProgam(new string[0]);

            var ex
                = Assert
                .Throws<InvalidOperationException>(() => this.iterator.Print());
            Assert.AreEqual("Invalid Operation!", ex.Message);

        }
    }
}

