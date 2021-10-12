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
            todoItems.Add("description1", false);
            todoItems.Add("description2", false);
            todoItems.Add("description3", false);
            Todo todoItem = todoItems.Add("description4", false);

            Assert.Equal(4, todoItem.TodoId);
            Assert.Equal(4, todoItems.Size());
        }

        [Fact]
        public void FindByIdTest()
        {
            todoItems.Add("description1", false);
            todoItems.Add("description2", false);

            Todo todo = todoItems.findById(2);

            Assert.True(todo.TodoId == 2);
        }


        [Fact]
        public void FindByIdNoMatchTest()
        {
            todoItems.Add("description1", false);
            todoItems.Add("description2", false);

            Todo todo = todoItems.findById(5);

            Assert.Null(todo);
        }

        [Fact]
        public void ClearTest()
        {
            todoItems.Add("description1", false);
            todoItems.Add("description2", false);
            todoItems.Add("description3", false);

            Assert.Equal(3, todoItems.Size());

            todoItems.clear();

            Assert.Equal(0, todoItems.Size());
        }

        [Fact]
        public void FindAllTest()
        {
            todoItems.Add("description1", false);
            todoItems.Add("description2", false);
            Todo todo = todoItems.Add("description3", false);

            Todo[] todos = todoItems.findAll();

            Assert.True(todos.Length == 3);

            Assert.Equal(3, todo.TodoId);

            Assert.Equal(3, todos[2].TodoId);
        }

        [Fact]
        public void FindByDoneStatusTest()
        {
            todoItems.Add("description1", false);
            todoItems.Add("description2", false);
            todoItems.Add("description3", true);
            todoItems.Add("description4", true);

            Todo[] todos = todoItems.FindByDoneStatus(false);

            Assert.True(todos.Length == 2);
            Assert.Equal(2, todos[1].TodoId);
        }


        [Fact]
        public void FindByAssigneeIdTest()
        {
            Person person1 = new Person(1);
            Person person2 = new Person(2);

            Todo todo1 = todoItems.Add("description1", false);
            todo1.Person = person1;
            Todo todo2 = todoItems.Add("description2", false);
            todo2.Person = person1;
            Todo todo3 = todoItems.Add("description3", false);
            todo3.Person = person2;
            Todo todo4 = todoItems.Add("description4", false);
            todo4.Person = person2;

            Todo[] todos = todoItems.FindByAssignee(2);

            Assert.True(todos.Length == 2);
            Assert.Equal(4, todos[1].TodoId);
        }


        [Fact]
        public void FindByAssigneePersonTest()
        {
            Person person1 = new Person(1);

            Todo todo1 = todoItems.Add("description1", false);
            todo1.Person = person1;
            Todo todo2 = todoItems.Add("description2", false);
            todo2.Person = person1;
            todoItems.Add("description3", false);
            todoItems.Add("description4", false);

            Todo[] todos = todoItems.FindByAssignee(person1);

            Assert.True(todos.Length == 2);
            Assert.Equal(1, todos[0].TodoId);
            Assert.Equal(2, todos[1].TodoId);
        }

        [Fact]
        public void FindUnassignedTodoItemsTest()
        {
            Person person1 = new Person(1);

            Todo todo1 = todoItems.Add("description1", false);
            todo1.Person = person1;
            Todo todo2 = todoItems.Add("description2", false);
            todo2.Person = person1;
            todoItems.Add("description3", false);
            todoItems.Add("description4", false);

            Todo[] todos = todoItems.FindUnassignedTodoItems();

            Assert.True(todos.Length == 2);
            Assert.Equal(4, todos[1].TodoId);
        }

        [Fact]
        public void RemoveTest()
        {
            todoItems.Add("description1", false);
            todoItems.Add("description2", false);
            todoItems.Add("description3", false);
            todoItems.Add("description4", false);

            todoItems.Remove(3);

            Todo[] todos = todoItems.findAll();

            Assert.True(todos.Length == 3);

            Assert.Equal(1, todos[0].TodoId);
            Assert.Equal(2, todos[1].TodoId);
            Assert.Equal(4, todos[2].TodoId);
        }

        [Fact]
        public void RemoveTestIdNotFound()
        {
            todoItems.Add("description1", false);
            todoItems.Add("description2", false);
            todoItems.Add("description3", false);
            todoItems.Add("description4", false);

            todoItems.Remove(26);

            Todo[] todos = todoItems.findAll();

            Assert.True(todos.Length == 4);
        }
    }
}
