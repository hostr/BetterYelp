using BetterYelp.Business.Directors;
using BetterYelp.Models;
using BetterYelp.ServiceConnectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BetterYelp.Controllers
{
    public class SearchController : Controller
    {
        private YelpClient _yelpClient;

        public SearchController()
        {
            _yelpClient = new YelpClient();
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

            _yelpClient.GetToken();
            var results = _yelpClient.SearchBusinesses(vm.Term, vm.Location);

            return Json(results);
        }

    }
}