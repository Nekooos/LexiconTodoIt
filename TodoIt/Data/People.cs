using TodoIt.Model;
using System;

namespace TodoIt.Data
{
    public class People
    {
        private static Person[] personArray = new Person[0];

        public int Size()
        {
            return personArray.Length;
        }

        public Person[] findAll()
        {
            return personArray;
        }

        public Person findById(int personId)
        {
            foreach(Person person in personArray)
            {
                if(person.PersonId == personId)
                {
                    return person;
                }
            }
            return null;
        }

        public Person Add(String firstName, String lastName) 
        {
            Person[] tempArray = personArray;
            int newLength = personArray.Length+1;
            personArray = new Person[newLength];

            if(personArray.Length > 1)
                for(int i = 0; i < tempArray.Length; i++)
                {
                    personArray[i] = tempArray[i];
                }
            personArray[newLength-1] = CreatePerson(firstName, lastName);
            return personArray[newLength-1];
        }

        private Person CreatePerson(String firstName, String lastName)
        {
            int personId = PersonSequencer.NextPersonId();
            Person person = new Person(personId);
            person.FirstName = firstName;
            person.LastName = lastName;
            return person;
        }

        public void clear()
        {
            personArray = new Person[0];
        }
    }
}
