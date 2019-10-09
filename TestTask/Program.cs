using System;

namespace TestTask
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string sortString = "Chief.LastName, FirstName, Born.Year desc";
            Person person1 = new Person
            {
                Chief = null,
                FirstName = "Ivan",
                LastName = "Ivanov",
                Born = DateTime.MaxValue
            };

            Person person2 = new Person
            {
                Chief = person1,
                FirstName = "Petr",
                LastName = "Petrov",
                Born = DateTime.Now
            };

            Person person3 = new Person
            {
                Chief = null,
                FirstName = "Oleg",
                LastName = "Olegov",
                Born = DateTime.MinValue
            };

            Person person4 = new Person
            {
                Chief = person1,
                FirstName = "Vasya",
                LastName = "Vasin",
                Born = DateTime.Now
            };

            Person[] people = {person1, person2, person3, person4};
            var universalComparer = new UniversalComparer(sortString);

            Array.Sort(people, universalComparer);
        }
    }
}
