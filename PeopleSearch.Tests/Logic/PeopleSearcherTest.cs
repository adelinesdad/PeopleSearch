using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleSearch.Logic;
using PeopleSearch.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PeopleSearch.Tests.Logic
{
    [TestClass]
    public class PeopleSearcherTest
    {
        private const int TestPeopleCount = 10;

        private static IReadOnlyCollection<Person> s_people;
        private static IQueryable<Person> s_query;

        [ClassInitialize]
        public static void InitializeClass(TestContext context)
        {
            s_people = GetTestPeople();
            s_query = s_people.AsQueryable();
        }

        private static IReadOnlyCollection<Person> GetTestPeople()
        {
            List<Person> people = new List<Person>();
            for (int i = 0; i < TestPeopleCount; i++)
            {
                people.Add(new Person() { Name = "testFirst testLast" + i });
            }
            return new ReadOnlyCollection<Person>(people);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullQueryable_ThrowsException()
        {
            PeopleSearcher searcher = new PeopleSearcher(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetStart_Negative_ThrowsException()
        {
            PeopleSearcher searcher = new PeopleSearcher(s_query);
            searcher.Start = -1;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetNumResults_Negative_ThrowsException()
        {
            PeopleSearcher searcher = new PeopleSearcher(s_query);
            searcher.NumResults = -1;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Search_NullSearchString_ThrowsException()
        {
            PeopleSearcher searcher = new PeopleSearcher(s_query);
            searcher.GetResults(null);
        }

        [TestMethod]
        public void Search_NoMatch_ReturnsEmpty()
        {
            PeopleSearcher searcher = new PeopleSearcher(s_query);
            var result = searcher.GetResults("nomatch");
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void Search_MatchOne_ReturnsOne()
        {
            PeopleSearcher searcher = new PeopleSearcher(s_query);
            var result = searcher.GetResults("testLast0");
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(s_people.ElementAt(0), result[0]);
        }

        [TestMethod]
        public void Search_MatchesCaseInsensitive_ReturnsMatch()
        {
            PeopleSearcher searcher = new PeopleSearcher(s_query);
            var result = searcher.GetResults("testlast0");
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(s_people.ElementAt(0), result[0]);
        }

        [TestMethod]
        public void Search_MatchAll_ReturnsAll()
        {
            PeopleSearcher searcher = new PeopleSearcher(s_query);
            var result = searcher.GetResults("testLast");
            Assert.AreEqual(TestPeopleCount, result.Count);
        }

        [TestMethod]
        public void Search_SearchMid_ReturnsMid()
        {
            PeopleSearcher searcher = new PeopleSearcher(s_query) { Start = 2, NumResults = 1 };
            var result = searcher.GetResults("testLast");
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(s_people.ElementAt(2), result[0]);
        }
    }
}
