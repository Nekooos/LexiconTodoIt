using System;
using Xunit;
using TodoIt.Data;
using TodoIt.Model;

namespace TodoItTests.Data
{
    public class TodoItemsTests : IDisposable
    {
        private TodoItems todoItems;

        public TodoItemsTests()
        {
            todoItems = new TodoItems();
            TodoSequencer.Reset();
            todoItems.clear();
        }

        public void Dispose()
        {
            TodoSequencer.Reset();
            todoItems.clear();
        }

        [Fact]
        public void AddTest()
        {
            todoItems.Add("description1");
            todoItems.Add("description2");
            todoItems.Add("description3");
            Todo todoItem = todoItems.Add("description4");

            Assert.Equal(4, todoItem.TodoId);
            Assert.Equal(4, todoItems.Size());
        }

        [Fact]
        public void findByIdTest()
        {
            todoItems.Add("description1");
            todoItems.Add("description2");

            Todo todo = todoItems.findById(2);

            Assert.True(todo.TodoId == 2);
        }


        [Fact]
        public void findByIdNoMatchTest()
        {
            todoItems.Add("description1");
            todoItems.Add("description2");

            Todo todo = todoItems.findById(5);

            Assert.Null(todo);
        }

        [Fact]
        public void clearTest()
        {
            todoItems.Add("description1");
            todoItems.Add("description2");
            todoItems.Add("description3");

            Assert.Equal(3, todoItems.Size());

            todoItems.clear();

            Assert.Equal(0, todoItems.Size());
        }

        [Fact]
        public void findAllTest()
        {
            TodoSequencer.Reset();
            todoItems.clear();

            todoItems.Add("description1");
            todoItems.Add("description2");
            Todo todo = todoItems.Add("description3");

            Todo[] todos = todoItems.findAll();

            Assert.True(todos.Length == 3);

            Assert.Equal(3, todo.TodoId);

            Assert.Equal(3, todos[2].TodoId);
        }
    }
}
