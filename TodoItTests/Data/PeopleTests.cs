using System;
using TodoIt.Data;
using TodoIt.Model;
using Xunit;

namespace TodoItTests.Data
{
    public class PeopleTests : IDisposable
    {
        private People people;

        public PeopleTests()
        {
            people = new People();
            PersonSequencer.Reset();
            people.clear();
        }

        public void Dispose()
        {
            PersonSequencer.Reset();
            people.clear();
        }

        [Fact]
        public void AddTest()
        {
            people.Add("firstName1", "lastName1");
            people.Add("firstName2", "lastName2");
            Person person3 = people.Add("firstName3", "lastName3");

            Assert.Equal(3, person3.PersonId);
            Assert.Equal(3, people.Size());
        }

        [Fact]
        public void addEmptyTest()
        {
            Assert.Throws<ArgumentException>(() => people.Add(String.Empty, "lastName"));
        }

        [Fact]
        public void addNullTest()
        {
            Assert.Throws<ArgumentException>(() => people.Add(null, "lastName"));
        }


        [Fact]
        public void findByIdTest()
        {
            people.Add("firstName1", "lastName1");
            people.Add("firstName2", "lastName2");

            Person person = people.findById(2);

            Assert.True(person.PersonId == 2);
        }


        [Fact]
        public void findByIdNoMatchTest()
        {
            people.Add("firstName1", "lastName1");
            people.Add("firstName2", "lastName2");

            Person person = people.findById(5);

            Assert.Null(person);
        }

        [Fact]
        public void clearTest()
        {
            people.Add("firstName1", "lastName1");
            people.Add("firstName2", "lastName2");

            Assert.Equal(2, people.Size());

            people.clear();

            Assert.Equal(0, people.Size());
        }

        [Fact]
        public void findAllTest()
        {
            people.Add("firstName1", "lastName1");
            people.Add("firstName2", "lastName2");

            Person[] persons = people.findAll();

            Assert.True(persons.Length == 2);
            Assert.Equal(1, persons[0].PersonId);
            Assert.Equal(2, persons[1].PersonId);
        }

        [Fact]
        public void RemoveTest()
        {
            people.Add("firstName1", "lastName1");
            people.Add("firstName1", "lastName1");
            people.Add("firstName1", "lastName1");
            people.Add("firstName1", "lastName1");

            people.Remove(3);

            Person[] persons = people.findAll();

            Assert.True(persons.Length == 3);

            Assert.Equal(1, persons[0].PersonId);
            Assert.Equal(2, persons[1].PersonId);
            Assert.Equal(4, persons[2].PersonId);
        }
    }
}
