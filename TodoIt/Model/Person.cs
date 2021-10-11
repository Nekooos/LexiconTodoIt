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

        public Person(int personId, String firstName, String lastName)
        {
            this.personId = personId;
            this.firstName = NullOrEmpty(firstName);
            this.lastName = NullOrEmpty(lastName);
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
                firstName = NullOrEmpty(value);
            }
        }

        public String LastName
        {
            get => lastName; 
            set 
            {
                lastName = NullOrEmpty(value);
            }
        }

        private String NullOrEmpty(String value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Value can't be null or empty");
            }
            return value;
        }
    }
}
