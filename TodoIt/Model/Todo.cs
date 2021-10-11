using System;
using System.Collections.Generic;
using System.Text;

namespace TodoIt.Model
{
    public class Todo
    {
        private readonly int todoId;
        private String description;
        private bool done;
        private Person assignee;

        public Todo(int todoId, String description)
        {
            this.todoId = todoId;
            this.description = description;
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
