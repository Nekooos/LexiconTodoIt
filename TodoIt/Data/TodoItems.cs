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

        public Todo Add(String description, bool done)
        {
            Todo[] tempArray = todoArray;
            int newLength = todoArray.Length+1;
            todoArray = new Todo[newLength];

            if (todoArray.Length > 1)
                for (int i = 0; i < tempArray.Length; i++)
                {
                    todoArray[i] = tempArray[i];
                }
            todoArray[newLength - 1] = CreateTodo(description, done);
            return todoArray[newLength - 1];
        }

        private Todo CreateTodo(String description, bool done)
        {
            int todoId = TodoSequencer.NextTodoId();
            Todo todo = new Todo(todoId);
            todo.Description = description;
            todo.Done = done;
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

        public void Remove(int id) 
        {
            int index = findIndex(id);

            if(index > -1)
            {
                int newLength = todoArray.Length - 1;
                Todo[] tempArray = todoArray;
                todoArray = new Todo[newLength];

                int count = 0;
                for (int i = 0; i < tempArray.Length; i++)
                {
                    if(i != index)
                    {
                        todoArray[count] = tempArray[i];
                        count++;
                    }
                }
            }
        }

        private int findIndex(int id)
        {
            for (int i = 0; i < todoArray.Length; i++)
            {
                if(todoArray[i].TodoId == id)
                {
                    return i;
                }
            }
            return -1;
        }
    }
 
}
