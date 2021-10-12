using System;
using TodoIt.Model;

namespace TodoIt.Data
{
    public class TodoItems
    {
        private static Todo[] todoArray = new Todo[0];

        public int Size()
        {
            return todoArray.Length;
        }

        public Todo[] findAll()
        {
            return todoArray;
        }

        public Todo findById(int todoId)
        {
            foreach (Todo todo in todoArray)
            {
                if (todo.TodoId == todoId)
                {
                    return todo;
                }
            }
            return null;
        }

        public Todo Add(String description)
        {
            Todo[] tempArray = todoArray;
            int newLength = todoArray.Length+1;
            todoArray = new Todo[newLength];

            if (todoArray.Length > 1)
                for (int i = 0; i < tempArray.Length; i++)
                {
                    todoArray[i] = tempArray[i];
                }
            todoArray[newLength - 1] = CreateTodo(description);
            return todoArray[newLength - 1];
        }

        private Todo CreateTodo(String description)
        {
            int todoId = TodoSequencer.NextTodoId();
            Todo todo = new Todo(todoId);
            todo.Description = description;
            todo.Done = false;
            return todo;
        }

        public void clear()
        {
            todoArray = new Todo[0];
        }

        public Todo[] FindByDoneStatus(bool done)
        {
            Todo[] sortedArray = new Todo[0];

            
            foreach(Todo todo in todoArray)
            {
                if(todo.Done == done)
                {
                    Array.Resize(ref sortedArray, sortedArray.Length+1);
                    sortedArray[sortedArray.Length-1] = todo;
                }
            }
            return sortedArray;
        }

        public Todo[] FindByAssignee(int personId)
        {
            Todo[] sortedArray = new Todo[0];
            foreach (Todo todo in todoArray)
            {
                if (todo.Person != null && todo.Person.PersonId == personId)
                {
                    Array.Resize(ref sortedArray, sortedArray.Length + 1);
                    sortedArray[sortedArray.Length-1] = todo;
                }
            }
            return sortedArray;
        }

        public Todo[] FindByAssignee(Person person)
        {
            Todo[] sortedArray = new Todo[0];
            foreach (Todo todo in todoArray)
            {
                if (todo.Person != null && todo.Person.PersonId == person.PersonId)
                {
                    Array.Resize(ref sortedArray, sortedArray.Length + 1);
                    sortedArray[sortedArray.Length-1] = todo;
                }
            }
            return sortedArray;
        }

        public Todo[] FindUnassignedTodoItems()
        {
            Todo[] sortedArray = new Todo[0];
            foreach (Todo todo in todoArray)
            {
                if (null == todo.Person)
                {
                    Array.Resize(ref sortedArray, sortedArray.Length + 1);
                    sortedArray[sortedArray.Length-1] = todo;
                }
            }
            return sortedArray;
        }
    }
 
}
