using WeShouldGo.Business.Directors;
using WeShouldGo.Models;
using WeShouldGo.ServiceConnectors;
using WeShouldGo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeShouldGo.Controllers
{
    public class SearchController : Controller
    {
        private SearchService _searchService;
        private YelpClient _yelpClient;

        public SearchController(SearchService searchService)
        {
            _searchService = searchService;
        }

        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetBusinesses(SearchRequestViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                // Add error
                return View(vm);
            }

            return Json(null);
        }

    }
}