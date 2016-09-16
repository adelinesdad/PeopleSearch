using PeopleSearch.Logic;
using PeopleSearch.Models;
using System.Threading;
using System.Web.Mvc;

namespace PeopleSearch.Controllers
{
    public class PeopleController : Controller
    {
        private ApplicationDbContext _db;
        private ISearch<Person> _search;

        public PeopleController() : base()
        {
            _db = new ApplicationDbContext();
            _search = new PeopleSearcher(_db.People);
        }

        public PeopleController(ISearch<Person> search) : base()
        {
            _search = search;
        }

        // GET: People
        public ActionResult Index()
        {
            return View();
        }

        // POST: People/Search
        [HttpPost]
        public ActionResult Search(SearchCriteria criteria)
        {
            if (criteria == null || string.IsNullOrWhiteSpace(criteria.SearchString))
            {
                return Json(null);
            }

            if (criteria.SimulateDelay)
            {
                Thread.Sleep(2000);
            }

            // todo: support paging
            var people = _search.GetResults(criteria.SearchString);
            return Json(people);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_db != null)
                {
                    _db.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
