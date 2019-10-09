using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniversalComparer;

namespace UniversalComparerTests
{
    [TestClass]
    public class UniversalComparerTests
    {
        [TestMethod]
        public void HasChiefTest()
        {
            const string sortString = "Chief.LastName, FirstName, Born.Year desc";

            var person1 = new Person
            {
                Chief = null,
                FirstName = "Ivan",
                LastName = "Ivanov",
                Born = DateTime.MaxValue
            };

            var person2 = new Person
            {
                Chief = person1,
                FirstName = "Petr",
                LastName = "Petrov",
                Born = DateTime.Now
            };

            var comparer = new UniversalComparer.UniversalComparer(sortString);

            int actual = comparer.Compare(person1, person2);
            int expected = -1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FieldCompareTest()
        {
            const string sortString = "LastName, FirstName, Born.Year desc";

            var person1 = new Person
            {
                Chief = null,
                FirstName = "Petr",
                LastName = "Petrov",
                Born = DateTime.Now
            };

            var person2 = new Person
            {
                Chief = null,
                FirstName = "Ivan",
                LastName = "Ivanov",
                Born = DateTime.MaxValue
            };

            var comparer = new UniversalComparer.UniversalComparer(sortString);

            int actual = comparer.Compare(person1, person2);
            int expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DescFieldCompareTest()
        {
            const string sortString = "LastName desc, FirstName, Born.Year desc";

            var person1 = new Person
            {
                Chief = null,
                FirstName = "Petr",
                LastName = "Petrov",
                Born = DateTime.Now
            };

            var person2 = new Person
            {
                Chief = null,
                FirstName = "Ivan",
                LastName = "Ivanov",
                Born = DateTime.MaxValue
            };

            var comparer = new UniversalComparer.UniversalComparer(sortString);

            int actual = comparer.Compare(person1, person2);
            int expected = -1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HasChiefDescTest()
        {
            const string sortString = "Chief.LastName, FirstName, Born.Year desc";

            var person1 = new Person
            {
                Chief = null,
                FirstName = "Ivan",
                LastName = "Ivanov",
                Born = DateTime.MaxValue
            };

            var person2 = new Person
            {
                Chief = person1,
                FirstName = "Petr",
                LastName = "Petrov",
                Born = DateTime.Now
            };

            var comparer = new UniversalComparer.UniversalComparer(sortString, false);

            int actual = comparer.Compare(person1, person2);
            int expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MonthDayTest()
        {
            const string sortString = "Born.Month desc, Born.Day desc";

            Person[] people = new Person[]
            {
                new Person
                {
                    Chief = null,
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    Born = DateTime.ParseExact("2019-10-09", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },
                new Person
                {
                    Chief = null,
                    FirstName = "Petr",
                    LastName = "Petrov",
                    Born = DateTime.ParseExact("2018-11-09", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },
                new Person
                {
                    Chief = null,
                    FirstName = "Oleg",
                    LastName = "Olegov",
                    Born = DateTime.ParseExact("2017-10-07", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },
                new Person
                {
                    Chief = null,
                    FirstName = "Vasya",
                    LastName = "Vasin",
                    Born = DateTime.ParseExact("2019-10-08", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },
                new Person
                {
                    Chief = null,
                    FirstName = "Egor",
                    LastName = "Egor",
                    Born = DateTime.ParseExact("2019-10-07", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },
                new Person
                {
                    Chief = null,
                    FirstName = "rfdg",
                    LastName = "sdvf",
                    Born = DateTime.ParseExact("2018-06-09", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                }
            };

            var comparer = new UniversalComparer.UniversalComparer(sortString);

            //Actual
            Array.Sort(people, comparer);
            string actual = people[1].FirstName;

            //Expected
            string expected = "Ivan";

            Assert.AreEqual(expected, actual);
        }
    }
}
