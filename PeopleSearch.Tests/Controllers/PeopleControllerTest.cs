using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleSearch.Controllers;
using PeopleSearch.Logic;
using PeopleSearch.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PeopleSearch.Tests.Controllers
{
    [TestClass]
    public class PeopleControllerTest
    {
        IList<Person> _people;
        PersonSearchStub _search;

        [TestInitialize]
        public void InitializeTest()
        {
            _people = new List<Person>();
            _search = new PersonSearchStub(_people);
        }

        [TestMethod]
        public void Index__ReturnsView()
        {
            using (PeopleController controller = new PeopleController(_search))
            {
                ViewResult result = controller.Index() as ViewResult;
                Assert.IsNotNull(result);
            }
        }

        [TestMethod]
        public void Search_NullCriteria_ReturnsEmpty()
        {
            using (PeopleController controller = new PeopleController(_search))
            {
                JsonResult result = controller.Search(null) as JsonResult;
                Assert.IsNull(result.Data);
            }
        }

        [TestMethod]
        public void Search_EmptySearch_ReturnsEmpty()
        {
            using (PeopleController controller = new PeopleController(_search))
            {
                SearchCriteria criteria = new SearchCriteria()
                {
                    SearchString = ""
                };
                JsonResult result = controller.Search(criteria) as JsonResult;
                Assert.IsNull(result.Data);
            }
        }

        [TestMethod]
        public void Search_SearchString_ReturnsPeople()
        {
            using (PeopleController controller = new PeopleController(_search))
            {
                SearchCriteria criteria = new SearchCriteria()
                {
                    SearchString = "searchString"
                };
                JsonResult result = controller.Search(criteria) as JsonResult;
                Assert.AreEqual(_people, result.Data);
            }
        }
    }

    internal class PersonSearchStub : ISearch<Person>
    {
        private IList<Person> _results;

        public PersonSearchStub(IList<Person> results)
        {
            _results = results;
        }

        public IList<Person> GetResults(string searchString)
        {
            return _results;
        }
    }
}
