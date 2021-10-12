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

            todoItems.Add("description1");
            todoItems.Add("description2");
            Todo todo = todoItems.Add("description3");

            Todo[] todos = todoItems.findAll();

            Assert.True(todos.Length == 3);

            Assert.Equal(3, todo.TodoId);

            Assert.Equal(3, todos[2].TodoId);
        }

        [Fact]
        public void FindByDoneStatusTest()
        {
            todoItems.Add("description1");
            todoItems.Add("description2");
            Todo todo1 = todoItems.Add("description3");
            todo1.Done = true;
            Todo todo2 = todoItems.Add("description4");
            todo2.Done = true;

            Todo[] todos = todoItems.FindByDoneStatus(false);

            Assert.True(todos.Length == 2);
            Assert.Equal(2, todos[1].TodoId);
        }


        [Fact]
        public void FindByAssigneeIdTest()
        {
            Person person1 = new Person(1);
            Person person2 = new Person(2);

            Todo todo1 = todoItems.Add("description1");
            todo1.Person = person1;
            Todo todo2 = todoItems.Add("description2");
            todo2.Person = person1;
            Todo todo3 = todoItems.Add("description3");
            todo3.Person = person2;
            Todo todo4 = todoItems.Add("description4");
            todo4.Person = person2;

            Todo[] todos = todoItems.FindByAssignee(2);

            Assert.True(todos.Length == 2);
            Assert.Equal(4, todos[1].TodoId);
        }


        [Fact]
        public void FindByAssigneePersonTest()
        {
            Person person1 = new Person(1);

            Todo todo1 = todoItems.Add("description1");
            todo1.Person = person1;
            Todo todo2 = todoItems.Add("description2");
            todo2.Person = person1;
            todoItems.Add("description3");
            todoItems.Add("description4");

            Todo[] todos = todoItems.FindByAssignee(person1);

            Assert.True(todos.Length == 2);
            Assert.Equal(1, todos[0].TodoId);
            Assert.Equal(2, todos[1].TodoId);
        }

        [Fact]
        public void FindUnassignedTodoItemsTest()
        {
            Person person1 = new Person(1);

            Todo todo1 = todoItems.Add("description1");
            todo1.Person = person1;
            Todo todo2 = todoItems.Add("description2");
            todo2.Person = person1;
            todoItems.Add("description3");
            todoItems.Add("description4");

            Todo[] todos = todoItems.FindUnassignedTodoItems();

            Assert.True(todos.Length == 2);
            Assert.Equal(4, todos[1].TodoId);
        }
    }
}
