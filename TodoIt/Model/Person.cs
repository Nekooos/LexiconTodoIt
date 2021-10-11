using System;
using System.Collections.Generic;
using System.Text;

namespace TodoIt.Model
{
    public class Person
    {
        private readonly int personId;
        private String firstName;
        private String lastName;

        public Person(int personId)
        {
            this.personId = personId;
        }

        public int PersonId
        {
            get => personId;
        }

        public String FirstName
        {
            get => firstName;
            set
            {
                firstName = NotNullOrEmpty(value);
            }
        }

        public String LastName
        {
            get => lastName; 
            set 
            {
                lastName = NotNullOrEmpty(value);
            }
        }

        private String NotNullOrEmpty(String value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Value can't be null or empty");
            }
            return value;
        }
    }
}
