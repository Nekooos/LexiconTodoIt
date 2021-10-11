using System;

namespace TodoIt.Model
{
    public class Todo
    {
        private readonly int todoId;
        private String description;
        private bool done;
        private Person assignee;

        public Todo(int todoId)
        {
            this.todoId = todoId;
        }

        public int TodoId
        {
            get => todoId;
        }

        public String Description
        {
            get => description;
            set => description = value;
        }

        public bool Done
        {
            get => done;
            set => done = value;
        }

        public Person Person
        {
            get => assignee;
            set => assignee = value;
        }
    }
}
