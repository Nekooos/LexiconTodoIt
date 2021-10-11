using Xunit;
using TodoIt.Model;
using System;

namespace TodoItTests.Model
{
    public class TodoTests
    {
        private Todo testTodo;

        public TodoTests()
        {
            testTodo = new Todo(1, "Description");
            testTodo.Done = false;
            testTodo.Person = new Person(1);
            testTodo.Person.FirstName = "firstname";
            testTodo.Person.FirstName = "lastName";
        }

        [Fact]
        public void GetIdTest()
        {
            int todoId = testTodo.TodoId;
            int expected = 1;

            Assert.Equal(expected, todoId);
        }

        [Fact]
        public void GetDescription()
        {
            String description = testTodo.Description;
            String expected = "Description";

            Assert.Equal(expected, description);
        }

        [Fact]
        public void GetDone()
        {
            bool done = testTodo.Done;
            bool expected = false;

            Assert.Equal(expected, done);
        }

        [Fact]
        public void GetPerson()
        {
            Person person = testTodo.Person;
            int expected = 1;

            Assert.Equal(expected, person.PersonId);
        }

        [Fact]
        public void SetDescriptiont()
        {
            testTodo.Description = "new Description";

            Assert.Equal("new Description", testTodo.Description);
        }

        [Fact]
        public void SetDone()
        {
            testTodo.Done = true;

            Assert.True(testTodo.Done);
        }

        [Fact]
        public void SetPerson()
        {
            testTodo.Person = new Person(2);

            Assert.Equal(2, testTodo.Person.PersonId);
        }
    }
}
