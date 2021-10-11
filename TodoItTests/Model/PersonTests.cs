using System;
using TodoIt.Model;
using Xunit;

namespace TodoItTests
{
    public class PersonTests
    {

        private Person testPerson;

        public PersonTests()
        {
            testPerson = new Person(1);
            testPerson.FirstName = "firstName";
            testPerson.LastName = "lastName";
        }

        [Fact]
        public void SetLastNameNullTest()
        {
            Assert.Throws<ArgumentException>(() => testPerson.LastName = null);
        }

        [Fact]
        public void SetFirstNameNullTest()
        {
            Assert.Throws<ArgumentException>(() => testPerson.FirstName = null);
        }

        [Fact]
        public void SetLastNameEmptyTest()
        {
            Assert.Throws<ArgumentException>(() => testPerson.LastName = String.Empty);
        }

        [Fact]
        public void SetFirstNameEmptyTest()
        {
            Assert.Throws<ArgumentException>(() => testPerson.FirstName = String.Empty);
        }

        [Fact]
        public void GetIdTest()
        {
            int personId = testPerson.PersonId;
            int expectedPersonId = 1;

            Assert.Equal(expectedPersonId, personId);
        }

        [Fact]
        public void GetFirstNameTest()
        {
            String firstName = testPerson.FirstName;
            String expectedFirstName = "firstName";

            Assert.Equal(expectedFirstName, firstName);
        }

        [Fact]
        public void GetLastNameTest()
        {
            String lastName = testPerson.LastName;
            String expectedLastName = "lastName";

            Assert.Equal(expectedLastName, lastName);
        }

        [Fact]
        public void SetFirstNameTest()
        {
            testPerson.FirstName = "newFirstName";
            String expectedFirstName = "newFirstName";

            Assert.Equal(expectedFirstName, testPerson.FirstName);
        }

        [Fact]
        public void SetLastNameTest()
        {
            testPerson.LastName = "newLastName";
            String expectedLastName = "newLastName";

            Assert.Equal(expectedLastName, testPerson.LastName);
        }
    }
}
