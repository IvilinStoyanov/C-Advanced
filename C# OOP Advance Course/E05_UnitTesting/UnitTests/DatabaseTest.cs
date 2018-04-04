using Exercises_Models.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercises_Models.Tests
{
    public class DatabaseTests
    {
        private const string DATABASE_FULL = "Database is currently full";
        private const string DATABASE_EMPTY = "Database is empty!";

        [Test]
        public void RegisterElementsInDateBase()
        {
            Database<int> database = new Database<int>(12, 9, -5, -5, 10);
            Assert.AreEqual(5, database.Count);
        }

        [Test]
        public void EmptyDatabaseHasZeroCount()
        {
            Database<int> database = new Database<int>();

            Assert.AreEqual(0, database.Count);
        }

        [Test]
        public void ThrowsExceptionOnFullDatabase()
        {
            Database<int> database = new Database<int>(Enumerable.Range(0, 16).ToArray());

            Exception ex = Assert.Throws<InvalidOperationException>(() => database.Add(100));

            Assert.AreEqual(DATABASE_FULL, ex.Message);
        }

        [Test]
        public void ThrowsExceptionOnInitializingDateBaseFullCapacity()
        {
            try
            {
                Database<int> database = new Database<int>(Enumerable.Range(0, 17).ToArray());
            }
            catch (Exception ex)
            {
                Assert.AreEqual(DATABASE_FULL, ex.Message);
                return;
            }

            Assert.Fail();
        }

        [Test]
        public void RemoveLastItemFromDatabase()
        {
            Database<int> database = new Database<int>(1, 2, 3);

            Assert.That(() => database.Remove() == 3);
        }

        [Test]
        public void RemovingItemChangesCount()
        {
            Database<int> database = new Database<int>(1);

            database.Remove();

            Assert.AreEqual(0, database.Count);
        }

        [Test]
        public void RemovingItemFromEmptyDatabaseThrowsException()
        {
            Database<int> database = new Database<int>();

            Exception ex = Assert.Throws<InvalidOperationException>(() => database.Remove());

            Assert.AreEqual(DATABASE_EMPTY, ex.Message);
        }

        [Test]
        public void FetchingDatabaseReturnsCorrectCollection()
        {
            Database<int> database = new Database<int>(Enumerable.Range(0, 16).ToArray());
            int[] numbers = Enumerable.Range(0, 16).ToArray();

            int[] returnedCollection = database.Fetch();

            Assert.IsTrue(numbers.SequenceEqual(returnedCollection));
        }

        [Test]
        public void FetchEmptyDatabaseReturnsEmptyCollection()
        {
            Database<int> database = new Database<int>();
            int[] numbers = new int[0];

            int[] returnedCollection = database.Fetch();

            Assert.IsTrue(numbers.SequenceEqual(returnedCollection));
        }
    }
}