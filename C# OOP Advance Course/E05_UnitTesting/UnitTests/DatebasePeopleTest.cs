using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTestExercises;
using UnitTestExercises.Interfaces;
using UnitTestExercises.Models;

namespace UnitTests
{
    public class DatebasePeopleTest
    {
        private DatabasePeople database;

        [SetUp]
        public void TestInitialization()
        {
            this.database = new DatabasePeople();
        }

        [Test]
        public void DatabaseInitializationConstructorWithCollectionOfPeople()
        {
            var firstPerson = new Person(123, "First");
            var secondPerson = new Person(345, "Second");
            var collectionOfPeople = new IPerson[] { firstPerson, secondPerson };

            this.database = new DatabasePeople(collectionOfPeople);

            Assert.AreEqual(2, this.database.Count, $"Constructor doesn't work with {typeof(IPerson)} as parameter");
        }

        [Test]
        public void DatabaseInitializeConstructorWithNullLeadsToEmptyDB()
        {
            Assert.DoesNotThrow(() => this.database = new DatabasePeople(null));
        }

        [Test]
        public void DatabaseAddPerson()
        {
            var person = new Person(111L, "Test");

            this.database.Add(person);

            Assert.AreEqual(1, this.database.Count, $"Add {typeof(IPerson)} doesn't work");
        }

        [Test]
        [TestCase(1L, "1L", 1L, "1L")]
        [TestCase(1L, "1L", 10L, "1L")]
        [TestCase(1L, "1L", 1L, "10L")]
        public void CanNotAddPersonWithAlreadyExistingUsernameOrId(long firstId, string firstUsername, long secondId, string secondUsername)
        {
            var firstPerson = new Person(firstId, firstUsername);
            var secondPerson = new Person(secondId, secondUsername);

            this.database.Add(firstPerson);

            Assert.Throws<InvalidOperationException>(() => this.database.Add(secondPerson));
        }

        [Test]
        public void RemovePersonFromDataBase()
        {
            var firstPerson = new Person(1L, "First");
            var secondPerson = new Person(2L, "Second");
            var thirdPerson = new Person(2, "Second");
            this.database.Add(firstPerson);
            this.database.Add(secondPerson);

            this.database.Remove(thirdPerson);
            this.database.Remove(firstPerson);

            Assert.AreEqual(0, this.database.Count, $"Remove {typeof(IPerson)} doesn't work");
        }

        [Test]
        [TestCase(1L, "1L", 2L, "2L", 3L, "3L", 1L)]
        [TestCase(1L, "1L", 2L, "2L", 3L, "3L", 2L)]
        [TestCase(1L, "1L", 2L, "2L", 3L, "3L", 3L)]
        public void FindById(long firstId, string firstUsername, long secondId, string secondUsername, long thirdId, string thirdUsername, long keyId)
        {
            this.database.Add(new Person(firstId, firstUsername));
            this.database.Add(new Person(secondId, secondUsername));
            this.database.Add(new Person(thirdId, thirdUsername));

            var foundPerson = this.database.Find(keyId);

            Assert.AreEqual(keyId, foundPerson.Id, $"Found {typeof(IPerson)} by Id is not the desired one");
        }

        [Test]
        [TestCase(1L, "1L", 2L, "2L", 3L, "3L", "1L")]
        [TestCase(1L, "1L", 2L, "2L", 3L, "3L", "2L")]
        [TestCase(1L, "1L", 2L, "2L", 3L, "3L", "3L")]
        public void FindByUsername(long firstId, string firstUsername, long secondId, string secondUsername, long thirdId, string thirdUsername, string keyUsername)
        {
            this.database.Add(new Person(firstId, firstUsername));
            this.database.Add(new Person(secondId, secondUsername));
            this.database.Add(new Person(thirdId, thirdUsername));

            var foundPerson = this.database.Find(keyUsername);

            Assert.AreEqual(keyUsername, foundPerson.Username, $"Found {typeof(IPerson)} by Username is not the desired one");
        }

        [Test]
        public void CannotFindUnexistentId()
        { 
            this.database.Add(new Person(1, "First"));

            Assert.Throws<InvalidOperationException>(() => this.database.Find(2));
        }

        [Test]
        public void CannotFindNegativeId()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.database.Find(-1));
        }

        [Test]
        public void CannotFindUnexistentUsername()
        { 
            this.database.Add(new Person(1, "First"));

            Assert.Throws<InvalidOperationException>(() => this.database.Find("fiRst"));
        }

        [Test]
        public void CannotFindUsernameNull()
        {
            this.database.Add(new Person(1, "First"));

            Assert.Throws<ArgumentNullException>(() => this.database.Find(null));
        }
    }
}
